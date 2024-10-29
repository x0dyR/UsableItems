using UnityEngine;

[RequireComponent(typeof(CapsuleCollider)), RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    [SerializeField] private Transform _itemHandleTransform;
    [SerializeField] private Transform _shootPoint;

    [SerializeField] private UsableItem _item;

    [SerializeField] private float _rotationAngleSpeed;

    [field: SerializeField] private int _health;
    [field: SerializeField] private float _speed;
    [field: SerializeField] private Bullet _bulletPrefab;

    private InputSystem _input;

    private Mover _mover;

    private Inventory _inventory;

    private ItemCollector _itemCollector;

    private Vector3 _inputDirection;

    private CapsuleCollider _collider;

    private Rigidbody _rigidbody;

    [field: SerializeField] public CharacterData CharacterData { get; private set; }

    public Transform ShootPoint => _shootPoint;

    private void Awake()
    {
        _input = new InputSystem();

        CharacterData = new CharacterData(_health, _speed, _bulletPrefab, transform);

        _mover = new Mover(transform, CharacterData, _rotationAngleSpeed);

        _inventory = new Inventory(_itemHandleTransform);

        _itemCollector = new ItemCollector(_inventory);

        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }

    private void Update()
    {
        _inputDirection = _input.ReadInput().normalized;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_inventory.HasItem() == false)
                return;

            _item = _inventory.GetItem();

            _item.UseItem(CharacterData);

            _speed = CharacterData.Speed;
            _health = CharacterData.Health;
        }

        _mover.ProcessMove(_inputDirection);
    }

    private void OnTriggerEnter(Collider other)
        => _itemCollector.TryColllectItem(other);

}

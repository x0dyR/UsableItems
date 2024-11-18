using UnityEngine;

[RequireComponent(typeof(CapsuleCollider)), RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    [SerializeField] private UsableItem _item;
    [SerializeField] private Transform _itemHandleTransform;

    [SerializeField] private Transform _shootPoint;

    [SerializeField] private int _health;

    [SerializeField] private float _speed;

    private InputSystem _input;

    private Mover _mover;

    private Vector3 _inputDirection;

    private Inventory _inventory;

    private ItemCollector _itemCollector;

    private CapsuleCollider _collider;

    private Rigidbody _rigidbody;

    [field: SerializeField] public EntityData CharacterData { get; private set; }

    private void Awake()
    {
        _input = new InputSystem();

        CharacterData = new EntityData(_health, _speed, _shootPoint);

        _mover = new Mover(transform, CharacterData);

        _inventory = new Inventory(_itemHandleTransform);
        _itemCollector = new ItemCollector(_inventory);
    }

    private void Update()
    {
        _inputDirection = _input.ReadInput().normalized;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_inventory.HasItem() == false)
            {
                Debug.Log("No item in inventory");
                return;
            }

            if (_inventory.TryGetItem(out _item))
                _item.UseItem(CharacterData);
        }

        _mover.ProcessMove(_inputDirection);
    }

    private void OnHealthChanged(int healthAmount)
        => _health = healthAmount;

    private void OnSpeedChanged(float speedAmount)
        => _speed = speedAmount;

    private void OnTriggerEnter(Collider other)
        => _itemCollector.TryCollectItem(other);

    private void OnEnable()
    {
        CharacterData.HealthChanged += OnHealthChanged;
        CharacterData.SpeedChanged += OnSpeedChanged;
    }

    private void OnDisable()
    {
        CharacterData.HealthChanged -= OnHealthChanged;
        CharacterData.SpeedChanged -= OnSpeedChanged;
    }
}
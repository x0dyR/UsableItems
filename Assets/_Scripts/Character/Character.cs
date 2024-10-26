using UnityEngine;

[RequireComponent(typeof(CapsuleCollider)), RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    [SerializeField] private Transform _itemHandle;
    [SerializeField] private Transform _shootPoint;

    [SerializeField] private UsableItem _item;
    
    [SerializeField]private float _rotationAngleSpeed;

    private CharacterData _characterData;

    private InputSystem _input;

    private Mover _mover;

    private Vector3 _inputDirection;

    private CapsuleCollider _collider;

    private Rigidbody _rigidbody;

    public CharacterData CharacterData => _characterData;

    public Transform ShootPoint => _shootPoint;

    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public Bullet BulletPrefab { get; private set; }

    private void Awake()
    {
        _input = new InputSystem();

        _characterData = new CharacterData(Health, Speed, BulletPrefab);

        _mover = new Mover(transform, _characterData.Speed,_rotationAngleSpeed);

        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }

    private void Update()
    {
        _inputDirection = _input.ReadInput().normalized;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_item == null)
                return;
            _characterData = _item.Use(this);

            Destroy(_item.gameObject);

            _mover = new Mover(transform, _characterData.Speed,_rotationAngleSpeed);

            Speed = _characterData.Speed;
            Health = _characterData.Health;
            BulletPrefab = _characterData.BulletPrefab;
        }

        _mover.ProcessMove(_inputDirection);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out UsableItem item))
        {
            if (_item == null)
            {
                _item = item;
                _item.transform.SetParent(_itemHandle.transform);
                _item.transform.localPosition = Vector3.zero;
            }
        }
    }
}

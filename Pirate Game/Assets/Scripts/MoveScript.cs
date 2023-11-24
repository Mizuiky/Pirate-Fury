using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [Header("Movement Components")]

    [SerializeField]
    private float _speed;

    private Vector3 _moveTo;

    private Vector2 _direction;

    private float _horizontal;

    private float _vertical;

    public bool isMoving = false;

    [Space(10)]

    [Header("Rotation Components")]

    [SerializeField]
    private float _speedRotation;

    private Quaternion _RotateTo;

    private float _angle;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if(isMoving)
            SetInput();
    }

    public void Init()
    {
        isMoving = true;
    }

    private void SetInput()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        _direction = new Vector2(_horizontal, _vertical);

        if (_direction != Vector2.zero)
        {
            Move(_direction);
            Rotate();
        }
    }

    private void Move(Vector2 direction)
    {
        _moveTo = direction * _speed * Time.deltaTime;

        transform.position += _moveTo;
    }

    private void Rotate()
    {
        _angle = Mathf.Atan2(_moveTo.x, _moveTo.y) * Mathf.Rad2Deg;

        _RotateTo = Quaternion.Euler(0, 0, _angle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, _RotateTo, _speedRotation * Time.deltaTime);
    }

    public void OnDrawGizmos()
    {
        Ray ray = new Ray(transform.position, _moveTo);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray);

    }
}

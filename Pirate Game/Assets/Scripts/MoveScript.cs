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

        Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, _moveTo);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, _speedRotation * Time.deltaTime);
    }

    public void OnDrawGizmos()
    {
        Ray ray = new Ray(transform.position, _moveTo);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray);
    }
}

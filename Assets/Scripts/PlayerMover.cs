using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private PlayerInput _input;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        _input = new PlayerInput();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 moveDirection = _input.Player.Move.ReadValue<Vector2>();

        Move(moveDirection);
    }

    private void Move(Vector2 direction)
    {
        float scaledMoveSpeed = _moveSpeed * Time.fixedDeltaTime;

        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        _rigidbody.AddForce(moveDirection * scaledMoveSpeed, ForceMode.VelocityChange);
    }
}

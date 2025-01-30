using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _xClamp = 3f;
    [SerializeField] private float _zClamp = 3f;
    
    private Vector2 _movement;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }
    
    private void HandleMovement()
    {
        Vector3 currentPosition = _rigidbody.position;
        Vector3 moveDirection = new Vector3(_movement.x, 0, _movement.y);
        Vector3 newPosition = currentPosition + moveDirection * (_moveSpeed * Time.fixedDeltaTime);
        
        newPosition.x = Mathf.Clamp(newPosition.x, -_xClamp, _xClamp);
        newPosition.z = Mathf.Clamp(newPosition.z, -_zClamp, _zClamp);
        
        _rigidbody.MovePosition(newPosition);
    }
}

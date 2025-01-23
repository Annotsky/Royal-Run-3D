using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float xClamp = 3f;
    [SerializeField] private float zClamp = 3f;
    
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
        Vector3 newPosition = currentPosition + moveDirection * (moveSpeed * Time.fixedDeltaTime);
        
        newPosition.x = Mathf.Clamp(newPosition.x, -xClamp, xClamp);
        newPosition.z = Mathf.Clamp(newPosition.z, -zClamp, zClamp);
        
        _rigidbody.MovePosition(newPosition);
    }
    
}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 movement;
    Rigidbody rb;
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float xClamp = 4f;
    [SerializeField] float zClamp = 2f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        HandleMovement();    
    }

    void HandleMovement()
    {
        Vector3 currentPos = rb.position;
        Vector3 moveDirection = new Vector3(movement.x, 0f, movement.y);
        Vector3 newPos = currentPos + moveDirection * (moveSpeed * Time.deltaTime);
        newPos.x = Mathf.Clamp(newPos.x,-xClamp,xClamp);
        newPos.z = Mathf.Clamp(newPos.z,-zClamp,zClamp);

        rb.MovePosition(newPos);
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
}

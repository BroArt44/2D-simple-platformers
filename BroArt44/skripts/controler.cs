using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction jumpAction;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    public float speed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();

        jumpAction.performed += OnJump;
    }

    void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();

        jumpAction.performed -= OnJump;
    }

    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.linearVelocity;
        velocity.x = moveInput.x * speed;
        rb.linearVelocity = velocity;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wold ground"))
        {
            // Дополнительно можно проверить контактные точки, но обычно этого достаточно
            isGrounded = true;
        }
    }
}
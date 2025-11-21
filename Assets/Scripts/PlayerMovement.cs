using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 7f;
    public float glideGravityScale = 0.3f; // gravedad suave al planear

    private Rigidbody rb;
    private bool isGrounded;
    private bool isGliding;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        // mover lateral (X), mantener Y, Z bloqueada
        rb.linearVelocity = new Vector3(x * speed, rb.linearVelocity.y, 0f);

        // salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, 0f);
        }

        // planeo si mantienes espacio en el aire
        isGliding = Input.GetButton("Jump") && !isGrounded;
    }

    void FixedUpdate()
    {
        if (isGliding)
        {
            rb.AddForce(Physics.gravity * (glideGravityScale - 1f), ForceMode.Acceleration);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
            isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
            isGrounded = false;
    }
}

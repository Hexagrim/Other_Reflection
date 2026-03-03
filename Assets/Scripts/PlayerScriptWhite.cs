using UnityEngine;

public class PlayerScriptWhite : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    public float jumpSpeed;
    public float mult;
    public bool isGrounded;

    public Transform groundCheck;
    public float checkRadius = 0.2f;   
    public LayerMask groundLayer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            checkRadius,
            groundLayer
        );

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocityY = jumpSpeed;
        }

        if(rb.linearVelocityY > 0f)
        {
            rb.gravityScale = 2f;
        }
        else
        {
            rb.gravityScale = 4f;
        }
        if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rb.linearVelocityX = 0;
        }

    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocityX = speed * mult;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocityX = -speed * mult;

        }
    }
    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}

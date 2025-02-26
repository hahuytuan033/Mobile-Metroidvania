using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Player Properties")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [Header("Collision Properties")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;

    private float xInput;

    private bool facingRight = true;
    private int facingDir = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerCollision();
        PlayerInput();
        PlayerMovement();
        Flip();
        PlayerAnimation();
    }

    private void PlayerInput()
    {
        xInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.K) && isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void PlayerCollision()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
    }

    private void PlayerMovement()
    {
        rb.linearVelocity = new Vector2(xInput * speed, rb.linearVelocity.y);
    }

    private void PlayerAnimation()
    {
        anim.SetFloat("xVelocity", rb.linearVelocity.x);
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
        anim.SetBool("isGrounded", isGrounded);
    }

    private void Flip()
    {
        if(xInput< 0 && facingRight || xInput > 0 && !facingRight)
        {
            facingDir = facingDir * -1;
            transform.Rotate(0.0f, 180.0f, 0.0f);
            facingRight = !facingRight;
        }
    }

    private void OrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundCheckDistance));        
    }
}

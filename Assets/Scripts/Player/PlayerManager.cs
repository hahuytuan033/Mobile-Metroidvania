using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float acceleration = .1f; //tăng tốc
    [SerializeField] private float jumpForce = 7f;

    private Rigidbody2D rb;
    private Animator anim;
    private bool jump = true;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        speed += acceleration * Time.deltaTime;
        transform.Translate(new Vector2(1f, 0f) * Time.deltaTime * speed);

        if (Input.GetKey(KeyCode.Space) && jump == true)
        {
            Jump();
            jump = false;
        }
    }

    void Jump()
    {
        Vector2 velocity = rb.linearVelocity;
        velocity.y = jumpForce;
        rb.linearVelocity = velocity;
        anim.SetBool("isGrounded", true);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jump = true;
            anim.SetBool("isGrounded", false);
        }
    }
}


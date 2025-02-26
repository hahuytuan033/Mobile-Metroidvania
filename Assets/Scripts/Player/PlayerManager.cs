using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private float speed;

    private float xInput;

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
        xInput = Input.GetAxis("Horizontal");
        PlayerAnimation();
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        rb.linearVelocity = new Vector2(xInput * speed, rb.linearVelocity.y);
    }

    private void PlayerAnimation()
    {
        anim.SetFloat("xVeclocity", rb.linearVelocity.x);
    }
}

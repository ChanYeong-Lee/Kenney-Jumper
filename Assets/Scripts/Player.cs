using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;
    private Animator animator;
    public int jumpCount;
    public bool isGround;
    public bool isJumping;
    public bool alive;
    float velocity;
    private void Awake()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
        jumpCount = 0;
        alive = true;
    }

    private void Update()
    {
        if (alive)
        {
            CheckGround();
            if (isGround)
                jumpCount = 2;
            TryJump();
        }
        rb.gravityScale = 2 + GameManager.objectMoveSpeed / 3;
        animator.SetFloat("runningSpeed", GameManager.objectMoveSpeed / 3);
        animator.SetBool("isJumping", !isGround);
        animator.SetBool("isDead", !alive);
    }

    private void FixedUpdate()
    {
        if (transform.position.x < -5.5)
        {
            transform.Translate(Vector2.right * Time.fixedDeltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Obstacle"))
        {
            alive = false;
            rb.velocity = new Vector2(0, 1.5f * velocity);
            col.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("DeadLine"))
        {
            GameManager.Instance.GameOver();
        }
    }

    private void CheckGround()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 1.05f);
        if (ray.collider != null)
        {
            if (ray.collider.gameObject.tag.Equals("Floor"))
            {
                Debug.Log("Hitfloor");
                isGround = true;
                isJumping = false;
            }
        }
        else
        {
            isGround = false;
        }
    }
    private void TryJump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (jumpCount > 0)
            {
                Jump();
                jumpCount--;
            }
        }
    }

    private void Jump()
    {
        isJumping = true;
        isGround = false;
        velocity = Mathf.Sqrt(2 * rb.gravityScale * 9.81f * 2);
        rb.velocity = new Vector2(0, velocity);
    }
}

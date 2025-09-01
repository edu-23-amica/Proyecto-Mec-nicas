using System;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public float speed = 3f;
    public float moveInput;
    public Animator animator;
    public new Rigidbody2D rigidbody2D;
    public float jumpForce = 8f;
    public bool isOnGround;
    public FireBallSpawner spawner;

    private void Awake()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(transform.position.y > collision.contacts[0].point.y){
            isOnGround = true;
        }
    }


    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(moveInput)); 

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround)
        {
            isOnGround = false;
            animator.Play("Jump");
            rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float direction = Mathf.Sign(transform.localScale.x);
            animator.Play("Attack");
            spawner.SpawnFireball(direction);
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigidbody2D.linearVelocity.y);
    }

}

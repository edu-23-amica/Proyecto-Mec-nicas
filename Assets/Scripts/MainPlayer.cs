using System;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{

    public float speed = 3f;
    public float jumpForce = 7f;
    public Animator animator;
    public new Rigidbody2D rigidbody2D;
    public bool isOnGround;
    public float moveInput;


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

    // Update is called once per frame
    void Update()
    {
        //float
        moveInput = Input.GetAxis("Horizontal");
        Debug.Log(moveInput);
        animator.SetFloat("Speed", moveInput);

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(5, 5, 5); // mira a la derecha

        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-5, 5, 5); // mira a la izquierda

        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && isOnGround)
        {
            isOnGround = false;
            animator.Play("Jump");
            rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, jumpForce);
        }
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("Attack");
        }
        */
    }

    private void FixedUpdate()
    {
        rigidbody2D.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigidbody2D.linearVelocity.y);
    }
}

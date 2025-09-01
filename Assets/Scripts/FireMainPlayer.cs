using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FireMainPlayer : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 moveDirection = Vector2.zero;
    private Rigidbody2D rb;
    public Animator animator;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;

    public float _dir;

    public void SetDirection(float direction)
    {
        _dir = direction;
        moveDirection = new Vector2(direction, 0);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        if(_dir > 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if(_dir < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        rb.linearVelocity = moveDirection * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.GetComponent<MainPlayer>() != null)
        {
            boxCollider.enabled = false;
        }
        else
        {
            boxCollider.enabled = true;
            Debug.Log("Entre en contacto");
            StartCoroutine(DisableFire(0.2f));
        }
    }

    private IEnumerator DisableFire(float seconds)
    {
        animator.Play("Explotion");
        yield return new WaitForSeconds(seconds);
        boxCollider.enabled = false;
        spriteRenderer.enabled = false;
    }
}
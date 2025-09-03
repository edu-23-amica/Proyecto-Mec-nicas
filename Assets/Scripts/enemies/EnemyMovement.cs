using UnityEngine;

[RequireComponent(typeof(EnemyBehaviour))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform flippable;

    private EnemyBehaviour behaviour;
    private Animator animator;
    private Rigidbody2D rb;
    private bool shouldMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        behaviour = GetComponent<EnemyBehaviour>();
        behaviour.stateChanged += OnStateChange;
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
    }

    void OnStateChange()
    {
        shouldMove = behaviour.State == EnemyState.Following;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shouldMove)
        {
            int dir =
                PlayerLocator.Player.transform.position.x < transform.position.x
                ? -1
                : 1;
            animator.SetFloat("speed", dir);
            flippable.localScale = new Vector3(dir, 1, 1);
            rb.linearVelocity = dir * speed * Time.fixedDeltaTime * Vector2.right;
        }
        else
        {
            animator.SetFloat("speed", 0);
        }
    }
}

using System.Linq;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private float attackDistance;
    [SerializeField]
    private Transform eyesight;
    [SerializeField]
    private Transform backEyesight;

    private EnemyState state;

    public EnemyState State { get => state; }

    public delegate void StateChanged();
    public StateChanged stateChanged;

    private Collider2D collider;

    void Start()
    {
        GetComponent<EnemyHealth>().onDeath += HasDied;
        collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (state == EnemyState.Dead) return;
        RaycastHit2D[] hitL = Physics2D.RaycastAll(backEyesight.position, transform.right * -1, 100f);
        RaycastHit2D[] hitR = Physics2D.RaycastAll(eyesight.position, transform.right, 100f);
        Debug.DrawRay(backEyesight.position, transform.right * -100, Color.red);
        Debug.DrawRay(eyesight.position, transform.right * 100, Color.blue);

        bool foundPlayer = false;
        foreach (var hit in hitL.Concat(hitR))
        {
            if (hit.collider.gameObject == PlayerLocator.Player)
            {
                float distance = Vector3.Distance(transform.position, PlayerLocator.Player.transform.position);

                if (distance > attackDistance)
                {
                    SetState(EnemyState.Following);
                }
                else
                {
                    SetState(EnemyState.Attacking);
                }
                foundPlayer = true;
                break;
            }
        }
        if (!foundPlayer) // Can't see player
        {
            SetState(EnemyState.Idle);
        }
    }

    void SetState(EnemyState newState)
    {
        if (state == newState) return;
        state = newState;
        stateChanged?.Invoke();
    }

    void HasDied()
    {
        SetState(EnemyState.Dead);
        collider.enabled = false;
    }
}

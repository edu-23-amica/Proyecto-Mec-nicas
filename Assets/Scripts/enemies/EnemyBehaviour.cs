using UnityEngine;

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

    void Update()
    {
        RaycastHit2D hitL = Physics2D.Raycast(backEyesight.position, transform.right * -1, 100f);
        RaycastHit2D hitR = Physics2D.Raycast(eyesight.position, transform.right, 100f);
        Debug.DrawRay(backEyesight.position, transform.right * -100, Color.red);
        Debug.DrawRay(eyesight.position, transform.right * 100, Color.blue);

        Debug.Log(hitL.collider?.gameObject.name);
        Debug.Log(hitR.collider?.gameObject.name);

        if ((!hitL.collider || hitL.collider.gameObject != PlayerLocator.Player)
        && (!hitR.collider || hitR.collider.gameObject != PlayerLocator.Player)) // Can't see player
        {
            SetState(EnemyState.Idle);
        }
        else
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
        }
    }

    void SetState(EnemyState newState)
    {
        if (state == newState) return;
        state = newState;
        stateChanged?.Invoke();
    }
}

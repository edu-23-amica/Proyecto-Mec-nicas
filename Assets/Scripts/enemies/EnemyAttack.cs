using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyBehaviour))]
public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    int damage;
    [SerializeField]
    float attackCooldown;
    [SerializeField]
    Transform attackTLCorner;
    [SerializeField]
    Transform attackBRCorner;

    bool canAttack = true;

    EnemyBehaviour behaviour;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        behaviour = GetComponent<EnemyBehaviour>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack && behaviour.State == EnemyState.Attacking)
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("attack");
        Collider2D[] collisions =
            Physics2D.OverlapAreaAll(attackTLCorner.position, attackBRCorner.position);
        foreach (Collider2D coll in collisions)
        {
            if (coll.TryGetComponent(out PlayerHealth ph))
            {
                ph.DealDamage(damage);
            }
        }

        StartCoroutine(AttackCooldown());
    }

    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}

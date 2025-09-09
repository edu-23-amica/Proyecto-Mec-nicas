using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private float timeToDeath;
    private int health;
    private Animator animator;

    public int MaxHealth { get => maxHealth; }
    public int Health { get => health; }

    public delegate void OnDeath();
    public OnDeath onDeath;
    public delegate void OnHurt();
    public OnDeath onHurt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        health = maxHealth;
    }
    void Start()
    {
        onDeath += StartDeathCoroutine;
        animator = GetComponent<Animator>();
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        Debug.Log("vida enemigo: " + health);
        onHurt?.Invoke();
        if (health <= 0)
        {
            onDeath?.Invoke();
        }
    }

    void StartDeathCoroutine()
    {
        StartCoroutine(Death());
    }

    IEnumerator Death()
    {
        animator.Play("death");
        yield return new WaitForSeconds(timeToDeath);
        SceneLoader.LoadWinState();
        gameObject.SetActive(false);
    }
}
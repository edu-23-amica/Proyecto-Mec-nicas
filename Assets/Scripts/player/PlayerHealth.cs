using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    private int health;

    public int MaxHealth { get => maxHealth; }
    public int Health { get => health; }

    public delegate void OnDeath();
    public OnDeath onDeath;
    public delegate void OnHurt();
    public OnDeath onHurt;

    public delegate void OnRecover();
    public OnRecover onRecover;


    void Awake()
    {
        health = maxHealth;
    }
    void Start()
    {
        
        onDeath += ActionsOnDeath;
       
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player health is now: " + health);
        onHurt?.Invoke();
        if (health <= 0)
        {
            onDeath?.Invoke();
        }
    }

    public void Recover()
    {
        health++;
        onRecover?.Invoke();
        Debug.Log("Player recovered life: " + health);
    }

  

    void ActionsOnDeath()
    {
        // Desactivar al main player al morir
        gameObject.SetActive(false);
    }
}

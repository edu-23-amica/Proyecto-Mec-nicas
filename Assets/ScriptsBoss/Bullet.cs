using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float tiempoBala = 3f;
    public int daño = 2;
    public PlayerHealth ph;
    void Start()
    {
        Destroy(gameObject, tiempoBala);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            ph.DealDamage(daño);
        }

    }
}

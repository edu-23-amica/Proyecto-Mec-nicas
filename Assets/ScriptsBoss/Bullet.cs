using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float tiempoBala = 3f;
    public int damage = 2;
    void Start()
    {
        Destroy(gameObject, tiempoBala);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth ph))
        {
            Destroy(gameObject);
            ph.DealDamage(damage);
        }
    }
}

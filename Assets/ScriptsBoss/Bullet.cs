using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float tiempoBala = 3f;
    public int da�o = 2;
    //public PlayerHealth ph;
    void Start()
    {
        Destroy(gameObject, tiempoBala);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            //Esta es la funcion para hacer da�o al player pero como no tengo el script la tengo comentada
            //ph.DealDamage(da�o);
        }

    }
}

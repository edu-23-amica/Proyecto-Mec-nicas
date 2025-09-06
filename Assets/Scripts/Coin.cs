using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject pooler;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MainPlayer>() != null && pooler.GetComponent<FireBallPooling>().attackIndex < 10)
        {
            gameObject.SetActive(false);
            pooler.GetComponent<FireBallPooling>().FillObjects();
        }
    }
}

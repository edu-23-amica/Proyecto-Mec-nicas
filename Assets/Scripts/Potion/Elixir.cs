using UnityEngine;

public class Elixir : MonoBehaviour
{
    public GameObject playerHealth;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.GetComponent<MainPlayer>() != null && playerHealth.GetComponent<PlayerHealth>().Health < playerHealth.GetComponent<PlayerHealth>().MaxHealth)
        {
            playerHealth.GetComponent<PlayerHealth>().Recover();
            gameObject.SetActive(false);
            Debug.Log("ENTRE");

        }
    }
}

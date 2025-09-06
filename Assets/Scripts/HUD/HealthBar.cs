using UnityEngine;
using UnityEngine.UI;
using static PlayerHealth;

public class HealthBar : MonoBehaviour
{

    public Image healthBar;
    private PlayerHealth player;

    private void Start()
    {
        player = FindFirstObjectByType<PlayerHealth>();
        if(player != null)
        {
           
            player.onHurt += UpdateHealthBar;
            player.onRecover += UpdateHealthBar;
            UpdateHealthBar();
        }
        
    }
    public void UpdateHealthBar()
    {
        float health = (float)player.Health / player.MaxHealth;
        healthBar.fillAmount = health;
    }


}

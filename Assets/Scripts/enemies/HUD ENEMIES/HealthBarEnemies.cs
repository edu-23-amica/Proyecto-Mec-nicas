using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemies : MonoBehaviour
{
    public Image healthBar;
    private EnemyHealth enemy;

    private void Start()
    {
        enemy = FindFirstObjectByType<EnemyHealth>();
        if (enemy != null)
        {

            enemy.onHurt += UpdateHealthBar;
  
            UpdateHealthBar();
        }

    }
    public void UpdateHealthBar()
    {
        float health = (float)enemy.Health / enemy.MaxHealth;
        healthBar.fillAmount = health;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(EnemyHealth))]
public class EndGameOnDeath : MonoBehaviour
{
    EnemyHealth health;
    void Start()
    {
        health = GetComponent<EnemyHealth>();
        health.onDeath += OnDeath;
    }

    void OnDeath()
    {
        SceneLoader.LoadWinState();
    }
}

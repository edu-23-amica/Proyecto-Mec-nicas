using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public static void LoadLoseState()
    {
        SceneManager.LoadScene(2);
    }

    public static void LoadWinState()
    {
        SceneManager.LoadScene(3);
    }

    // Nuevo: detectar colisión con el BossTrigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainPlayer"))
        {
            SceneManager.LoadScene(4);
            // o por nombre:
            // SceneManager.LoadScene(sceneNameToLoad);
        }
    }


}

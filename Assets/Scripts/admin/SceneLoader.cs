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
        // TODO: No hay win state todavia
        // SceneManager.LoadScene(2);
    }
}

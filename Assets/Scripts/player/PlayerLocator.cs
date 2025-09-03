using UnityEngine;

public class PlayerLocator : MonoBehaviour
{
    private static GameObject player;
    public static GameObject Player { get => player; }

    void Awake()
    {
        player = gameObject;
    }
}

using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public MainPlayer player;
    public FireBallPooling generatorObstacle;  
    public Transform playerTransform;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.animator.Play("Attack");
            generatorObstacle.GetObject(playerTransform);
        }
    }
}
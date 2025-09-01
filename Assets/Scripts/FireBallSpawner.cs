using UnityEngine;

public class FireBallSpawner : MonoBehaviour
{
    public FireBallPooling generatorObstacle;
    public Transform firePoint;
    void Update()
    {
 
    }
    public void SpawnFireball(float direction)
    {
        generatorObstacle.GetObject(firePoint, direction);
    }
}
using UnityEngine;

public class MovingP : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float mSpeed;
    private Vector3 nextP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextP = pointA.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextP, mSpeed * Time.deltaTime);
        if (transform.position == nextP)
        {
            nextP = (nextP == pointB.position) ? pointA.position : pointB.position;
        }
    }
}

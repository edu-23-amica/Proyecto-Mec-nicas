using UnityEngine;

public class FireMainPlayer : MonoBehaviour
{
    public float speed = 10f;
    
    public MainPlayer player_facing;
    public int dir = 1;

    private void Awake()
    {
        player_facing = GetComponent<MainPlayer>();
    }
    public void OnBecameInvisible()
    {
        Debug.Log("YA NO ME VEN LAS CÁMARAS");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        
        float facing = player_facing.moveInput;
        if (facing < 0)
        {
            dir = -1;
            Debug.Log("Entre 1");
        }
        if(facing > 0)
        {
            Debug.Log("Entre 2");
            dir = 1;
        }
        transform.position += new Vector3(dir * speed * Time.deltaTime, 0, 0);
        
        
        //transform.position += Vector3.left * Time.deltaTime * speed;
        
    }
}

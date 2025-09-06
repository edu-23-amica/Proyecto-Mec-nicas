using System.Collections.Generic;
using UnityEngine;
public class FireBallPooling : MonoBehaviour
{
    public int objectCount = 10;
    public GameObject prefabObject;
    public List<GameObject> createdObjects;
    public int attackIndex = 0;
    public FireCharges fireUI;

    private void Awake()
    {
        FillObjects();
    }

    public void FillObjects()
    {
        for (int i = 0; i < objectCount; i++)
        {
            if(attackIndex < 10)
            {
                GameObject instancedObject = Instantiate(prefabObject);
                instancedObject.SetActive(false);
                createdObjects.Add(instancedObject);
                attackIndex++;
                
            }
            
        }
    }

    public void GetObject(Transform point, float direction) 
    {
        for (int i = 0; i < createdObjects.Count; i++)
        {
            if (!createdObjects[i].activeInHierarchy)
            {

                createdObjects[i].transform.position = point.position;
                createdObjects[i].transform.rotation = point.rotation;
                createdObjects[i].SetActive(true);
                createdObjects[i].GetComponent<FireMainPlayer>().SetDirection(direction); 
                attackIndex--;
                
                return;
            }
        }
    }

    private void Update()
    {
        fireUI.UpdateScore(attackIndex);
    }

}

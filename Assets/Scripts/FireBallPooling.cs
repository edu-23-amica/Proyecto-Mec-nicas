using System.Collections.Generic;
using UnityEngine;
public class FireBallPooling : MonoBehaviour
{
    public int objectCount = 10;
    public GameObject prefabObject;
    public List<GameObject> createdObjects;

    private void Awake()
    {
        FillObjects();
    }

    public void FillObjects()
    {
        for (int i = 0; i < objectCount; i++)
        {
            GameObject instancedObject = Instantiate(prefabObject);
            instancedObject.SetActive(false);
            createdObjects.Add(instancedObject);
        }
    }

    public void GetObject(Transform point)
    {
        for (int i = 0; i < createdObjects.Count; i++)
        {
            if (!createdObjects[i].activeInHierarchy)
            {

                createdObjects[i].transform.position = point.position;
                createdObjects[i].transform.rotation = point.rotation;
                createdObjects[i].SetActive(true);
                return;
            }
        }
    }

}

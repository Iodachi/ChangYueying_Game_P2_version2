using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {
    public GameObject pooledObject;
    public int amount;
    List<GameObject> objects;

	// Use this for initialization
	void Start () {
        objects = new List<GameObject>();
        for(int i = 0; i < amount; i++)
        {
            GameObject obj = (GameObject) Instantiate(pooledObject);
            obj.SetActive(false);
            objects.Add(obj);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject getPooledObject()
    {
        for(int i = 0; i < objects.Count; i++)
        {
            if (!objects[i].activeInHierarchy)
            {
                return objects[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        objects.Add(obj);
        return obj;
    }
}

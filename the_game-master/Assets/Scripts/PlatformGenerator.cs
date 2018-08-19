using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {
    public Transform generationPoint;
    public Transform left;
    public Transform right;

    public float distanceMin;
    public float distanceMax;
    private float[] platformWidths;
    
    public ObjectPooler[] objectPools;

    private int platformSelector;

    // Use this for initialization
    void Start(){
        platformWidths = new float[objectPools.Length];

        for(int i = 0; i < objectPools.Length; i++)
        {
            platformWidths[i] = objectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.y;
        }
    }

	// Update is called once per frame
	void Update () {
		if(transform.position.y < generationPoint.position.y)
        {
            Debug.Log("hui");
            float distance = Random.Range(distanceMin, distanceMax);
            float offset = Random.Range(-10.0f, 10.0f);
            float xPos = transform.position.x + offset;
            if (xPos > right.position.x || xPos < left.position.x)
                xPos = transform.position.x;
            platformSelector = Random.Range(0, objectPools.Length);

            transform.position = new Vector3(xPos, transform.position.y + platformWidths[platformSelector]+ distance, transform.position.z);
            //Instantiate(platform, transform.position, transform.rotation);
            GameObject newPlaform = objectPools[platformSelector].getPooledObject();
            newPlaform.transform.position = transform.position;
            newPlaform.transform.rotation = transform.rotation;
            newPlaform.SetActive(true);


        }
	}
}

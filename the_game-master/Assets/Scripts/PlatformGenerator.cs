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

    public float spike;
    public ObjectPooler spikePool;

    public float launchpad;
    public ObjectPooler launchpadPool;

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
        if (transform.position.y < generationPoint.position.y)
        {
            float distance = Random.Range(distanceMin, distanceMax);
            float offset = Random.Range(-10.0f, 10.0f);
            float xPos = transform.position.x + offset;
            if (xPos > right.position.x || xPos < left.position.x)
                xPos = transform.position.x;
            platformSelector = Random.Range(0, objectPools.Length);

            transform.position = new Vector3(xPos, transform.position.y + platformWidths[platformSelector] + distance, transform.position.z);
            //Instantiate(platform, transform.position, transform.rotation);
            GameObject newPlaform = objectPools[platformSelector].getPooledObject();
            newPlaform.transform.position = transform.position;
            newPlaform.transform.rotation = transform.rotation;
            newPlaform.SetActive(true);

            if (Random.Range(0f, 10f) < spike)
            {
                GameObject newSpike = spikePool.getPooledObject();
                float spikeOffset = Random.Range(-1f, 1f);
                float newSpikeX = transform.position.x + spikeOffset;
                float newSpikeY = transform.position.y + 0.5f;
                newSpike.transform.position = new Vector3(newSpikeX, newSpikeY, transform.position.z);
                newSpike.transform.rotation = transform.rotation;
                newSpike.SetActive(true);
            }

            if (Random.Range(0f, 10f) < launchpad)
            {
                GameObject newLaunchpad = launchpadPool.getPooledObject();
                float launchpadOffset = Random.Range(-1f, 1f);
                float newLaunchpadX = transform.position.x + launchpadOffset;
                float newLaunchpadY = transform.position.y + 0.7f;
                newLaunchpad.transform.position = new Vector3(newLaunchpadX, newLaunchpadY, transform.position.z);
                newLaunchpad.transform.rotation = transform.rotation;
                newLaunchpad.SetActive(true);
            }
        }
	}
}

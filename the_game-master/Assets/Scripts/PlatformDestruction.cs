using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestruction : MonoBehaviour {
    public GameObject platformDestructionPoint;

	// Use this for initialization
	void Start () {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");

    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < platformDestructionPoint.transform.position.y)
        {
            gameObject.SetActive(false);
        }
	}
}

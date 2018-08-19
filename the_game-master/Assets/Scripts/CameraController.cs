using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject player;
    public float speed = 0.05f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
    }
}

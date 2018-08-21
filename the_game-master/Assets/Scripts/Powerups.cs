using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {
    public bool invincible;
    public bool cameraSpeedDown;
    public bool superJump;

    public float length;
    private PowerupManager powerupManager;

	// Use this for initialization
	void Start () {
        powerupManager = FindObjectOfType<PowerupManager>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            powerupManager.ActivatePowerup(invincible, cameraSpeedDown, superJump, length);
        }
        gameObject.SetActive(false);
    }
}

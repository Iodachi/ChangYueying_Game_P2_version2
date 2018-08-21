using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour {
    private bool invincible;
    private bool cameraSpeedDown;
    private bool superJump;

    private bool active;

    private float length;

    public CameraController cam;
    public Movement player;

	// Use this for initialization
	void Start () {
        cam = FindObjectOfType<CameraController>();
        player = FindObjectOfType<Movement>();
	}
	
	// Update is called once per frame
	void Update () {
        if(active){
            length -= Time.deltaTime;

            if (invincible)
            {
                player.safe = true;
            }
            else if (cameraSpeedDown)
            {
                cam.speed = 0.02f;
            }
            else if(superJump){
                player.jumpSpeed = 25;
            }
        }

        if(length <= 0){
            active = false;
            cam.speed = 0.05f;
            player.jumpSpeed = 15;
            player.safe = false;
        }
	}

    public void ActivatePowerup(bool invin, bool camera, bool jump, float leng){
        invincible = invin;
        cameraSpeedDown = camera;
        superJump = jump;
        length = leng;

        active = true;
    }
}

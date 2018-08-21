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

	// Use this for initialization
	void Start () {
        cam = FindObjectOfType<CameraController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(active){
            length -= Time.deltaTime;

            if (invincible)
            {

            }
            else if (cameraSpeedDown)
            {
                cam.speed = 0.02f;
            }
            else if(superJump){
                
            }
        }

        if(length <= 0){
            active = false;
            cam.speed = 0.05f;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public Transform player;
    private Vector3 playerStartPoint;

    public Transform mainCam;
    private Vector3 cameraStartPoint;

    private PlatformDestruction[] platforms;


	// Use this for initialization
	void Start () {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;
        cameraStartPoint = mainCam.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void restart(){
        StartCoroutine("RestartGame");
    }

    public IEnumerator RestartGame(){
        player.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        platforms = FindObjectsOfType<PlatformDestruction>();
        for (int i = 0; i < platforms.Length; i++){
            platforms[i].gameObject.SetActive(false);
        }

        player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        mainCam.transform.position = cameraStartPoint;

        player.gameObject.SetActive(true);
    }
}

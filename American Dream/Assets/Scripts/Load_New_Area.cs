using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_New_Area : MonoBehaviour {

    public string levelToLoad;

    public Player_Controller thePlayer;
    public Camera_Controller theCamera;

    public Vector2 startDirection;

    public float xPos;
    public float yPos;
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(levelToLoad);

            thePlayer = FindObjectOfType<Player_Controller>();
            theCamera = FindObjectOfType<Camera_Controller>();

            thePlayer.transform.position = new Vector3(xPos, yPos, 0f);

            theCamera.transform.position = new Vector3(xPos, yPos, theCamera.transform.position.z);

            thePlayer.lastMove = startDirection;
        }
    }
}

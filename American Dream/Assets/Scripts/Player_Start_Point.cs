using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Start_Point : MonoBehaviour {

    public Player_Controller thePlayer;
    public Camera_Controller theCamera;

    public Vector2 startDirection;

	// Use this for initialization
	void Startz () {
        thePlayer = FindObjectOfType<Player_Controller>();
        theCamera = FindObjectOfType<Camera_Controller>();

        thePlayer.transform.position = transform.position;

        theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);

        thePlayer.lastMove = startDirection;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

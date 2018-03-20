using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour {

    private static bool cameraExists;

    public GameObject target;
    private Vector3 targetPos;
    public float moveSpeed;

	// Use this for initialization
	void Start () {
        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void FixedUpdate()
    {
        targetPos = new Vector3(target.transform.position.x, target.transform.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed);
    }
}

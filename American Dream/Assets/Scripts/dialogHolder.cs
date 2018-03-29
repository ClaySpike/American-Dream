using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogHolder : MonoBehaviour {

    private Dialouge_Manager dMAn;

    public string[] dialogueLines;

	// Use this for initialization
	void Start () {
        dMAn = FindObjectOfType<Dialouge_Manager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (!dMAn.dialogueActive)
                {
                    dMAn.dialogLines = dialogueLines;
                    dMAn.currentLine = 0;
                    dMAn.showDialogue();
                }
                if(transform.parent.GetComponent<NPC_Controller>() != null)
                {
                    transform.parent.GetComponent<NPC_Controller>().canMove = false;
                }
            }
        }
    }
}

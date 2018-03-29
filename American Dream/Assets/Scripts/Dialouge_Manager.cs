using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialouge_Manager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;

    public bool dialogueActive;

    public string[] dialogLines;
    public int currentLine;

    private Player_Controller thePlayer;

    private bool keyIsDown;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<Player_Controller>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (dialogueActive && Input.GetKey(KeyCode.Space))
        {
            keyIsDown = true;
        }
        if(dialogueActive && keyIsDown && Input.GetKeyUp(KeyCode.Space))
        {
            currentLine++;
            keyIsDown = false;
        }
        if (currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogueActive = false;
            currentLine = 0;
            thePlayer.canMove = true;
            keyIsDown = false;
        }
        dText.text = dialogLines[currentLine];
	}

    public void ShowBox(string dialogue)
    {
        dialogueActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void showDialogue()
    {
        dialogueActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;
    }
 }

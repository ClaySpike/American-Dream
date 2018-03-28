﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialouge_Manager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;

    public bool dialogueActive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (dialogueActive && Input.GetAxis("a") > 0f)
        {
            dBox.SetActive(false);
            dialogueActive = false;
        }
	}

    public void ShowBox(string dialogue)
    {
        dialogueActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }
 }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscToMenu : MonoBehaviour {

    public GameObject escMenu;
    public RigidbodyFirstPersonController controller;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("Start button")) {
            if(escMenu.active == true) {
                escMenu.SetActive(false);
                FindObjectOfType<RigidbodyFirstPersonController>().enabled = true;
            } else {
                escMenu.SetActive(true);
                FindObjectOfType<RigidbodyFirstPersonController>().enabled = false;
            }
        }
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour {

    Text interactText;
    RaycastHit hit;
    GameObject player;
    public string interactAction;

	// Use this for initialization
	void Start () {
        interactText = GameObject.Find("InteractText").GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(player.transform.position, player.transform.TransformDirection(Vector3.forward), out hit, 3f)) {
            if (hit.collider.GetComponent<EnvironmentalAction>()) {


                if (hit.transform.tag == "Interactable" && hit.collider.GetComponentInChildren<Menu_Button_Pulse>().inRange == true) {
                    if (interactText.enabled == false) {
                        ShowInteractButton(hit.transform.gameObject);
                    }

                    if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown("joystick button 0")) {
                        ReplaceSubtitles.instance.currentStory = hit.collider.GetComponent<CharacterStorySettings>();
                        ReplaceSubtitles.instance.start = true;
                    }

                } else {
                    HideInteractButton();
                }
            }
        } else {
            HideInteractButton();
        }
	}

    void ShowInteractButton(GameObject currentObject) {
        interactText.text = "Press X to " + currentObject.GetComponent<EnvironmentalAction>().interactableAction;
        interactText.enabled = true;
    }

    void HideInteractButton() {
        interactText.enabled = false;
        interactText.text = "";

    }
}

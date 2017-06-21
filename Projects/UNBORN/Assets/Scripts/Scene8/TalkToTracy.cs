using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkToTracy : MonoBehaviour {

    public GameObject Player;
    RaycastHit hit;
    Text interactText;
    GameObject camera;


    // Use this for initialization
    void Start() {
        Player = GameObject.Find("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        interactText = GameObject.Find("InteractText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit, 3f)) {
            if (hit.collider.GetComponent<TalkToTracy>()) {
                if (hit.transform.tag == "Tracy" && hit.collider.GetComponentInChildren<Menu_Button_Pulse>().inRange == true) {
                    if (interactText.enabled == false) {
                        interactText.text = "Press X to talk to Tracy";
                        interactText.enabled = true;
                    }

                    if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown("joystick button 0")) {
                        ReplaceSubtitles.instance.currentStory = GetComponent<CharacterStorySettings>();
                        ReplaceSubtitles.instance.start = true;
                        Destroy(this);
                    }
                } else {
                    if (interactText == true) {
                        HideInteractButton();
                    }
                }
            }
        } else {
            if (interactText == true) {
                HideInteractButton();
            }
        }
    }

    void HideInteractButton() {
        interactText.enabled = false;
        interactText.text = "";

    }
}

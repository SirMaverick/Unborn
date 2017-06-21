using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractWithDrawing : MonoBehaviour {

    TalkToSam sam;
    public bool bear, giraffe, elephant, shark = false;
    CharacterStorySettings animalStory;


    public GameObject Player;
    RaycastHit hit;
    Text interactText;
    GameObject camera;


    // Update is called once per frame
    private void Start() {
        sam = GameObject.FindGameObjectWithTag("Sam").GetComponent<TalkToSam>();
        Player = GameObject.Find("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        interactText = GameObject.Find("InteractText").GetComponent<Text>();
    }

    void Update () {
        if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit, 3f)) {
            if (hit.transform.tag == "Drawing" && hit.collider.GetComponentInChildren<Menu_Button_Pulse>().inRange == true) {
                Debug.Log(hit.transform.name);
                Debug.Log(hit.transform.parent);
                if (interactText.enabled == false) {
                    interactText.text = "Press X to look at drawing";
                    interactText.enabled = true;
                }

                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown("joystick button 0")) {
                    if (hit.transform.name == "Bear") {
                        sam.bearDone = true;
                    } else if (hit.transform.name == "Giraffe") {
                        sam.giraffeDone = true;
                    } else if (hit.transform.name == "Elephant") {
                        sam.elephantDone = true;
                    } else if (hit.transform.name == "Shark") {
                        sam.sharkDone = true;

                    }

                    ReplaceSubtitles.instance.currentStory = hit.transform.GetComponent<CharacterStorySettings>();
                    ReplaceSubtitles.instance.start = true;
                }

            } else {
                if (interactText == true) {
                    HideInteractButton();
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

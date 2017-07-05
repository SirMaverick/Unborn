using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpDrawing : MonoBehaviour {


    Text interactText;
    RaycastHit hit;
    GameObject player;
    Transform wieldingObject;
    Transform oldParent;
    Vector3 oldPosition;
    Quaternion oldRotation;
    public string interactAction;
    public GameObject closeUp;
    bool focused;

    // Use this for initialization
    void Start() {
        interactText = GameObject.Find("InteractText").GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update() {

        if (focused == true) {
            Debug.Log(focused);
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown("joystick button 0")) {
                Debug.Log("hello");
                wieldingObject.parent = oldParent;
                Debug.Log("Current parent = " + wieldingObject.parent);
                wieldingObject.position = oldPosition;
                wieldingObject.rotation = oldRotation;

                Menu_Button_Pulse[] interactionIcons = hit.transform.GetComponentsInChildren<Menu_Button_Pulse>();
                foreach (Menu_Button_Pulse item in interactionIcons) {
                    item.gameObject.SetActive(false);
                }
                focused = false;
            }
        } else if (Physics.Raycast(player.transform.position, player.transform.TransformDirection(Vector3.forward), out hit, 3f)) {
            if (hit.collider.GetComponent<EnvironmentalAction>()) {

                if (hit.transform.tag == "Pickup") {

                    if (interactText.enabled == false) {

                        ShowInteractButton(hit.transform.gameObject);
                    }

                    if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown("joystick button 0")) {
                        Debug.Log("Pressed Z");
                        if (focused == false) {
                            player.GetComponent<CRTEffect>().colorIntensity = 0;
                            ReplaceSubtitles.instance.currentStory = hit.transform.GetComponent<CharacterStorySettings>();
                            ReplaceSubtitles.instance.start = true;
                            wieldingObject = hit.transform;
                            oldPosition = hit.transform.position;
                            oldRotation = hit.transform.rotation;
                            oldParent = hit.transform.parent;
                            hit.transform.position = closeUp.transform.position;
                            hit.transform.rotation = closeUp.transform.rotation;
                            hit.transform.parent = closeUp.transform;
                            Menu_Button_Pulse[] interactionIcons = hit.transform.GetComponentsInChildren<Menu_Button_Pulse>();
                            foreach (Menu_Button_Pulse item in interactionIcons) {
                                item.gameObject.SetActive(false);
                            }
                            focused = true;
                        }


                    }

                } else if (hit.transform.tag == "Interactable") {
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

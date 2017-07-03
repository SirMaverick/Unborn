using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkToSam : MonoBehaviour {

    public GameObject Player;
    RaycastHit hit;
    Text interactText;
    GameObject camera;
    public GameObject endSwitch;

    bool quest;
    bool done;
    bool spoken;

    public bool bearDone, elephantDone, giraffeDone, sharkDone;

    BoxCollider elephant, giraffe, shark, bear;
    

    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        interactText = GameObject.Find("InteractText").GetComponent<Text>();
        elephant = GameObject.Find("Elephant").GetComponent<BoxCollider>();
        giraffe = GameObject.Find("Giraffe").GetComponent<BoxCollider>();
        shark = GameObject.Find("Shark").GetComponent<BoxCollider>();
        bear = GameObject.Find("Bear").GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update() {
        if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit, 3f)) {
            if (hit.collider.GetComponent<TalkToSam>()) {
                if ((hit.transform.tag == "Drawing" || hit.transform.tag == "Interactable" || hit.transform.tag == "Door" || hit.transform.tag == "Sam") && hit.collider.GetComponentInChildren<Menu_Button_Pulse>().inRange == true) {
                    if (interactText.enabled == false) {
                        if (hit.transform.tag == "Sam") {
                            if (spoken == false) {
                                interactText.text = "Press X to say Hi";
                                interactText.enabled = true;
                            } else {
                                interactText.text = "Press X to talk to Sam";
                                interactText.enabled = true;
                            }
                            
                        } else {
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown("joystick button 0")) {
                        if (quest == false) {

                            if (done == false) {
                                spoken = true;
                                ReplaceSubtitles.instance.currentStory = hit.collider.GetComponent<CharacterStorySettings>();
                                ReplaceSubtitles.instance.start = true;
                                Destroy(hit.collider.GetComponent<CharacterStorySettings>());
                                ActivateQuest();
                            } else {
                                ReplaceSubtitles.instance.currentStory = hit.collider.GetComponent<CharacterStorySettings>();
                                ReplaceSubtitles.instance.start = true;
                                Destroy(hit.collider.GetComponent<CharacterStorySettings>());
                               
                            }

                        } else {
                            if (bearDone && giraffeDone && sharkDone && elephantDone) {
                                QuestCompleted();
                            } else {
                                CharacterStorySettings[] storyList = hit.collider.GetComponents<CharacterStorySettings>();
                                for (int i = 0; i < storyList.Length; i++) {
                                    if (storyList[i].dialogueName == "Quest not completed") {
                                        ReplaceSubtitles.instance.currentStory = storyList[i];
                                        ReplaceSubtitles.instance.start = true;
                                    }
                                }
                            }
                            
                        }
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

    void ActivateQuest() {
        quest = true;
        bear.enabled = true;
        giraffe.enabled = true;
        shark.enabled = true;
        elephant.enabled = true;
    }

    void QuestCompleted() {
        quest = false;
        done = true;
        bear.enabled = false;
        giraffe.enabled = false;
        shark.enabled = false;
        elephant.enabled = false;
        endSwitch.SetActive(true);
        
    }
}

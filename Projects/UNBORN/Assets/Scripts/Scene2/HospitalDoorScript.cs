using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HospitalDoorScript : MonoBehaviour {

    bool chat1, chat2, chat3;

    public static int amountOfDoorsOpened;

    public GameObject Player;
    Text interactText;
    GameObject camera;
    public GameObject hospitalRoom;
    RaycastHit hit;
    GameObject storyContainer;
    public GameObject baby;


    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        storyContainer = GameObject.Find("StoryContainer");
        interactText = GameObject.Find("InteractText").GetComponent<Text>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {

        if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit, 3f)) {
            if (hit.transform.tag == "Door" && hit.collider.GetComponentInChildren<Menu_Button_Pulse>().inRange == true) {
                if (interactText.enabled == false) {
                    interactText.text = "Press X to open the door";
                    interactText.enabled = true;
                }

                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown("joystick button 0") && hit.transform.GetComponent<HospitalDoorContainer>().DoorMoving == false) {
                    if (hit.transform.GetComponent<HospitalDoorContainer>().DoorOpen == false) {
                        StartCoroutine(OpenDoor(hit.transform.GetComponent<HospitalDoorContainer>()));

                    } else {
                        StartCoroutine(CloseDoor(hit.transform.GetComponent<HospitalDoorContainer>()));
                    }
                }

            } else {
                HideInteractButton();
            }
        } else {
            HideInteractButton();
        }

        if (amountOfDoorsOpened == 1 && chat1 == false) {
            ReplaceSubtitles.instance.currentStory = storyContainer.GetComponent<CharacterStorySettings>();
            ReplaceSubtitles.instance.start = true;
            chat1 = true;
            Destroy(storyContainer.GetComponent<CharacterStorySettings>());
        } else if (amountOfDoorsOpened == 2 && chat2 == false) {
            ReplaceSubtitles.instance.currentStory = storyContainer.GetComponent<CharacterStorySettings>();
            ReplaceSubtitles.instance.start = true;
            chat2 = true;
            Destroy(storyContainer.GetComponent<CharacterStorySettings>());
        } else if (amountOfDoorsOpened == 3 && chat3 == false) {
            ReplaceSubtitles.instance.currentStory = storyContainer.GetComponent<CharacterStorySettings>();
            ReplaceSubtitles.instance.start = true;
            chat3 = true;
            Destroy(storyContainer.GetComponent<CharacterStorySettings>());
            baby.tag = "Interactable";
            baby.transform.GetChild(0).gameObject.SetActive(true);
            baby.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    void SetHospitalRoom(HospitalDoorContainer go) {
        hospitalRoom.transform.rotation = go.newHospitalPos.rotation;
        hospitalRoom.transform.position = go.newHospitalPos.position;
    }

    void HideInteractButton() {
        interactText.enabled = false;
        interactText.text = "";

    }

    IEnumerator OpenDoor(HospitalDoorContainer go)
    {
        go.DoorMoving = true;
        SetHospitalRoom(go);
        yield return new WaitForSeconds(0.5f);
        go.GetComponent<Animation>().Play("HospitalDoorOpen");
        
        go.DoorOpen = true;
        go.DoorMoving = false;
        yield return new WaitForSeconds(1.5f);
        amountOfDoorsOpened++;
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(CloseDoor(go));
    }

    IEnumerator CloseDoor(HospitalDoorContainer go)
    {
        go.DoorMoving = true;
        yield return new WaitForSeconds(1.5f);
        go.GetComponent<Animation>().Play("HospitalDoorClose");
        go.DoorOpen = false;
        go.DoorMoving = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HospitalDoorScript : MonoBehaviour {

    public bool DoorMoving;
    public bool DoorOpen;
    bool chat1, chat2, chat3;

    public static int amountOfDoorsOpened;

    public GameObject Player;
    Text interactText;
    GameObject camera;
    public GameObject hospitalRoom;
    public Transform newHospitalPos;
    public Animation Anim;
    RaycastHit hit;
    GameObject storyContainer;


    // Use this for initialization
    void Start()
    {
        Anim = gameObject.GetComponent<Animation>();
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

                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown("joystick button 0") && DoorMoving == false && Vector3.Distance(Player.transform.position, gameObject.transform.position) < 1.8f) {
                    if (DoorOpen == false) {
                        StartCoroutine(OpenDoor());

                    } else {
                        StartCoroutine(CloseDoor());
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
        }
    }

    void SetHospitalRoom() {
        hospitalRoom.transform.rotation = newHospitalPos.rotation;
        hospitalRoom.transform.position = newHospitalPos.position;
    }

    void HideInteractButton() {
        interactText.enabled = false;
        interactText.text = "";

    }

    IEnumerator OpenDoor()
    {
        DoorMoving = true;
        SetHospitalRoom();
        yield return new WaitForSeconds(0.5f);
        GetComponent<Animation>().Play("HospitalDoorOpen");
        
        DoorOpen = true;
        DoorMoving = false;
        yield return new WaitForSeconds(1.5f);
        amountOfDoorsOpened++;
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(CloseDoor());
    }

    IEnumerator CloseDoor()
    {
        DoorMoving = true;
        yield return new WaitForSeconds(1.5f);
        GetComponent<Animation>().Play("HospitalDoorClose");
        DoorOpen = false;
        DoorMoving = false;
    }
}

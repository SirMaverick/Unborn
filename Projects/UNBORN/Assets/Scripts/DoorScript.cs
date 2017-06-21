using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class DoorScript : MonoBehaviour {

    public bool DoorMoving;
    public bool DoorOpen;

    public GameObject Player;
    RaycastHit hit;
    Text interactText;
    GameObject camera;

    public GameObject DoorPlate;
    public Animation Anim;

	// Use this for initialization
	void Start () {
        Anim = gameObject.GetComponent<Animation>();
        Player = GameObject.Find("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        interactText = GameObject.Find("InteractText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit, 3f)) {
            if (hit.transform.tag == "Door" && hit.collider.GetComponentInChildren<Menu_Button_Pulse>().inRange == true) {
                if (interactText.enabled == false) {
                    interactText.text = "Press X to open the door";
                    interactText.enabled = true;
                }

                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown("joystick button 0") && DoorMoving == false) {
                    if (DoorOpen == false) {
                        StartCoroutine(OpenDoor());
                        RuntimeManager.PlayOneShot("event:/Room 02/SFX/Door_open", transform.position + new Vector3(0, 0, 0.85f));

                    } else {
                        StartCoroutine(CloseDoor());
                        RuntimeManager.PlayOneShot("event:/Room 02/SFX/Door_open", transform.position + new Vector3(0, 0, 0.85f));
                    }
                }

            } else {
                HideInteractButton();
            }
        } else {
            HideInteractButton();
        }
    }

    void HideInteractButton() {
        interactText.enabled = false;
        interactText.text = "";

    }

    IEnumerator OpenDoor() {
        DoorMoving = true;
        GetComponent<Animation>().Play("DoorConsole");
        yield return new WaitForSeconds(0.4f);
        DoorPlate.GetComponent<Animation>().Play("DoorPlate");
        yield return new WaitForSeconds(1.0f);
        DoorOpen = true;
        DoorMoving = false;
    }

    IEnumerator CloseDoor() {
        DoorMoving = true;
        DoorPlate.GetComponent<Animation>().Play("DoorPlateclose");
        yield return new WaitForSeconds(0.7f);
        GetComponent<Animation>().Play("DoorConsoleClose");
        yield return new WaitForSeconds(1.0f);
        DoorOpen = false;
        DoorMoving = false;
    }
}

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
            if ( hit.transform.tag == "Door"  && hit.collider.GetComponentInChildren<Menu_Button_Pulse>().inRange == true) {
                DoorContainer container = hit.transform.GetComponent<DoorContainer>();
                if (interactText.enabled == false)  {
                    if(hit.transform.tag == "Door") {
                        interactText.text = "Press X to open the door";
                        interactText.enabled = true;
                    }
                   
                } 

                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown("joystick button 0") && container.DoorMoving == false) {
                    if (container.DoorOpen == false) {
                        StartCoroutine(OpenDoor(container));
                        RuntimeManager.PlayOneShot("event:/Room 02/SFX/Door_open", transform.position + new Vector3(0, 0, 0.85f));

                    } else {
                        StartCoroutine(CloseDoor(container));
                        RuntimeManager.PlayOneShot("event:/Room 02/SFX/Door_open", transform.position + new Vector3(0, 0, 0.85f));
                    }
                }

            } else if ((hit.transform.tag == "Drawing" || hit.transform.tag == "Interactable" || hit.transform.tag == "Sam")) {

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

    IEnumerator OpenDoor(DoorContainer container) {
        container.DoorMoving = true;
        container.GetComponent<Animation>().Play("DoorConsole");
        yield return new WaitForSeconds(0.4f);
        container.DoorPlate.GetComponent<Animation>().Play("DoorPlate");
        yield return new WaitForSeconds(1.0f);
        container.DoorOpen = true;
        container.DoorMoving = false;
    }

    IEnumerator CloseDoor(DoorContainer container) {
        container.DoorMoving = true;
        container.DoorPlate.GetComponent<Animation>().Play("DoorPlateclose");
        yield return new WaitForSeconds(0.7f);
        container.GetComponent<Animation>().Play("DoorConsoleClose");
        yield return new WaitForSeconds(1.0f);
        container.DoorOpen = false;
        container.DoorMoving = false;
    }
}

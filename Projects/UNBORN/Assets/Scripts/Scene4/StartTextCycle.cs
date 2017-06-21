using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTextCycle : MonoBehaviour {

    GameObject player;
    GameObject playerCamera;
    RaycastHit hit;
    Text interactText;
    float speed = 2;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        interactText = GameObject.Find("InteractText").GetComponent<Text>();
        ReplaceSubtitles.instance.currentStory = GetComponent<CharacterStorySettings>();
        ReplaceSubtitles.instance.start = true;
        Destroy(GetComponent<CharacterStorySettings>());
        StopMovement.MovementOff(60, -60);
	}
	
	// Update is called once per frame
	void Update () {
        if(ReplaceSubtitles.instance.play == false) {
            StopMovement.MovementOn();
        }
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward), out hit, 3f)) {
            if (hit.transform.tag == "Bicycle" && hit.collider.GetComponentInChildren<Menu_Button_Pulse>().inRange == true) {
                if (interactText.enabled == false) {
                    ShowInteractButton(hit.transform.gameObject);
                }
                

                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown("joystick button 0")) {
                    
                    StartCoroutine(PushBicycle());
                    ReplaceSubtitles.instance.currentStory = hit.collider.GetComponent<CharacterStorySettings>();
                    ReplaceSubtitles.instance.start = true;
                    Destroy(hit.collider.GetComponent<CharacterStorySettings>());
                }

            } else {
                HideInteractButton();
            }
        } else {
            HideInteractButton();
        }
    }

    void ShowInteractButton(GameObject currentObject) {
        interactText.text = "Press X to push Sam" ;
        interactText.enabled = true;
    }

    void HideInteractButton() {
        interactText.enabled = false;
        interactText.text = "";

    }

    IEnumerator PushBicycle() {
        float step = speed * Time.deltaTime;
        Vector3 targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * 8);
        while (transform.position.z != targetPos.z) {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
            yield return new WaitForSeconds(0.02f);
        }
        
    }
}

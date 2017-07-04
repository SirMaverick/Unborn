using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandUpAvaline : MonoBehaviour {

    Text interactText;
    GameObject player;
    bool isVisible;

    // Use this for initialization
    void Start() {
        interactText = GameObject.Find("InteractText").GetComponent<Text>();
        player = GameObject.Find("Player"); 
    }

    void Update() {
        if (ReplaceSubtitles.instance.play == false && isVisible == false) {
            ShowStandUpText();
            isVisible = true;
        }

        if (isVisible && ReplaceSubtitles.instance.play == false && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Z))) {
            StartCoroutine(MoveAvalineOutBed());
            interactText.enabled = false;
        }
    }

    void ShowStandUpText() {
        interactText.text = "Press X to stand up";
        interactText.enabled = true;
    }

    void StandUp() {
        player.transform.position = transform.position;
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<CapsuleCollider>().enabled = true;
    }

    IEnumerator MoveAvalineOutBed() {
        StartCoroutine(FadeIn.FadeToBlack());
        yield return new WaitForSeconds(3.0f);
        StandUp();
        StartCoroutine(FadeOut.FadeToScreen());
        yield return new WaitForSeconds(2.0f);
        StopMovement.MovementOn();
        ReplaceSubtitles.instance.currentStory = GetComponent<CharacterStorySettings>();
        ReplaceSubtitles.instance.start = true;
        Destroy(this);

    }
}

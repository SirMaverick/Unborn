using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpFinalScene : MonoBehaviour {
    public string storyUsed;
    private CharacterStorySettings[] storyList;
    public string secondStory;
    public string waitStory;
    bool done, done2;
    bool done3 = true;
    bool ready;
    public FinalScene_Button_Screens screen;

    // Use this for initialization
    void Start() {
        ReplaceSubtitles.instance.currentChar = gameObject;
        storyList = gameObject.GetComponents<CharacterStorySettings>();
        for (int i = 0; i < storyList.Length; i++) {
            if (storyList[i].dialogueName == storyUsed) {
                ReplaceSubtitles.instance.currentStory = storyList[i];
                ReplaceSubtitles.instance.start = true;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if(ReplaceSubtitles.instance.play) {
            ready = true;
        }
		if(ReplaceSubtitles.instance.play == false && done == false && ready) {
            done = true;
            foreach (FinalScene_Button d in FindObjectsOfType<FinalScene_Button>()) {
                d.startButton = true;
            }
        }
        if(screen.Transparancy > 0.5f && done2 == false && ReplaceSubtitles.instance.play == false) {
            done2 = true;
            for (int i = 0; i < storyList.Length; i++) {
                if (storyList[i].dialogueName == secondStory) {
                    ReplaceSubtitles.instance.currentStory = storyList[i];
                    ReplaceSubtitles.instance.start = true;
                    break;
                }
            }
            done3 = false;
        }

        if (ReplaceSubtitles.instance.play == false && done2 == true && done3 == false) {
            Debug.Log("Hello");
            StartCoroutine(CheckIfAnswered());
        }
	}

    IEnumerator CheckIfAnswered() {
        done3 = true;
        yield return new WaitForSeconds(42.0f);
        if(ReplaceSubtitles.instance.play == false) {
            for(int i = 0; i < storyList.Length; i++) {
                if(storyList[i].dialogueName == waitStory) {
                    ReplaceSubtitles.instance.currentStory = storyList[i];
                    ReplaceSubtitles.instance.start = true;
                }
            }
            
        }
    }
}

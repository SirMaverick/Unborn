using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachScreen : MonoBehaviour {

    public string storyUsed;
    private CharacterStorySettings[] storyList;
    private bool done;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "MainScreen" && done == false && ReplaceSubtitles.instance.play == false) {
            done = true;
            ReplaceSubtitles.instance.currentChar = other.gameObject;
            storyList = other.GetComponents<CharacterStorySettings>();
            for (int i = 0; i < storyList.Length; i++) {
                if (storyList[i].dialogueName == storyUsed) {
                    ReplaceSubtitles.instance.currentStory = storyList[i];
                    ReplaceSubtitles.instance.start = true;
                    
                    break;
                }
            }

        }
    }
}

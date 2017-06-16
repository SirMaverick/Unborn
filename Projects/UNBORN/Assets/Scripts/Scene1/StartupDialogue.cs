using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupDialogue : MonoBehaviour {

    public string storyUsed;
    private CharacterStorySettings[] storyList;

	// Use this for initialization
	void Start () {
        ReplaceSubtitles.instance.currentChar = gameObject;
        storyList = gameObject.GetComponents<CharacterStorySettings>();
        for (int i = 0; i < storyList.Length; i++ ) {
            if (storyList[i].dialogueName == storyUsed) {
                ReplaceSubtitles.instance.currentStory = storyList[i];
                ReplaceSubtitles.instance.start = true;
                break;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

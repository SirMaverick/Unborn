using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPeterBack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(ReplaceSubtitles.instance.currentNode.character == "Peter" && ReplaceSubtitles.instance.currentNode.fmodVoiceOver == "4") {
            Destroy(GetComponent<CharacterStorySettings>());
            GetComponent<EnvironmentalAction>().interactableAction = "call Peter back.";
        }

        if(ReplaceSubtitles.instance.currentNode.character == "Computer") {
            Destroy(GetComponent<CharacterStorySettings>());
            Destroy(GetComponent<EnvironmentalAction>());
            Destroy(this);

        }
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterSamsRoom : MonoBehaviour {

    public string storyInUse;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            ReplaceSubtitles.instance.currentStory = GetComponent<CharacterStorySettings>();
            ReplaceSubtitles.instance.start = true;
            Destroy(GetComponent<CharacterStorySettings>());
            Destroy(this);
        }

    }
}

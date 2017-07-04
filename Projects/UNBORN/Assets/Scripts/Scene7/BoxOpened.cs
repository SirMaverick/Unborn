using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOpened : MonoBehaviour {

    GameObject lever;

	// Use this for initialization
	void Start () {
        lever = GameObject.Find("Lever");
        lever.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(ReplaceSubtitles.instance.currentNode.character == "Sam" && ReplaceSubtitles.instance.currentNode.fmodVoiceOver == "Zin08c") {
            lever.SetActive(true);
            Destroy(this);            
        }
	}
}

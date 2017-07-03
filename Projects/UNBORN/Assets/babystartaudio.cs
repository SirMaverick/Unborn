using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class babystartaudio : MonoBehaviour {
	bool playing = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		string currenttext = ReplaceSubtitles.instance.currentNode.fmodVoiceOver;
		string currentchar = ReplaceSubtitles.instance.currentNode.character;

		if(currentchar == "Avaline" && currenttext == "Zin03" && playing == false)
		{
			Debug.Log("Playing baby cry audio...");
			GetComponent<StudioEventEmitter>().Play();
			playing = true;
		}

	}
}

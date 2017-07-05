using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class KerkBGMstop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(ReplaceSubtitles.instance.currentNode.triggerFunction == "PreloadWithFadeInAndOut")
		{
			GetComponent<StudioEventEmitter>().Stop();
		}
	}
}

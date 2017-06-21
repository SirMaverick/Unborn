using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBloodtracks : MonoBehaviour {

    List<GameObject> bloodtracks = new List<GameObject>();

    GameObject sam;

    bool done;

	// Use this for initialization
	void Start () {
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("Bloodtrack")) {
            bloodtracks.Add(go);
            go.SetActive(false);
        }
        sam = GameObject.FindGameObjectWithTag("Sam");
	}
	
	// Update is called once per frame
	void Update () {
		if(ReplaceSubtitles.instance.play == false && done == false) {
            sam.SetActive(false);
            ReplaceSubtitles.instance.currentStory = GetComponent<CharacterStorySettings>();
            foreach(GameObject go in bloodtracks) {
                go.SetActive(true);
            }
            done = true;
            Destroy(GetComponent<CharacterStorySettings>());
            Destroy(this);
        }
	}
}

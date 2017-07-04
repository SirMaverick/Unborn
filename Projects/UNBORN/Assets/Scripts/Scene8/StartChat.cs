using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class StartChat : MonoBehaviour {

    List<GameObject> bloodtracks = new List<GameObject>();

    GameObject sam;

    bool done;

    // Use this for initialization
    void Start () {
        ReplaceSubtitles.instance.currentStory = GetComponent<CharacterStorySettings>();
        ReplaceSubtitles.instance.start = true;
        Destroy(GetComponent<CharacterStorySettings>());
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Bloodtrack")) {
            bloodtracks.Add(go);
            go.SetActive(false);
        }
        sam = GameObject.FindGameObjectWithTag("Sam");
    }
	
	// Update is called once per frame
	void Update () {
        if (ReplaceSubtitles.instance.play == false && done == false) {
            sam.SetActive(false);
            ReplaceSubtitles.instance.currentStory = GetComponent<CharacterStorySettings>();
            ReplaceSubtitles.instance.start = true;
            foreach (GameObject go in bloodtracks) {
                go.SetActive(true);
            }
            done = true;
            GameObject.Find("BGM").GetComponent<StudioEventEmitter>().Play();
            Destroy(GetComponent<CharacterStorySettings>());
            Destroy(this);
        }
    }
}

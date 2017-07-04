using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartNews : MonoBehaviour {

    RawImage newsAnchor;
    MovieTexture movie;
    AudioSource audioS;
    bool done, done2;

	// Use this for initialization
	void Start () {
        newsAnchor = GameObject.Find("News Anchor").GetComponent<RawImage>();
        movie = newsAnchor.texture as MovieTexture;
        audioS = newsAnchor.gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(ReplaceSubtitles.instance.currentNode.dialogueName == "Start News" && done == false) {
            ShowNews();
            done = true;
        }
        if(done == true && audioS.isPlaying == false && done2 == false) {
            StartCoroutine(PreloadLevel.SwitchToCredits());
            done2 = true;
        }
	}

    void ShowNews() {
        newsAnchor.color = new Color(newsAnchor.color.r, newsAnchor.color.g, newsAnchor.color.b, 1);
        movie.Play();
        audioS.Play();
    }
}

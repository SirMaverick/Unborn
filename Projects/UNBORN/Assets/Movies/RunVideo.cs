using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunVideo : MonoBehaviour {

    public MovieTexture movie;

    RawImage image;
    AudioSource AS;



	// Use this for initialization
	void Start () {
        image = GetComponent<RawImage>();
        AS = GetComponent<AudioSource>();

        PlayClip();
		
	}

    void PlayClip() {
        image.texture = movie;
        movie.Play();
        AS.clip = movie.audioClip;
        AS.Play();
    }

}

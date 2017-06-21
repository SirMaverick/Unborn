using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenTexture : MonoBehaviour {

    public int CurrentTexture;
    public float ActivationSlider;

    public Texture[] Textures;

	// Use this for initialization
	void Start () {
        CurrentTexture = 0;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Renderer>().material.mainTexture = Textures[CurrentTexture];
        ActivationSlider = gameObject.GetComponent<Renderer>().material.GetFloat("_ActivationSlider");
        if(ActivationSlider < 1)
        {
            ActivationSlider += 0.01f;
            gameObject.GetComponent<Renderer>().material.SetFloat("_ActivationSlider", ActivationSlider);
        }
	}
}

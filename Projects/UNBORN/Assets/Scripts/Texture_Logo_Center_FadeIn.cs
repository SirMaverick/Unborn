using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texture_Logo_Center_FadeIn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        Material mat = renderer.material;

        float emission = Mathf.Lerp(0, 2.5f, 0.01f);

        Color finalColor = GetComponent<Renderer>().material.color * Mathf.LinearToGammaSpace(emission);

        mat.SetColor("_EmissionColor", finalColor);
    }
}

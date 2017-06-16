using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScreenGlitchScript : MonoBehaviour {

    public float intensity;
    private Material material;


    private void Awake() {
        material = new Material(Shader.Find("Hidden/ScreenGlitch"));   
    }

    void OnRenderImage (RenderTexture source, RenderTexture destination) {
        if (intensity == 0) {
            Graphics.Blit(source, destination);
            return;
        }

        material.SetFloat("_bwBlend", intensity);
        Graphics.Blit(source, destination, material);
    }

    // Use this for initialization
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

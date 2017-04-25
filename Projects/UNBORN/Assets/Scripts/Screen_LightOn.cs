using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_LightOn : MonoBehaviour {

    public bool LightOn;
    public GameObject RandomScreen;
    public float StartIntensity;

	// Use this for initialization
	void Start () {
        StartIntensity = gameObject.GetComponent<Light>().intensity;
        gameObject.GetComponent<Light>().intensity = 0;
    }
	
	// Update is called once per frame
	void Update () {
        LightOn = RandomScreen.GetComponent<Texture_Screen_Flicker>().LightOn;
		if(LightOn == true)
        {
            GetComponent<Light>().intensity = StartIntensity;
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2_ControlPanel : MonoBehaviour {

    public bool Shutters;
    public bool Lights;
    public bool Holograms;
    public bool Intimacy;

    public Light[] CheckLights;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Shutters == true)
        {
            CheckLights[0].intensity = 10;
            CheckLights[1].intensity = 0;
        }
        else
        {
            CheckLights[0].intensity = 0;
            CheckLights[1].intensity = 10;
        }
        if (Lights == true)
        {
            CheckLights[2].intensity = 10;
            CheckLights[3].intensity = 0;
        }
        else
        {
            CheckLights[2].intensity = 0;
            CheckLights[3].intensity = 10;
        }
        if (Holograms == true)
        {
            CheckLights[4].intensity = 10;
            CheckLights[5].intensity = 0;
        }
        else
        {
            CheckLights[4].intensity = 0;
            CheckLights[5].intensity = 10;
        }
        if (Intimacy == true)
        {
            Shutters = false;
            CheckLights[6].intensity = 10;
            CheckLights[7].intensity = 0;
        }
        else
        {
            CheckLights[6].intensity = 0;
            CheckLights[7].intensity = 10;
        }
    }
}

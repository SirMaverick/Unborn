using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2_IntimacyCandles : MonoBehaviour {

public float Transparancy;
    public GameObject WindowShutters;
    public bool IntimacyMode;

    public bool HologramOn;

    // Use this for initialization
    void Start()
    {
        WindowShutters = GameObject.Find("WindowShutter");
        Transparancy = GetComponent<Renderer>().material.GetFloat("_Transparancy");
    }

    // Update is called once per frame
    void Update()
    {
        IntimacyMode = WindowShutters.GetComponent<WindowShutters>().IntimacyMode;
        if (IntimacyMode == true && HologramOn == false )
        {
            HologramOn = true;

        }
        else if (IntimacyMode == false && HologramOn == true)
        {
            HologramOn = false;
            
        }
        if (Transparancy > 0.50f && HologramOn == false)
        {
            Transparancy -= 0.005f;
            GetComponent<Renderer>().material.SetFloat("_Transparancy", Transparancy);
        }
        else if (Transparancy < 0.9f && HologramOn == true)
        {
            Transparancy += 0.005f;
            GetComponent<Renderer>().material.SetFloat("_Transparancy", Transparancy);
        }
    }

}
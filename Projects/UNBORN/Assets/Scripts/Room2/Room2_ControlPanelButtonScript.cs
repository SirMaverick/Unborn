using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2_ControlPanelButtonScript : MonoBehaviour
{

    public bool Hovering;
    public bool AnimationPlayed;

    public Color Startcolor;
    // Use this for initialization
    void Start()
    {
        Startcolor = GetComponent<Renderer>().material.GetColor("_EmissionColor");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag != "LightsButton")
        {
            if (Hovering == true && AnimationPlayed == false)
            {
                gameObject.GetComponent<Animation>().Play("ControlPanelButtonHover");
                AnimationPlayed = true;
            }
            else if (Hovering == false && AnimationPlayed == true)
            {
                gameObject.GetComponent<Animation>().Play("ControlPanelButtonNoHover");
                AnimationPlayed = false;
            }

            if (Hovering == true)
            {
                gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.8f, 0.8f, 0.8f));
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Startcolor);
            }
        }
        else
        {
            if (Hovering == true)
            {
                gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.8f, 0.2f, 0));
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Startcolor);
            }

        }
    }
}

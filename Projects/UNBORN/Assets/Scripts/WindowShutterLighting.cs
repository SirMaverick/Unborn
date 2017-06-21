using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowShutterLighting : MonoBehaviour {

    public GameObject WindowShutters;
    public bool Increasing = true;
    public Color StartColor;
    public bool IntimacyMode;

	// Use this for initialization
	void Start () {
		 gameObject.GetComponent<Light>().intensity = 0.5f;
        StartColor = gameObject.GetComponent<Light>().color;
	}
	
	// Update is called once per frame
	void Update () {
        IntimacyMode = WindowShutters.GetComponent<WindowShutters>().IntimacyMode;

		if (WindowShutters.GetComponent<WindowShutters>().ShuttersOpen == true && Increasing == true)
        {
            StartCoroutine(LightOn());
        }

        if (WindowShutters.GetComponent<WindowShutters>().ShuttersOpen == false && Increasing == false)
        {
            StartCoroutine(LightOff());
        }

        if (GetComponent<Light>().intensity > 6)
        {
            GetComponent<Light>().intensity = 6;
            Increasing = false;
        }

        if (GetComponent<Light>().intensity < 0.5f)
        {
            GetComponent<Light>().intensity = 0.5f;
            Increasing = true;
        }

        if (IntimacyMode == true && WindowShutters.GetComponent<WindowShutters>().ShuttersOpen == false)
        {
            gameObject.GetComponent<Light>().color = new Color(1f, 0, 0);
            if (GetComponent<Light>().intensity < 3)
            {
                GetComponent<Light>().intensity += 0.03f;
            }
        }
        else
        {

            if (GetComponent<Light>().intensity > 0.5 && WindowShutters.GetComponent<WindowShutters>().ShuttersOpen == false  && WindowShutters.GetComponent<WindowShutters>().ShuttersOpened == false)
            {
                GetComponent<Light>().intensity -= 0.03f;
            }
            if (GetComponent<Light>().intensity <= 0.5)
            {
                gameObject.GetComponent<Light>().color = StartColor;
            }
        }

       
	}

    IEnumerator LightOn()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<Light>().intensity += 0.0200f;
    }

    IEnumerator LightOff()
    {
        yield return new WaitForSeconds(0);
        GetComponent<Light>().intensity -= 0.0200f;
    }

}

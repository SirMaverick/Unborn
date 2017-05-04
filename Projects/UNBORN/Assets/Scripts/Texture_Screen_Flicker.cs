using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Texture_Screen_Flicker : MonoBehaviour {

    private Material Mat;
    public bool LightOn;
    public int FlickerSolved;
    public int DelayMin;
    public int DelayMax;
    public bool mainScreen = false;

    // Use this for initialization
    void Start () {
        Mat = gameObject.GetComponent<Renderer>().material;

        if (mainScreen)
        {
            
            StudioEventEmitter mainscreen = GameObject.FindGameObjectsWithTag("Mainscreen_sound")[0].GetComponent<StudioEventEmitter>();
            mainscreen.Play();
        }
        StartCoroutine(ScreenFlickerDelay());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator ScreenFlickerDelay()
    {
       yield return new WaitForSeconds(Random.Range(DelayMin,DelayMax));
        StartCoroutine(ScreenFlicker());
        LightOn = true;

        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).transform.name == "screensound")
            {
                transform.GetChild(i).GetComponent<StudioEventEmitter>().Play();
            }
        }

        if (FlickerSolved == 1)
        {
            Mat.SetColor("_EmissionColor", (GetComponent<Renderer>().material.color * 2.5f));
        }

    }
    IEnumerator ScreenFlicker()
    {
        while (FlickerSolved != 1)
        {
            FlickerSolved = Random.Range(0, 2);
            Mat.SetColor("_EmissionColor", (GetComponent<Renderer>().material.color * 0));
            yield return new WaitForSeconds(Random.Range(0.3f,0.5f));
            Mat.SetColor("_EmissionColor", (GetComponent<Renderer>().material.color * 2.5f));

            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).transform.name == "screensound")
                {
                    transform.GetChild(i).GetComponent<StudioEventEmitter>().Play();
                }
            }


            yield return new WaitForSeconds(Random.Range(0.3f, 0.5f));
        }

    }
}

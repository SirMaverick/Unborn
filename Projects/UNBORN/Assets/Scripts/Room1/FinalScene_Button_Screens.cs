using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScene_Button_Screens : MonoBehaviour {

    public GameObject MainButton;
    public float Transparancy;
    public bool ScreensLowering;
    public bool ScreensOn;

    // Use this for initialization
    void Start () {
        Transparancy = GetComponent<Renderer>().material.GetFloat("_Transparancy");
    }
	
	// Update is called once per frame
	void Update () {
        if (MainButton.GetComponent<FinalScene_Button>().ButtonDown == true && ScreensLowering == false)
        {
            ScreensLowering = true;
            StartCoroutine(InitializeScreens());
        }
        if (ScreensOn == true && Transparancy < 0.75f)
        {
            Transparancy += 0.005f;
            GetComponent<Renderer>().material.SetFloat("_Transparancy", Transparancy);
        }
	}

    IEnumerator InitializeScreens()
    {
        yield return new WaitForSeconds(3);
        ScreensOn = true;

    }

 }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour {

    public GameObject MainScreen;
    public int ButtonNumber;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnButtonClick()
    {
        Debug.Log("Click");
        Debug.Log(ButtonNumber);
        MainScreen.GetComponent<MainScreenTexture>().CurrentTexture = ButtonNumber;
        MainScreen.GetComponent<Renderer>().material.SetFloat("_ActivationSlider", 0);
        MainScreen.GetComponent<MainScreenTexture>().ActivationSlider = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScene_Button : MonoBehaviour {

    public GameObject ButtonMid;
    public GameObject ButtonConsole;

    public bool ButtonDown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.G) == true && ButtonDown == false)
        {
            ButtonDown = true;
            GetComponent<Animation>().Play();
            ButtonMid.GetComponent<Animation>().Play();
            ButtonConsole.GetComponent<Animation>().Play();
        }
	}
}

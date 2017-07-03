using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowShutters : MonoBehaviour {

    bool inHouse;
    public bool ShuttersOpen;
    public bool ShuttersOpened;

    public bool IntimacyMode;

    public GameObject ControlPanel;
    public GameObject Shutter2;
    public GameObject Shutter3;
    public GameObject Shutter4;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (ControlPanel.GetComponent<Room2_ControlPanel>().Shutters == true && ShuttersOpen == false && ShuttersOpened == false && IntimacyMode == false)
        {
            StartCoroutine(ShutterOpen());
        }
        else if (ControlPanel.GetComponent<Room2_ControlPanel>().Shutters == false && ShuttersOpen == true && ShuttersOpened == true)
        {
            StartCoroutine(ShutterClose());
        }
        if (ControlPanel.GetComponent<Room2_ControlPanel>().Intimacy == false)
        {
            IntimacyMode = false;
        }
        if (ControlPanel.GetComponent<Room2_ControlPanel>().Intimacy == true && ShuttersOpen == false && ShuttersOpened == false && IntimacyMode == false)
        {
            IntimacyMode = true;
        }



	}

    IEnumerator ShutterOpen()
    {
        ShuttersOpen = true;
        gameObject.GetComponent<Animation>().Play("WindowShutters");
        yield return new WaitForSeconds(0.5f);
        Shutter2.GetComponent<Animation>().Play("WindowShutters");
        yield return new WaitForSeconds(0.5f);
        Shutter3.GetComponent<Animation>().Play("WindowShutters");
        yield return new WaitForSeconds(0.5f);
        Shutter4.GetComponent<Animation>().Play("WindowShutters");
        yield return new WaitForSeconds(5f);
        ShuttersOpened = true;
    }

    IEnumerator ShutterClose()
    {
        ShuttersOpen = false;
        gameObject.GetComponent<Animation>().Play("WindowShuttersClose");
        yield return new WaitForSeconds(0.5f);
        Shutter2.GetComponent<Animation>().Play("WindowShuttersClose");
        yield return new WaitForSeconds(0.5f);
        Shutter3.GetComponent<Animation>().Play("WindowShuttersClose");
        yield return new WaitForSeconds(0.5f);
        Shutter4.GetComponent<Animation>().Play("WindowShuttersClose");
        yield return new WaitForSeconds(5f);
        ShuttersOpened = false;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player" && inHouse == false) {
            inHouse = true;
            ControlPanel.GetComponent<Room2_ControlPanel>().Shutters = true;
            ControlPanel.GetComponent<Room2_ControlPanel>().Holograms = true;
         }
    }
}

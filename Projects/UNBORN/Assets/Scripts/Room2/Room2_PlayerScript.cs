using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2_PlayerScript : MonoBehaviour
{
    RaycastHit Hitobject;
    public Camera camera;
    public GameObject ControlPanel;

    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            
            if (hit.transform.tag == "ShuttersButton" || hit.transform.tag == "HologramsButton" || hit.transform.tag == "IntimacyButton" || hit.transform.tag == "LightsButton")
            {
                hit.transform.GetComponent<Room2_ControlPanelButtonScript>().Hovering = true;
                Hitobject = hit;
            }
            else
            {
                Hitobject.transform.GetComponent<Room2_ControlPanelButtonScript>().Hovering = false;
            }

            if (hit.transform.tag == "ShuttersButton" && Input.GetMouseButtonDown(0))
            {
                if (ControlPanel.GetComponent<Room2_ControlPanel>().Shutters == false)
                {
                    ControlPanel.GetComponent<Room2_ControlPanel>().Shutters = true;
                }
                else
                {
                    ControlPanel.GetComponent<Room2_ControlPanel>().Shutters = false;
                }
            }

            if (hit.transform.tag == "HologramsButton" && Input.GetMouseButtonDown(0))
            {
                if (ControlPanel.GetComponent<Room2_ControlPanel>().Holograms == false)
                {
                    ControlPanel.GetComponent<Room2_ControlPanel>().Holograms = true;
                }
                else
                {
                    ControlPanel.GetComponent<Room2_ControlPanel>().Holograms = false;
                }
                
            }
            if (hit.transform.tag == "IntimacyButton" && Input.GetMouseButtonDown(0))
            {
                if (ControlPanel.GetComponent<Room2_ControlPanel>().Intimacy == false)
                {
                    ControlPanel.GetComponent<Room2_ControlPanel>().Intimacy = true;
                }
                else
                {
                    ControlPanel.GetComponent<Room2_ControlPanel>().Intimacy = false;
                }
            }


            // Do something with the object that was hit by the raycast.
        }
    }
}

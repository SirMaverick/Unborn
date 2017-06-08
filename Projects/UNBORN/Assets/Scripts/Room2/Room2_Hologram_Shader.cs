using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2_Hologram_Shader : MonoBehaviour {

    public float Transparancy;
    public float Offset;

    public GameObject Player;
    public GameObject ControlPanel;

    public bool HologramOn;

    // Use this for initialization
    void Start()
    {
        ControlPanel = GameObject.Find("ControlPanel");
        Player = GameObject.Find("Player");
        Transparancy = GetComponent<Renderer>().material.GetFloat("_Transparancy");
        Offset = GetComponent<Renderer>().material.GetFloat("_Offset");
    }

    // Update is called once per frame
    void Update()
    {
        if (ControlPanel.GetComponent<Room2_ControlPanel>().Holograms == true && HologramOn == false)
        {
            HologramOn = true;
            gameObject.GetComponent<ParticleSystem>().Stop();

        }
        else if (ControlPanel.GetComponent<Room2_ControlPanel>().Holograms == false && HologramOn == true)
        {
            HologramOn = false;
            gameObject.GetComponent<ParticleSystem>().Play();
            
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

        if (Vector3.Distance(Player.transform.position, this.transform.position) < 1)
        {
            if(Offset <= 0.5f)
            {
                Offset += 0.05f;
            }
            GetComponent<Renderer>().material.SetFloat("_Offset", Offset);
        }
        else
        {
            if (Offset >= 0)
            {
                Offset -= 0.05f;
            }
            GetComponent<Renderer>().material.SetFloat("_Offset", Offset);
        }
    }

}
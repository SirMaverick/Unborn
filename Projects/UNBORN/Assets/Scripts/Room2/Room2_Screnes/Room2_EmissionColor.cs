using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2_EmissionColor : MonoBehaviour {

    private Material Mat;
    public GameObject Player;
    public float PlayerDistance;
    public float EmissionColor;


    // Use this for initialization
    void Start()
    {
        Mat = gameObject.GetComponent<Renderer>().material;
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerDistance < 4f)
        {
            if (EmissionColor < 8)
                EmissionColor += 0.02f;
        }
        else
        {
            if (EmissionColor > 0)
                EmissionColor -= 0.04f;
        }
        PlayerDistance = Vector3.Distance(this.transform.position, Player.transform.position);
        Mat.SetColor("_EmissionColor", new Color (EmissionColor, EmissionColor / 4, 0));
        //Mat.SetColor("_EmissionColor", new Color (3f / (PlayerDistance / 4), 2f / (PlayerDistance), 0));
    }
}

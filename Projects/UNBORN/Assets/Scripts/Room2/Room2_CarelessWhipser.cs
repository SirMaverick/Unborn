using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2_CarelessWhipser : MonoBehaviour
{

    public GameObject WindowShutters;
    public bool IntimacyMode;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        IntimacyMode = WindowShutters.GetComponent<WindowShutters>().IntimacyMode;

        if (IntimacyMode == true)
        {
            if (gameObject.GetComponent<AudioSource>().isPlaying == false)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
            if (GetComponent<AudioSource>().volume < 1)
            {
                GetComponent<AudioSource>().volume += 0.01f;
            }
        }
        else
        {
            if (GetComponent<AudioSource>().volume > 0)
            {
                GetComponent<AudioSource>().volume -= 0.01f;
            }
        }
    }
}

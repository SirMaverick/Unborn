using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDistortion : MonoBehaviour {




    public static void StartDistortionEffect() {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CRTEffect>().enabled = true;
    }

    public static void StopDistortionEffect() {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CRTEffect>().enabled = false;
    }
}

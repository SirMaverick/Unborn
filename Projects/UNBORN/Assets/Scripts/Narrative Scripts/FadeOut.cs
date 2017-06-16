using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

    public static IEnumerator FadeToScreen() {
        GameObject faderObject = GameObject.FindGameObjectWithTag("Fader");
        RawImage fader = faderObject.GetComponent<RawImage>();
        Color color = fader.color;
        for (float i = 1; i > 0; i-= 0.02f) {
            color.a = i;
            fader.color = color;
            yield return new WaitForSeconds(0.02f);
        }
    }

}

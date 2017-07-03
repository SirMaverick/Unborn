using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {

    public Light light;
    public float maxIntensity;
    public float step;

	// Use this for initialization
	void Start () {
        step = maxIntensity / 100;
        StartCoroutine(BlinkIn());
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.T)) {
            SetAlarmBlink.SetAlarm();
        }
	}

    IEnumerator BlinkOut() {
        for(int i = 0; light.intensity > 0; i++) {
            light.intensity -= step;
            yield return new WaitForSeconds(0.02f);
        } StartCoroutine(BlinkIn());
    }

    IEnumerator BlinkIn() {
        for (int i = 0; light.intensity < 2; i++) {
            light.intensity += step;
            yield return new WaitForSeconds(0.02f);
           
        } StartCoroutine(BlinkOut());
    }
}

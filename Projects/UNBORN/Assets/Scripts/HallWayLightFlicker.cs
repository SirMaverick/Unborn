using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallWayLightFlicker : MonoBehaviour {

    public GameObject Lamp;
    public Material LampOn;
    public Material LampOff;



	// Use this for initialization
	void Start () {
        StartCoroutine(LightFlicker());
    }

    
    IEnumerator LightFlicker()
    {
        GetComponent<Light>().intensity = 0;
        Lamp.GetComponent<MeshRenderer>().material = LampOff;
        yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
        GetComponent<Light>().intensity = Random.Range(3, 10);
        Lamp.GetComponent<MeshRenderer>().material = LampOn;
        yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
        GetComponent<Light>().intensity = 0;
        Lamp.GetComponent<MeshRenderer>().material = LampOff;
        yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
        GetComponent<Light>().intensity = Random.Range(3, 10);
        Lamp.GetComponent<MeshRenderer>().material = LampOn;
        yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
        GetComponent<Light>().intensity = 0;
        Lamp.GetComponent<MeshRenderer>().material = LampOff;
        yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
        GetComponent<Light>().intensity = Random.Range(3, 10);
        Lamp.GetComponent<MeshRenderer>().material = LampOn;
        yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
        GetComponent<Light>().intensity = 0;
        Lamp.GetComponent<MeshRenderer>().material = LampOff;
        yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
        GetComponent<Light>().intensity = Random.Range(3, 10);
        Lamp.GetComponent<MeshRenderer>().material = LampOn;
        yield return new WaitForSeconds(Random.Range(5f, 20f));
        StartCoroutine(LightFlicker());
    }
}

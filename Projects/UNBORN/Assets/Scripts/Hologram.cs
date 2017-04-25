using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hologram : MonoBehaviour {

    private Color BaseColor;

	// Use this for initialization
	void Start () {
        BaseColor = gameObject.GetComponent<Renderer>().material.GetColor("_TintColor");
        StartCoroutine(HoloGramFlicker());
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * 0.1f);
    }

    IEnumerator HoloGramFlicker ()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", BaseColor * 0.6f);
        yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
        gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", BaseColor * Random.Range(0.61f,0.65f));
        yield return new WaitForSeconds(Random.Range(0.11f, 0.3f));
        StartCoroutine(HoloGramFlicker());

    }


}

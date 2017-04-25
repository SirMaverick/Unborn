using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston_Animation : MonoBehaviour {

    public float Delay;

	// Use this for initialization
	void Start () {
        StartCoroutine(AnimationDelay());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator AnimationDelay()
    {
        yield return new WaitForSeconds(Delay);
        GetComponent<Animation>().Play();
    }
}

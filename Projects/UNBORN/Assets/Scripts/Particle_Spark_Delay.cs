using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Spark_Delay : MonoBehaviour {

    public int Delay;

	// Use this for initialization
	void Start () {
        StartCoroutine(SparkDelay());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SparkDelay()
    {
        yield return new WaitForSeconds(Random.Range(1, Delay));
        GetComponent<ParticleSystem>().Play();
    }
}

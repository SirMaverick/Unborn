using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceBaby : MonoBehaviour {

    public GameObject babyWithScript;
    public GameObject babyWithout;

	// Update is called once per frame
	void Update () {
		if (HospitalDoorScript.amountOfDoorsOpened == 3 && babyWithout) {
            babyWithout.SetActive(false);
            babyWithScript.SetActive(true);
            Destroy(this);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class HospitalDoorContainer : MonoBehaviour {

    public bool DoorMoving;
    public bool DoorOpen;
    public Transform newHospitalPos;

	private bool previousmoving = false;

	private void Update()
	{
		if(previousmoving == false && DoorMoving == true)
		{
			//TO DO (-Milan)
			//RuntimeManager.PlayOneShot("event:/Room 02/SFX/Door_open", transform.position + new Vector3(0, 0, 0.85f));
			
		}
		previousmoving = DoorMoving;
	}

}

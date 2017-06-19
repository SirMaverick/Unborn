using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class DoorScript : MonoBehaviour {

    public bool DoorMoving;
    public bool DoorOpen;

    public GameObject DoorPlate;
    public GameObject Player;
    public Animation Anim;

	// Use this for initialization
	void Start () {
        Anim = gameObject.GetComponent<Animation>();
        Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F) && DoorMoving == false && Vector3.Distance(Player.transform.position, gameObject.transform.position) < 3)
            {
            if (DoorOpen == false)
            {
                StartCoroutine(OpenDoor());
				Debug.Log("play");
				RuntimeManager.PlayOneShot("event:/Room 02/SFX/Door_open", transform.position + new Vector3(0, 0, 0.85f));
            }
            else
            {
                StartCoroutine(CloseDoor());
            }
        }
	}

    IEnumerator OpenDoor()
    {
        DoorMoving = true;
        GetComponent<Animation>().Play("DoorConsole");
        yield return new WaitForSeconds(0.4f);
        DoorPlate.GetComponent<Animation>().Play("DoorPlate");
        yield return new WaitForSeconds(1);
        DoorOpen = true;
        DoorMoving = false;
    }

    IEnumerator CloseDoor()
    {
        DoorMoving = true;
        DoorPlate.GetComponent<Animation>().Play("DoorPlateClose");
        yield return new WaitForSeconds(0.7f);
        GetComponent<Animation>().Play("DoorConsoleClose");
        yield return new WaitForSeconds(1);
        DoorOpen = false;
        DoorMoving = false;
    }
}

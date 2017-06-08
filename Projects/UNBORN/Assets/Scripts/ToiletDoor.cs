using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletDoor : MonoBehaviour {

    public bool DoorMoving;
    public bool DoorOpen;

    public GameObject Player;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && DoorMoving == false && Vector3.Distance(Player.transform.position, gameObject.transform.position) > 16 && Vector3.Distance(Player.transform.position, gameObject.transform.position) < 18 )
        {
            if (DoorOpen == false)
            {
                StartCoroutine(OpenDoor());
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
        GetComponent<Animation>().Play("DoorToilet");
        yield return new WaitForSeconds(3f);
        DoorOpen = true;
        DoorMoving = false;
    }

    IEnumerator CloseDoor()
    {
        DoorMoving = true;
        GetComponent<Animation>().Play("DoorToiletClose");
        yield return new WaitForSeconds(3f);
        DoorOpen = false;
        DoorMoving = false;
    }
}

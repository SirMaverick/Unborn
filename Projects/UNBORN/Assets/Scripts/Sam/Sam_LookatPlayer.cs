using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sam_LookatPlayer : MonoBehaviour {

    public Transform Player;
    public GameObject samHead;
    public Quaternion Startposition;
    public Quaternion TargetRotation;

    public float Angleview;

    public bool LookAtPlayer;

    // Use this for initialization
    void Start() {
        Player = GameObject.Find("MainCamera").transform;
        //SamChest = GameObject.Find("SamChest").transform;
        Startposition = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update() {
        TargetRotation = Quaternion.LookRotation(Player.transform.position - samHead.transform.position);
        


        if (LookAtPlayer == true && Vector3.Distance(Player.transform.position, samHead.transform.position) < 3)
        {
           samHead.transform.rotation = Quaternion.Slerp(samHead.transform.rotation,TargetRotation * new Quaternion (0, 2, 0, 0), 4f * Time.deltaTime);
        }

        if (LookAtPlayer == false)
        {
            samHead.transform.rotation = Quaternion.Slerp(samHead.transform.rotation, Startposition, 4f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
                LookAtPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            LookAtPlayer = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracy_LookAtPlayer : MonoBehaviour {

    public Transform Player;
    public Quaternion Startposition;
    public Quaternion TargetRotation;

    public float Angleview;

    public bool LookAtPlayer;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("MainCamera").transform;
        //SamChest = GameObject.Find("SamChest").transform;
        Startposition = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        TargetRotation = Quaternion.LookRotation(Player.transform.position - transform.position);
        //float Angle = Vector3.Angle(SamChest.transform.forward, Player.position - transform.position);
        //Angleview = Angle;
        //if (Mathf.Abs(Angle) > 30 && Mathf.Abs(Angle) < 130)
        if (Vector3.Distance(Player.transform.position, gameObject.transform.position) < 2)
        {
            LookAtPlayer = true;
            print("Object2 if front Obj1");
        }
        else
        {
            LookAtPlayer = false;
        }

        if (LookAtPlayer == true && Vector3.Distance(Player.transform.position, gameObject.transform.position) < 3)
        {

            //transform.LookAt(2 * transform.position - Player.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, 4f * Time.deltaTime);
        }

        if (LookAtPlayer == false)
        {
            //transform.rotation = Startposition;
            transform.rotation = Quaternion.Slerp(transform.rotation, Startposition, 4f * Time.deltaTime);
        }
    }
}

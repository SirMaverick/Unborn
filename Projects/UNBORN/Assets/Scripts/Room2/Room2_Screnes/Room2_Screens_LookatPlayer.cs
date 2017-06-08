using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2_Screens_LookatPlayer : MonoBehaviour {

    public Transform Player;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.LookAt(Player);
	}
}

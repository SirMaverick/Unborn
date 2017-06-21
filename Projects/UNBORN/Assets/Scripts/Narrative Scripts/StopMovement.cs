using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class StopMovement : MonoBehaviour {

        public static void MovementOff(float maxY, float minY) {
            GameObject player = GameObject.Find("Player");
            RigidbodyFirstPersonController playerController = player.GetComponent<RigidbodyFirstPersonController>();
            playerController.AllowMovement = false;
            playerController.mouseLook.MaximumY = 60;
            playerController.mouseLook.MinimumY = -60;
        }

        public static void MovementOn() {
            GameObject player = GameObject.Find("Player");
            RigidbodyFirstPersonController playerController = player.GetComponent<RigidbodyFirstPersonController>();
            playerController.AllowMovement = true;
            playerController.mouseLook.clampPlayerRotation = false;
        }
    }
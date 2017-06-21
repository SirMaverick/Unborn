using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class TestSwapFMod : MonoBehaviour {
    
    string inputSound = "event:/VO/Scene02/Avaline/Zin02";
    FMOD.Studio.EventInstance snapshot;
    


    // Use this for initialization
    void Start () {
        snapshot = RuntimeManager.CreateInstance(inputSound);
    }
	
	// Update is called once per frame
	void Update () {

       


        if (Input.GetKeyDown(KeyCode.Y)) {
            FMOD.Studio.PLAYBACK_STATE play_state;
            snapshot.getPlaybackState(out play_state);
            if (play_state == FMOD.Studio.PLAYBACK_STATE.PLAYING) {
                snapshot.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

                snapshot.release ();

            }
            inputSound = "event:/VO/Scene02/Avaline/Zin02";
            snapshot = RuntimeManager.CreateInstance(inputSound);
            snapshot.start();

        } else if (Input.GetKeyDown(KeyCode.U)) {
            FMOD.Studio.PLAYBACK_STATE play_state;
            snapshot.getPlaybackState(out play_state);
            if (play_state == FMOD.Studio.PLAYBACK_STATE.PLAYING) {
                snapshot.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

                snapshot.release();

            }
            inputSound = "event:/VO/Scene02/Avaline/Zin03";
            snapshot = RuntimeManager.CreateInstance(inputSound);
            snapshot.start();
        } else if (Input.GetKeyDown(KeyCode.I)) {
            FMOD.Studio.PLAYBACK_STATE play_state;
            snapshot.getPlaybackState(out play_state);
            if (play_state == FMOD.Studio.PLAYBACK_STATE.PLAYING) {
                snapshot.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

                snapshot.release();

            }
            inputSound = "event:/VO/Scene02/Avaline/Zin04";
            snapshot = RuntimeManager.CreateInstance(inputSound);
            snapshot.start();
        }
        

    }
}

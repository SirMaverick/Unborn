using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SetAlarmBlink : MonoBehaviour {

    public Light light;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (ReplaceSubtitles.instance.currentNode.character == "Avaline" && ReplaceSubtitles.instance.currentNode.fmodVoiceOver == "Zin18") {
            SetAlarm();
        }
	}

    public static void SetAlarm() {
        Blink blinking = GameObject.Find("Heartmonitor").GetComponent<Blink>();
        Light redLight = GameObject.Find("RedLight").GetComponent<Light>();
        StudioEventEmitter emitter = GameObject.Find("HeartAudio").GetComponent<StudioEventEmitter>();
        StudioEventEmitter emitter2 = GameObject.Find("HeartAudioFast").GetComponent<StudioEventEmitter>();
        emitter.enabled = false;
        emitter2.enabled = true;

        redLight.range = 20;
        blinking.step = 0.25f;
        blinking.maxIntensity = 10;
    }
}

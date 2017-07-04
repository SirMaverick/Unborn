using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DialogueSettings {

    
    
    public string nodeInput = "";
    public int amountOfOutputs;
    public List<DialogueSettings> outputList = new List<DialogueSettings>();

    public bool hasOutput;
    public float waitTime;
    public string triggerFunction;
    public string fmodVoiceOver;

    [HideInInspector]
    public string dialogueName = "Untitled";
    [HideInInspector]
    public string orderString = "";
    [HideInInspector]
    public bool isChoice;
    [HideInInspector]
    public bool isTrigger;
    
    public string dialogueText = "";
    [HideInInspector]
    public string character = "";
    [HideInInspector]
    public bool choice1, choice2, choice3;
    [HideInInspector]
    public Vector2 positionInWindows;
    [HideInInspector]
    public int orderNumber;
    public AudioClip voiceOver;

    public TriggerType triggerType;

    public CharacterType characterList;
    public DialogueType dialogueType;

    public enum CharacterType {
        Computer,
        Avaline,
        Sam,
        Nurse,
        Doctor,
        UncleDavid,
        Unknown,
        Empty,
        Tracy,
        Peter,
        NewsAnchor
    }

    public enum DialogueType {
        Text,
        Audio,
        Character
    }

    public enum TriggerType {
        FadeIn,
        FadeOut,
        PreloadWithFadeIn,
        PreloadWithFadeOut,
        PreloadWithFadeInAndOut,
        Preload,
        StopMovement,
        StartMovement,
        StartDistortionEffect,
        StopDistortionEffect,
        PreloadCrash,
        PreloadFromCrash,
        SwitchToCredits
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class ReplaceSubtitles : MonoBehaviour {

    public static ReplaceSubtitles instance = null;
    public bool start;
    public bool play;
    public string lastDialogue;

    private int tempWait;

    string inputSound = "event:/VO/Scene2/Avaline/Zin02";
    FMOD.Studio.EventInstance snapshot;

    public Text subtitles;
    public Text charName;
    public Text choice1, choice2, choice3;
    private Text[] choiceLists = new Text[3];
    public RawImage fadeScreen;

    public GameObject currentChar;
    public GameObject choices;
    public CharacterStorySettings currentStory;
    private CharacterStorySettings[] dialogueList;
    public DialogueSettings currentNode;

    FMOD.Studio.EventDescription description;

    // Use this for initialization

    void Awake() {
        if (instance == null)           
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }


        void Start () {
        snapshot = RuntimeManager.CreateInstance(inputSound);
        choiceLists[0] = choice1;
        choiceLists[1] = choice2;
        choiceLists[2] = choice3;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            currentNode.choice1 = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            currentNode.choice2 = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) ) {
            currentNode.choice3 = true;
        }

        if (start && play == false) {
            StartCoroutine(StartText(currentStory.MyList[0], currentStory.MyList[0].waitTime));
            start = false;
            play = true;
        }
    }

    IEnumerator StartText(DialogueSettings d, float waitTime) {
        play = true;
        if(subtitles.enabled == false) {
            subtitles.enabled = true;
        }
        currentNode = d;
        if (d.fmodVoiceOver !=   "") {
            SwapAudio(d.fmodVoiceOver, d.character);
            waitTime = (float)tempWait / 1000;
            
        }
        Debug.Log(currentNode.dialogueName);
        Debug.Log(currentNode.isChoice);
        if (currentNode.isTrigger) {
            PlayFunction(currentNode.triggerFunction);
            yield return new WaitForSeconds(waitTime);

            if (d.hasOutput) {
                lastDialogue = currentNode.dialogueName;
                DialogueSettings nextDialogue = null;
                foreach (DialogueSettings diaS in currentStory.MyList) {
                    if (d.outputList[0].dialogueName ==  diaS.dialogueName) {
                         nextDialogue = diaS;
                    }
                }
                StartCoroutine(StartText(nextDialogue, nextDialogue.waitTime));
            } else {
                subtitles.enabled = false;
                play = false;
            }

        } else if(currentNode.isChoice == false) {
            //charName.text = d.character;
            
            subtitles.text = d.character + ": " + d.dialogueText;

            yield return new WaitForSeconds(waitTime);

            if (d.hasOutput) {
                lastDialogue = currentNode.dialogueName;
                DialogueSettings nextDialogue = null;
                foreach (DialogueSettings diaS in currentStory.MyList) {
                    if (d.outputList[0].dialogueName == diaS.dialogueName) {
                        nextDialogue = diaS;
                    }
                }
                StartCoroutine(StartText(nextDialogue, nextDialogue.waitTime));
            } else {
                subtitles.enabled = false;
                play = false;
            }
        } else {
            List<DialogueSettings> listOfChoices = new List<DialogueSettings>();
            foreach (DialogueSettings diaNode in currentStory.MyList) {
                if(diaNode.nodeInput == lastDialogue) {
                    listOfChoices.Add(diaNode);
                    Debug.Log("Added " + diaNode.nodeInput + " to list");
                }
            } for (int c = 0; c < listOfChoices.Count; c++) {
                choiceLists[c].text = listOfChoices[c].dialogueText;
            } ShowChoices(listOfChoices);

            while (currentNode.choice1 == false && currentNode.choice2 == false && currentNode.choice3 == false) {
                yield return null;
            }

            
            DialogueSettings nextDialogue = null;
            if (currentNode.choice1) {
                foreach (DialogueSettings diaS in currentStory.MyList) {
                    if (listOfChoices[0].outputList[0].dialogueName == diaS.dialogueName) {
                        nextDialogue = diaS;
                    }
                }
                currentNode.choice1 = false;
            } else if (currentNode.choice2) {
                foreach (DialogueSettings diaS in currentStory.MyList) {
                    if (listOfChoices[1].outputList[0].dialogueName == diaS.dialogueName) {
                        nextDialogue = diaS;
                    }
                }
                currentNode.choice2 = false;
            } else if (currentNode.choice3) {
                foreach (DialogueSettings diaS in currentStory.MyList) {
                    if (listOfChoices[2].outputList[0].dialogueName == diaS.dialogueName) {
                        nextDialogue = diaS;
                    }
                }
                currentNode.choice3 = false;
            }
            HideChoices(listOfChoices);
            lastDialogue = currentNode.dialogueName;
            StartCoroutine(StartText(nextDialogue, nextDialogue.waitTime));



        } 
        
        
    }

    private void OnLevelWasLoaded(int level) {
        
            //snapshot.release();
            //snapshot = RuntimeManager.CreateInstance(inputSound);
            //Debug.Log("Created Instance");
        
        
    }

    private void SwapAudio(string audioFile, string characterName) {
        int wait = 0;
        FMOD.Studio.PLAYBACK_STATE play_state;
        snapshot.getPlaybackState(out play_state);
        if (play_state == FMOD.Studio.PLAYBACK_STATE.PLAYING) {
            snapshot.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

            snapshot.release();

        }
        int currentScene = SceneManager.GetActiveScene().buildIndex + 1;
        if(characterName == "Uncle David") {
            characterName = "Uncle";
        }
        snapshot = RuntimeManager.CreateInstance("event:/VO/Scene" + currentScene + "/" + characterName + "/" + audioFile);
        snapshot.start();
        snapshot.release();
        snapshot.getDescription(out description);
        description.getLength(out wait);
        tempWait = wait;

		if (characterName != "Avaline")
		{
			RuntimeManager.AttachInstanceToGameObject(snapshot, GameObject.FindGameObjectWithTag(characterName).transform, GameObject.FindGameObjectWithTag(characterName).GetComponent<Rigidbody>());
		}

		Debug.Log(tempWait);

    }

    private void ShowChoices(List<DialogueSettings> listOfChoices) {
        choices.SetActive(true);
        for (int i = 0; i < listOfChoices.Count; i++) {
            choiceLists[i].enabled = true;
        }
    }

    private void HideChoices(List<DialogueSettings> listOfChoices) {
        choices.SetActive(false);
        for (int i = 0; i < listOfChoices.Count; i++) {
            choiceLists[i].enabled = false;
        }
    }

    public void SetBoolToTrue(int i) {
        if (i == 0) {
            currentNode.choice1 = true;
        } else if (i == 1) {
            currentNode.choice2 = true;
        } else if (i == 2) {
            currentNode.choice3 = true;
        }
    }

   public void PlayFunction(string name) {
        if (name == "FadeIn") {
            StartCoroutine(FadeIn.FadeToBlack());
        } else if (name == "FadeOut") {
            StartCoroutine(FadeOut.FadeToScreen());
        } else if (name == "PreloadWithFadeIn") {
            StartCoroutine(PreloadLevel.PreloadWithFadeIn());
        } else if (name == "PreloadWithFadeInAndOut") {
            StartCoroutine(PreloadLevel.PreloadWithFadeInAndOut());
        } else if (name == "PreloadWithFadeOut") {
            StartCoroutine(PreloadLevel.PreloadWithFadeOut());
        } else if (name == "Preload") {
            StartCoroutine(PreloadLevel.Preload());
        } else if (name == "StartMovement") {
            StopMovement.MovementOn();
        } else if (name == "StopMovement") {
            StopMovement.MovementOff(60, -60);
        } else if (name == "StartDistortionEffect") {
            StartDistortion.StartDistortionEffect();
			//foreach (GameObject bgm in GameObject.FindGameObjectsWithTag("BGM_Kerk"))
			//{
			//	bgm.GetComponent<StudioEventEmitter>().Play();
			//}
        } else if (name == "StopDistortionEffect") {
            StartDistortion.StopDistortionEffect();
        } else if (name == "PreloadCrash") {
            StartCoroutine(PreloadLevel.PreloadCrashScene());
        } else if (name == "PreloadFromCrash") {
            StartCoroutine(PreloadLevel.PreloadFromCrashScene());
        }
    }
}

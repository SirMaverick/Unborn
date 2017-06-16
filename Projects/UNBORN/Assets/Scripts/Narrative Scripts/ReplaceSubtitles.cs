using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplaceSubtitles : MonoBehaviour {

    public static ReplaceSubtitles instance = null;
    public bool start;
    public bool play;
    public string lastDialogue;

    public AudioSource playerAudio;
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


    // Use this for initialization

    void Awake() {
        if (instance == null)           
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }


        void Start () {
        choiceLists[0] = choice1;
        choiceLists[1] = choice2;
        choiceLists[2] = choice3;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q)) {
            StartCoroutine(StartText(dialogueList[0].MyList[0], 3.0f));
            currentStory = dialogueList[0];
        }
        if (Input.GetKeyDown(KeyCode.T)) {
            StartCoroutine(StartText(dialogueList[1].MyList[0], 3.0f));
            currentStory = dialogueList[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            currentNode.choice1 = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            currentNode.choice2 = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
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
        if (d.voiceOver != null) {
            playerAudio.clip = d.voiceOver;
            playerAudio.Play();
            waitTime = d.voiceOver.length;
        }
        Debug.Log(currentNode.dialogueName);
        Debug.Log(currentNode.isChoice);
        if (currentNode.isTrigger) {
            PlayFunction(currentNode.triggerFunction);
            yield return new WaitForSeconds(waitTime);

            if (d.hasOutput) {
                lastDialogue = currentNode.dialogueName;
                StartCoroutine(StartText(d.outputList[0], d.outputList[0].waitTime));
            } else {
                subtitles.enabled = false;
                play = false;
            }

        } else if(currentNode.isChoice == false) {
            //charName.text = d.character;
            subtitles.text = d.character + d.dialogueText;

            yield return new WaitForSeconds(waitTime);

            if (d.hasOutput) {
                lastDialogue = currentNode.dialogueName;
                StartCoroutine(StartText(d.outputList[0], d.outputList[0].waitTime));
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
                nextDialogue = listOfChoices[0].outputList[0];
                currentNode.choice1 = false;
            } else if (currentNode.choice2) {
                nextDialogue = listOfChoices[1].outputList[0];
                currentNode.choice2 = false;
            } else if (currentNode.choice3) {
                nextDialogue = listOfChoices[2].outputList[0];
                currentNode.choice3 = false;
            }
            HideChoices(listOfChoices);
            lastDialogue = currentNode.dialogueName;
            StartCoroutine(StartText(nextDialogue, nextDialogue.waitTime));



        } 
        
        
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
        }
    }
    /*
    IEnumerator FadeToBlack() {
        RawImage faderObj = fader.GetComponent<RawImage>();
        Color color = faderObj.color;
        for (float i = 0; i < 1; i = i + 0.02f) {
            color.a = i;
            faderObj.color = color;
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator FadeToScreen() {
        RawImage faderObj = fader.GetComponent<RawImage>();
        Color color = faderObj.color;
        for (float i = 1; i > 0; i = i - 0.02f) {
            color.a = i;
            faderObj.color = color;
            yield return new WaitForSeconds(0.02f);
        }
    } */    
}

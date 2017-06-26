using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DialogueNode : BaseInputNode {

    public DialogueNode inputNode;
    private Rect inputNodeRect;
    private string input1Title = "None";

    public DialogueSettings container = new DialogueSettings();

    public int orderNumber;
    public float waitTillNext;
    
    public Vector2 positionInWindow;
    private bool startDialogue;
    private bool choiceDialogue;
    private bool option1, option2, option3;


    public DialogueNode () {
        if(container.isChoice) {
            windowTitle = "Choice Node";
        } else {
            windowTitle = "Dialogue Node";
        }
        
        hasInputs = true;

    }

    public override void DrawWindow() {
        //base.DrawWindow();
        container.dialogueName = EditorGUILayout.TextField(container.dialogueName);
        container.positionInWindows = positionInWindow;


        Event e = Event.current;
            input1Title = container.nodeInput;

        GUILayout.Label("Input 1: " + input1Title, EditorStyles.boldLabel);
        if(container.outputList.Count == 0) {
            GUILayout.Label("Output: ");
        } else {
            GUILayout.Label("Output: " + container.outputList[0]);
        }
        

        if (e.type == EventType.Repaint) {
            inputNodeRect = GUILayoutUtility.GetLastRect();
        }
        
        if (container.isTrigger) {
            container.triggerType = (DialogueSettings.TriggerType)EditorGUILayout.EnumPopup(container.triggerType);
            if (container.triggerType == DialogueSettings.TriggerType.FadeIn) {
                container.triggerFunction = "FadeIn";
            } else if (container.triggerType == DialogueSettings.TriggerType.FadeOut) {
                container.triggerFunction = "FadeOut";
            } else if (container.triggerType == DialogueSettings.TriggerType.PreloadWithFadeIn) {
                container.triggerFunction = "PreloadWithFadeIn";
            } else if (container.triggerType == DialogueSettings.TriggerType.PreloadWithFadeOut) {
                container.triggerFunction = "PreloadWithFadeOut";
            } else if (container.triggerType == DialogueSettings.TriggerType.PreloadWithFadeInAndOut) {
                container.triggerFunction = "PreloadWithFadeInAndOut";
            } else if (container.triggerType == DialogueSettings.TriggerType.Preload) {
                container.triggerFunction = "Preload";
            } else if (container.triggerType == DialogueSettings.TriggerType.StopMovement) {
                container.triggerFunction = "StopMovement";
            } else if (container.triggerType == DialogueSettings.TriggerType.StartMovement) {
                container.triggerFunction = "StartMovement";
            } else if (container.triggerType == DialogueSettings.TriggerType.StartDistortionEffect) {
                container.triggerFunction = "StartDistortionEffect";
            } else if (container.triggerType == DialogueSettings.TriggerType.StopDistortionEffect) {
                container.triggerFunction = "StopDistortionEffect";
            } else if (container.triggerType == DialogueSettings.TriggerType.PreloadCrash) {
                container.triggerFunction = "PreloadCrash";
            } else if (container.triggerType == DialogueSettings.TriggerType.PreloadFromCrash) {
                container.triggerFunction = "PreloadFromCrash";
            }
            container.waitTime = EditorGUILayout.FloatField(container.waitTime);    
        } else if (container.isChoice == false) {

        
            

            container.dialogueType = (DialogueSettings.DialogueType)EditorGUILayout.EnumPopup("Dialogue Type : ", container.dialogueType);
            if (container.dialogueType == DialogueSettings.DialogueType.Text) {
                container.dialogueText = EditorGUILayout.TextArea(container.dialogueText, GUILayout.Width(150), GUILayout.Height(50));
                container.waitTime = EditorGUILayout.FloatField(container.waitTime);
            } else if (container.dialogueType == DialogueSettings.DialogueType.Character) {
                container.characterList = (DialogueSettings.CharacterType)EditorGUILayout.EnumPopup("Character : ", container.characterList);

                switch (container.characterList) {
                    case DialogueSettings.CharacterType.Avaline:
                        container.character = "Avaline";
                        break;
                    case DialogueSettings.CharacterType.Computer:
                        container.character = "Computer";
                        break;
                    case DialogueSettings.CharacterType.Sam:
                        container.character = "Sam";
                        break;
                    case DialogueSettings.CharacterType.Doctor:
                        container.character = "Doctor";
                        break;
                    case DialogueSettings.CharacterType.Nurse:
                        container.character = "Nurse";
                        break;
                    case DialogueSettings.CharacterType.UncleDavid:
                        container.character = "Uncle David";
                        break;
                    case DialogueSettings.CharacterType.Tracy:
                        container.character = "Tracy";
                        break;
                    case DialogueSettings.CharacterType.Unknown:
                        container.character = "???";
                        break;
                    case DialogueSettings.CharacterType.Empty:
                        container.character = "";
                        break;

                }



            } else if (container.dialogueType == DialogueSettings.DialogueType.Audio ) {

                container.fmodVoiceOver = EditorGUILayout.TextField(container.fmodVoiceOver);

                //container.voiceOver = EditorGUILayout.ObjectField(container.voiceOver, typeof(AudioClip), false) as AudioClip;
            }
        } else {
            container.dialogueText = EditorGUILayout.TextArea(container.dialogueText, GUILayout.Width(150), GUILayout.Height(25));
            
        }
        if(GUILayout.Button("")) {
            container.outputList = new List<DialogueSettings>();
        }
        EditorGUILayout.LabelField(container.orderNumber + container.orderString);
        
    }

    public int getOrder() {
        return orderNumber;
    }

    public override void SetInput(DialogueNode input, Vector2 clickPos) {
        if (input is DialogueNode) {
            clickPos.x -= windowRect.x;
            clickPos.y -= windowRect.y;

            if (inputNodeRect.Contains(clickPos)) {

                if(container.outputList.Contains(container)) {

                } else {
                    input.container.hasOutput = true;
                    input.container.outputList.Add(container);
                    
                    input.container.amountOfOutputs = input.container.outputList.Count;

                    input1Title = input.container.dialogueName;
                    container.nodeInput = input1Title;

                    inputNode = input;
                }
                

                if (container.isChoice) {
                    container.orderNumber = input.container.orderNumber + 1;
                    container.orderString = input.container.orderString + "-" + input.container.amountOfOutputs;
                    
                } else {
                    container.orderNumber = input.container.orderNumber + 1;
                    container.orderString = input.container.orderString;
                }

            }
        }

    }

    public override DialogueNode ClickedOnInput(Vector2 pos) {
        DialogueNode retVal = null;

        pos.x -= windowRect.x;
        pos.y -= windowRect.y;

        if (inputNodeRect.Contains(pos)) {
            retVal = inputNode;
            inputNode = null;
        }
            return retVal;
    }

    public override void DrawCurves() {
        if (inputNode) {
            Rect rect = windowRect;
            rect.x += inputNodeRect.x;
            rect.y += inputNodeRect.y + inputNodeRect.height / 2;
            rect.width = 1;
            rect.height = 1;

            NodeEditor.DrawNodeCurve(inputNode.windowRect, rect);
        }



    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NodeEditor : EditorWindow {

    public List<DialogueNode> windows = new List<DialogueNode>();

    public List<DialogueSettings> windowsOrdered = new List<DialogueSettings>();

    private CharacterStorySettings[] storiesInCharacter = new CharacterStorySettings[10];

    private CharacterStorySettings characterStory;

    private CharacterStorySettings lastStory = null;
    private GameObject lastObject;

    private Vector2 mousePos;
    private bool existingListCheck;
    private DialogueNode selectedNode;

    private CharacterStorySettings[] amountOfDialogues;
    private int selected = 0;
    private string[] selections;

    private bool makeTransistionMode = false;

    private System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

    [MenuItem("Window/Node Editor")]

    static void ShowEditor() {
        NodeEditor editor = EditorWindow.GetWindow<NodeEditor>();
    }


    private void Update() {

        long dTime = stopwatch.ElapsedMilliseconds;
        float deltaTime = ((float)dTime) / 1000;

        foreach (BaseNode b in windows) {
            if(b is DialogueNode) {
                DialogueNode d = b as DialogueNode;
                d.positionInWindow = d.windowRect.position;
            }
            
        }

        stopwatch.Reset();
        stopwatch.Start();

        Repaint();
    }


    private void OnGUI() {
        Event e = Event.current;
        mousePos = e.mousePosition;
        

        if (Selection.activeGameObject) {
            Selection.activeGameObject.name = EditorGUILayout.TextField("Object Name: ", Selection.activeGameObject.name);

        } else if (Selection.activeGameObject == null) {
            GUILayout.Label("No object was selected");
        }

    
        if (Selection.activeGameObject.GetComponent<CharacterStorySettings>() != null) {
            if (storiesInCharacter == null) {
                selected = 0;
                storiesInCharacter = Selection.activeGameObject.GetComponents<CharacterStorySettings>();
                characterStory = storiesInCharacter[selected];

            }

            if (lastObject != Selection.activeGameObject) {
                lastObject = Selection.activeGameObject;
                selected = 0;
                storiesInCharacter = Selection.activeGameObject.GetComponents<CharacterStorySettings>();
                characterStory = storiesInCharacter[selected];
                
            }

            if (lastStory != storiesInCharacter[selected]) {
                lastStory = storiesInCharacter[selected];
                characterStory = storiesInCharacter[selected];
                windows = new List<DialogueNode>();
                foreach (DialogueSettings d in characterStory.MyList) {
                    DialogueNode dialogueNode = new DialogueNode();
                    dialogueNode.windowRect = new Rect(d.positionInWindows.x, d.positionInWindows.y, 200, 200);
                    dialogueNode.container = d;
                    windows.Add(dialogueNode);
                    
                }foreach (DialogueNode diaNode in windows) {
                    DialogueSettings d = diaNode.container;
                    for (int b = 0; b < d.outputList.Count; b++) {
                        for (int i = 0; i < windows.Count; i++) {
                            if (d.outputList[b].dialogueName == windows[i].container.dialogueName) {
                                d.outputList[b] = windows[i].container;
                                break;
                            }
                        }
                    }
                    
                }
                characterStory.MyList = new List<DialogueSettings>();
                for (int i = 0; i < windows.Count; i++) {
                    characterStory.MyList.Add(windows[i].container);
                }                
                /* foreach (DialogueNode d in windows) {
                    if (d.container.nodeInput != "") {
                        foreach (DialogueNode dN in windows) {
                            Debug.Log("Ik zit in de for loop");
                        if(dN.container.dialogueName == d.container.nodeInput) {
                                Debug.Log("Ik ben gelijk");
                                DrawNodeCurve(d.windowRect, dN.windowRect);
                                Repaint();
                            }                               
                        
                        }
                        foreach (DialogueNode n in windows) {
                            n.DrawCurves();
                        }


                    }
                }*/
            }


            amountOfDialogues = Selection.activeGameObject.GetComponents<CharacterStorySettings>();
            ReplaceList();
            selected = EditorGUILayout.Popup(selected, selections);
            if (GUILayout.Button("Add to List", GUILayout.Width(100))) {
                windowsOrdered = new List<DialogueSettings>();
                foreach (DialogueNode b in windows) {
                    if (windowsOrdered.Count == 0) {
                        windowsOrdered.Add(b.container);
                    } else if (windowsOrdered.Count == 1) {
                        if (windowsOrdered[0].orderNumber > b.container.orderNumber) {
                            windowsOrdered.Insert(0, b.container);
                        } else {
                            windowsOrdered.Add(b.container);
                        }
                    } else if (windowsOrdered.Count > 1){
                        int i = 0;
                        bool done = false;

                        while (done == false) {
                            if (windowsOrdered[i].orderNumber >= b.container.orderNumber) {
                                windowsOrdered.Insert(i, b.container);
                                done = true;
                            } else if (i < windowsOrdered.Count - 1) {
                                i++;
                            } else {
                                windowsOrdered.Add(b.container);
                                done = true;
                            }
                        }

                    }
                }
                storiesInCharacter[selected].MyList = windowsOrdered;
            }



            EditorGUILayout.LabelField(windows.Count.ToString());
            EditorGUILayout.LabelField(Selection.activeGameObject.GetComponent<CharacterStorySettings>().MyList.Count.ToString());
            foreach (DialogueSettings b in Selection.activeGameObject.GetComponent<CharacterStorySettings>().MyList) {
                EditorGUILayout.LabelField(b.orderNumber.ToString());
            }

            if (e.button == 1 && !makeTransistionMode) {
                if (e.type == EventType.MouseDown) {
                    bool clickedOnWindow = false;
                    int selectedIndex = -1;

                    for (int i = 0; i < windows.Count; i++) {
                        if (windows[i].windowRect.Contains(mousePos)) {
                            selectedIndex = i;
                            clickedOnWindow = true;
                            break;
                        }
                    }
                    if (!clickedOnWindow) {
                        GenericMenu menu = new GenericMenu();
                        menu.AddItem(new GUIContent("Add Dialogue Node"), false, ContextCallback, "dialogueNode");
                        menu.AddItem(new GUIContent("Add Choice Node"), false, ContextCallback, "choiceNode");
                        menu.AddItem(new GUIContent("Add Tirgger Node"), false, ContextCallback, "triggerNode");

                        menu.ShowAsContext();
                        e.Use();
                    } else {
                        GenericMenu menu = new GenericMenu();

                        menu.AddItem(new GUIContent("Add Transition"), false, ContextCallback, "makeTransition");
                        menu.AddSeparator(" ");
                        menu.AddItem(new GUIContent("Delete Node"), false, ContextCallback, "deleteNode");

                        menu.ShowAsContext();
                        e.Use();

                    }

                }
            } else if (e.button == 0 && e.type == EventType.MouseDown && makeTransistionMode) {
                bool clickedOnWindow = false;
                int selectedIndex = -1;
                for (int i = 0; i < windows.Count; i++) {
                    if (windows[i].windowRect.Contains(mousePos)) {
                        selectedIndex = i;
                        clickedOnWindow = true;
                        break;
                    }
                }
                if (clickedOnWindow && !windows[selectedIndex].Equals(selectedNode)) {
                    windows[selectedIndex].SetInput(selectedNode, mousePos);
                    makeTransistionMode = false;
                    selectedNode = null;
                }

                if (!clickedOnWindow) {
                    makeTransistionMode = false;
                    selectedNode = null;
                }

                e.Use();
            } else if (e.button == 0 && e.type == EventType.MouseDown && !makeTransistionMode) {
                bool clickedOnWindow = false;
                int selectedIndex = -1;

                for (int i = 0; i < windows.Count; i++) {
                    if (windows[i].windowRect.Contains(mousePos)) {
                        selectedIndex = i;
                        clickedOnWindow = true;
                        DialogueNode dialogueNode = windows[selectedIndex] as DialogueNode;
                        dialogueNode.positionInWindow = windows[selectedIndex].windowRect.position;
                        break;
                    }
                }
                if (clickedOnWindow) {
                    DialogueNode nodeToChange = windows[selectedIndex].ClickedOnInput(mousePos);
                    if (nodeToChange != null) {

                        nodeToChange.container.outputList.Remove(windows[selectedIndex].container);
                        selectedNode = nodeToChange;
                        makeTransistionMode = true;
                    }
                }
            }
            if (makeTransistionMode && selectedNode != null) {
                Rect mouseRect = new Rect(e.mousePosition.x, e.mousePosition.y, 10, 10);
                DrawNodeCurve(selectedNode.windowRect, mouseRect);
                Repaint();
            }
            foreach (BaseNode n in windows) {
                n.DrawCurves();
            }



            BeginWindows();
            for (int i = 0; i < windows.Count; i++) {
                windows[i].windowRect = GUI.Window(i, windows[i].windowRect, DrawNodeWindow, windows[i].windowTitle);
            }

            EndWindows();
        }
    }
        


    void DrawNodeWindow(int id) {
        windows[id].DrawWindow();
        GUI.DragWindow();
    }

    void ContextCallback(object obj) {
        string clb = obj.ToString();

        if (clb.Equals("dialogueNode")) {
            DialogueNode dialogueNode = new DialogueNode();
            dialogueNode.windowRect = new Rect(mousePos.x, mousePos.y, 200, 200);
            dialogueNode.container.dialogueName = "Untitled" + characterStory.MyList.Count;
            characterStory.MyList.Add(dialogueNode.container);

            windows.Add(dialogueNode);
        } else if (clb.Equals("choiceNode")) {
            DialogueNode dialogueNode = new DialogueNode();
            dialogueNode.windowRect = new Rect(mousePos.x, mousePos.y, 200, 110);
            dialogueNode.container.dialogueName = "Untitled" + characterStory.MyList.Count;
            characterStory.MyList.Add(dialogueNode.container);
            dialogueNode.container.isChoice = true;

            windows.Add(dialogueNode);

        } else if (clb.Equals("triggerNode")) {
            DialogueNode dialogueNode = new DialogueNode();
            dialogueNode.windowRect = new Rect(mousePos.x, mousePos.y, 200, 110);
            dialogueNode.container.dialogueName = "Untitled" + characterStory.MyList.Count;
            characterStory.MyList.Add(dialogueNode.container);
            dialogueNode.container.isTrigger = true;

            windows.Add(dialogueNode);
        } 
        
        else if (clb.Equals("makeTransition")) {
            bool clickedOnWindow = false;
            int selectedIndex = -1;

            for (int i = 0; i < windows.Count; i++) {
                if (windows[i].windowRect.Contains(mousePos)) {
                    selectedIndex = i;
                    clickedOnWindow = true;
                    break;
                }
            }
            if (clickedOnWindow) {
                selectedNode = windows[selectedIndex];
                makeTransistionMode = true;
            }
        } else if (clb.Equals("deleteNode")) {
            bool clickedOnWindow = false;
            int selectedIndex = -1;

            for (int i = 0; i < windows.Count; i++) {
                if (windows[i].windowRect.Contains(mousePos)) {
                    selectedIndex = i;
                    clickedOnWindow = true;
                    break;
                }
            }
            if (clickedOnWindow) {
                BaseNode selNode = windows[selectedIndex];
                windows.RemoveAt(selectedIndex);

                foreach (BaseNode n in windows) {
                    n.NodeDeleted(selNode);
                }
                if (selNode is DialogueNode) {
                    DialogueNode selDiaNode = selNode as DialogueNode;
                    foreach (DialogueSettings d in characterStory.MyList) {
                        if(selDiaNode.container.dialogueName == d.dialogueName && selDiaNode.container.orderNumber == d.orderNumber) {
                            foreach (DialogueSettings diaSet in characterStory.MyList) {
                                if (diaSet.dialogueName == d.nodeInput) {
                                    diaSet.outputList.Remove(d);
                                }
                            }
                            characterStory.MyList.Remove(d);
                            
                            break;
                        }
                    }
                }
            }
        }
    }
    
    public static void DrawNodeCurve( Rect start, Rect end) {

        Vector3 startPos = new Vector3(start.x + start.width / 2, start.y + start.height / 2, 0);
        Vector3 endPos = new Vector3(end.x + end.width / 2, end.y + end.height / 2, 0);
        Vector3 startTan = startPos + Vector3.right * 50;
        Vector3 endTan = endPos + Vector3.left * 50;
        Color shadowCol = new Color(0, 0, 0, 0.6f);

        for (int i = 0; i < 3; i++) {
            Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, null, 0.3f);
        }
        Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.black, null, 1);

    }

    private void CheckForExistingList() {
        
    }

    private void ReplaceList() {
        int arraySize = 0;
        foreach (CharacterStorySettings c in amountOfDialogues) {
            arraySize++;
        }
        selections = new string[arraySize];
        for (int i = 0; i < arraySize; i++) {
            selections[i] = amountOfDialogues[i].dialogueName;
        }
    }
}


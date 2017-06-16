using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStorySettings : MonoBehaviour{


    public List<DialogueSettings> MyList = new List<DialogueSettings>(1);
    public string dialogueName = "";
   

    void AddNew() {
        //Add a new index position to the end of our list
        MyList.Add(new DialogueSettings());
    }

    void Remove(int index) {
        //Remove an index position from our list at a point in our list array
        MyList.RemoveAt(index);
    }


}

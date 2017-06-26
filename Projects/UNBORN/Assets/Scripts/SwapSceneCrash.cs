using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapSceneCrash : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.N)) {
            StartCoroutine(PreloadCrash());
        }
		
	}

    IEnumerator PreloadCrash() {
        int currentLevel = 5;
        AsyncOperation async = SceneManager.LoadSceneAsync(currentLevel);
        async.allowSceneActivation = false;
        while (!async.isDone) {
            if (async.progress == 0.9f) {
                yield return new WaitForSeconds(2);
                async.allowSceneActivation = true;
            }
        }
    }
}

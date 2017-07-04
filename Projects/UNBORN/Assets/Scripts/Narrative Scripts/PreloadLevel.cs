using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PreloadLevel : MonoBehaviour {

    AsyncOperation async;

    public static IEnumerator PreloadWithFadeInAndOut() {
        int currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
        AsyncOperation async = SceneManager.LoadSceneAsync(currentLevel);
        async.allowSceneActivation = false;
        GameObject faderObject = GameObject.FindGameObjectWithTag("Fader");
        RawImage fader = faderObject.GetComponent<RawImage>();
        Color color = fader.color;
        for (float i = 0; i < 1; i = i + 0.02f) {
            color.a = i;
            fader.color = color;
            yield return new WaitForSeconds(0.02f);
        }
        while (!async.isDone) {
            if (async.progress == 0.9f) {
                yield return new WaitForSeconds(2);
                async.allowSceneActivation = true;
            }
        }
        for (float i = 1; i > 0; i = i - 0.02f) {
            color.a = i;
            fader.color = color;
            yield return new WaitForSeconds(0.02f);
        }

    }

    public static IEnumerator PreloadWithFadeOut() {
        int currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
        AsyncOperation async = SceneManager.LoadSceneAsync(currentLevel);
        async.allowSceneActivation = false;
        GameObject faderObject = GameObject.FindGameObjectWithTag("Fader");
        RawImage fader = faderObject.GetComponent<RawImage>();
        Color color = fader.color;
        while (!async.isDone) {
            if (async.progress == 0.9f) {
                yield return new WaitForSeconds(2);
                async.allowSceneActivation = true;
            }
        }
        for (float i = 1; i > 0; i = i - 0.02f) {
            color.a = i;
            fader.color = color;
            yield return new WaitForSeconds(0.02f);
        }

    }

    public static IEnumerator PreloadWithFadeIn() {
        int currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
        AsyncOperation async = SceneManager.LoadSceneAsync(currentLevel);
        async.allowSceneActivation = false;
        GameObject faderObject = GameObject.FindGameObjectWithTag("Fader");
        RawImage fader = faderObject.GetComponent<RawImage>();
        Color color = fader.color;
        for (float i = 0; i < 1; i = i + 0.02f) {
            color.a = i;
            fader.color = color;
            yield return new WaitForSeconds(0.02f);
        }
        while (!async.isDone) {
            if (async.progress == 0.9f) {
                yield return new WaitForSeconds(2);
                async.allowSceneActivation = true;
            }
        }
    }

    public static IEnumerator Preload() {
        int currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
        AsyncOperation async = SceneManager.LoadSceneAsync(currentLevel);
        async.allowSceneActivation = false;
        while (!async.isDone) {
            if (async.progress == 0.9f) {
                yield return new WaitForSeconds(2);
                async.allowSceneActivation = true;
            }
        }
    }


    public static IEnumerator PreloadCrashScene() {
        int currentLevel = 9;
        AsyncOperation async = SceneManager.LoadSceneAsync(currentLevel);
        async.allowSceneActivation = false;
        while (!async.isDone) {
            if (async.progress == 0.9f) {
                yield return new WaitForSeconds(2);
                async.allowSceneActivation = true;
            }
        }
    }

    public static IEnumerator PreloadFromCrashScene() {
        int currentLevel = 5;
        AsyncOperation async = SceneManager.LoadSceneAsync(currentLevel);
        async.allowSceneActivation = false;
        GameObject faderObject = GameObject.FindGameObjectWithTag("Fader");
        RawImage fader = faderObject.GetComponent<RawImage>();
        Color color = fader.color;
        while (!async.isDone) {
            if (async.progress == 0.9f) {
                yield return new WaitForSeconds(2);
                async.allowSceneActivation = true;
            }
        }
        for (float i = 1; i > 0; i = i - 0.02f) {
            color.a = i;
            fader.color = color;
            yield return new WaitForSeconds(0.02f);
        }

    }

    public static IEnumerator SwitchToCredits() {
        int currentLevel = 10;
        AsyncOperation async = SceneManager.LoadSceneAsync(currentLevel);
        async.allowSceneActivation = false;
        GameObject faderObject = GameObject.FindGameObjectWithTag("Fader");
        RawImage fader = faderObject.GetComponent<RawImage>();
        Color color = fader.color;
        while (!async.isDone) {
            if (async.progress == 0.9f) {
                yield return new WaitForSeconds(2);
                async.allowSceneActivation = true;
            }
        }
        for (float i = 1; i > 0; i = i - 0.02f) {
            color.a = i;
            fader.color = color;
            yield return new WaitForSeconds(0.02f);
        }

    }
}

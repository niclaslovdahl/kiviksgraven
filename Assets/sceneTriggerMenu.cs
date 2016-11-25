using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class sceneTriggerMenu : MonoBehaviour {

    public GameObject fader;

    private AsyncOperation scene;

    void Start() {
        scene = SceneManager.LoadSceneAsync("Grave", LoadSceneMode.Single);
        scene.allowSceneActivation = false;
    }

    void OnTriggerEnter(Collider other) {
        StartCoroutine(sceneChange());
    }

    IEnumerator sceneChange() {
        iTween.FadeTo(fader, 1f, 5f);
        yield return new WaitForSeconds(5);
        scene.allowSceneActivation = true;
    }
}

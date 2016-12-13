using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    public float duration = 1.0F;
    public Light light;
    private bool changeLight = false;
    private AsyncOperation scene;

    public AudioClip sound2;
    public GameObject procession;
    public GameObject whiteFader;
    public GameObject blackFader;

    void Start() {
        iTween.FadeTo(procession, 0.0f, 0.0f);
        StartCoroutine(Example());


        scene = SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
        scene.allowSceneActivation = false;

    }

    void FixedUpdate() {
        if (changeLight) {

            light.intensity += 0.02F;

        }

    }




    IEnumerator Example() {
        yield return new WaitForSeconds(10);
        iTween.FadeTo(procession, 1.0f, 4.0f);


        yield return new WaitForSeconds(110);

        changeLight = true;

        yield return new WaitForSeconds(2);
        iTween.FadeTo(procession, 0.0f, 2.0f);
        yield return new WaitForSeconds(2);

        iTween.FadeTo(blackFader, 1f, 2f);

        yield return new WaitForSeconds(6);
        scene.allowSceneActivation = true;


    }

}

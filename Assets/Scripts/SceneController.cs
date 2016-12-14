using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Light light;
    public GameObject VRbox;
    public AudioClip sound2;
    public GameObject procession;
    public GameObject fader;

    private bool changeLight = false;
    private AsyncOperation scene;
    private bool moveBox = true;
    private float boxSpeed = 0.03f;
    private Transform boxTransform;

    void Start()
    {
        boxTransform = VRbox.transform;
        iTween.FadeTo(procession, 0.0f, 0.0f);
        StartCoroutine(sceneHandler());
        StartCoroutine(flyIn());

        scene = SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
        scene.allowSceneActivation = false;

    }

    void FixedUpdate()
    {
        if (changeLight)
        {
            light.intensity += 0.02F;
        }

        if (moveBox)
        {
            boxTransform.Translate(boxSpeed, 0, 0, Space.Self);
        }

    }


    IEnumerator sceneHandler()
    {
        yield return new WaitForSeconds(10);
        iTween.FadeTo(procession, 1.0f, 4.0f);

        yield return new WaitForSeconds(110);

        changeLight = true;

        yield return new WaitForSeconds(2);
        iTween.FadeTo(procession, 0.0f, 2.0f);
        yield return new WaitForSeconds(2);

        iTween.FadeTo(fader, 1f, 2f);

        yield return new WaitForSeconds(6);
        scene.allowSceneActivation = true;

    }

    IEnumerator flyIn()
    {
        yield return new WaitForSeconds(6);
        iTween.FadeTo(fader, 1f, 2f);
        yield return new WaitForSeconds(2);
        moveBox = false;
        VRbox.transform.position = new Vector3(965.36f, 0f, 781.06f);
        iTween.FadeTo(fader, 0f, 2f);
    }
}

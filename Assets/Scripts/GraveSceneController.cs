using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GraveSceneController : MonoBehaviour {

	public AudioClip sound2;
	public GameObject trigger;
	public GameObject procession;
	private bool fadeOut = false;
    private AsyncOperation scene;



    void Start () {

		iTween.FadeTo (procession, 0.0f, 0.0f);
		PlaySource1();
        trigger.SetActive(false);
        StartCoroutine(SceneHandler());

        scene = SceneManager.LoadSceneAsync("First", LoadSceneMode.Single);
        scene.allowSceneActivation = false;


    }

    public void ChangeScene()
    {
        scene.allowSceneActivation = true;
    }

    IEnumerator SceneHandler()
    {
        yield return new WaitForSeconds(30);
        trigger.SetActive(true);
    }





    public void PlaySource1() {

		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();



	}

	public void PlaySource2() {

		AudioSource audio = GetComponent<AudioSource> ();

		audio.clip = sound2;
		audio.Play ();
		audio.loop = false;


	}




}

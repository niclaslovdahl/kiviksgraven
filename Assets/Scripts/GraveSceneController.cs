using UnityEngine;
using System.Collections;

public class GraveSceneController : MonoBehaviour {

	public AudioClip sound2;
	//public GameObject trigger;
	public GameObject procession;



	void Start () {

		iTween.FadeTo (procession, 0.0f, 0.0f);
		PlaySource1();


	}
		

	void PlaySource1() {

		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();



	}

	public void PlaySource2() {

		AudioSource audio = GetComponent<AudioSource> ();

		audio.clip = sound2;
		audio.Play ();


	}


}

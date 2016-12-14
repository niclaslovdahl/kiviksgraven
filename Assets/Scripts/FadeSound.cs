using UnityEngine;
using System.Collections;

public class FadeSound : MonoBehaviour {

	private AudioSource sound;
	private bool fadeOut = false;

	void Start () {
		sound = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (fadeOut) {
			sound.volume -= 0.05F;
		}
	
	}

	public void FadeOut() {

		fadeOut = true;

	}

}

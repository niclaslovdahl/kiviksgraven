
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private GameObject hmd;

	private float timeBeforeStart = 1.0f;


	// Use this for initialization
	void Start () {

		hmd = GameObject.Find ("Camera (eye)");

	}

	// Update is called once per frame
	void Update () {

		Vector3 pos = new Vector3 (hmd.transform.position.x, hmd.transform.position.y / 2, hmd.transform.position.z); 
		transform.position = pos;
		Vector3 scale = new Vector3 (transform.localScale.x, hmd.transform.position.y, transform.localScale.z);
		transform.localScale = scale;

		//transform.position.y = hmd.transform.position.y / 2;
		//transform.position.z = hmd.transform.position.z;
		//transform.localScale = hmd.transform.position.y;

	}

	void OnTriggerEnter(Collider other) {

		//debug:
		Debug.Log("Kollision!");

		AudioSource fx = other.gameObject.GetComponent<AudioSource> ();
		fx.Play ();

		StartCoroutine(FadeInCollider (other, 1.0f));

	}


	IEnumerator FadeInCollider(Collider other, float fadeTime) {
		Color oldColor = other.gameObject.transform.GetChild (0).GetComponent<SkinnedMeshRenderer> ().material.color;

		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeTime) {
			Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, Mathf.Lerp(oldColor.a, 1.0f, t));
			other.gameObject.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.color = newColor;
			yield return null;
		}

		yield return new WaitForSeconds(timeBeforeStart);

		Animator animator = other.gameObject.GetComponent<Animator>();
		//animator.Play ("followerLandskapLoop"); //varför funkar inte denna?
		animator.enabled = true;

	}


}
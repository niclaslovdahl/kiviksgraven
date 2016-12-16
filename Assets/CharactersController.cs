using UnityEngine;
using System.Collections;

public class CharactersController : MonoBehaviour {

	public float walkingTime;
	public float waitTime;

	// Use this for initialization
	void Start () {
		//StartCoroutine(WalkingTimer ());

	}
	
	// Update is called once per frame
	void Update () {
	
	}



	IEnumerator WalkingTimer () {
		yield return new WaitForSeconds (walkingTime);
		int children = transform.childCount;
		for (int i = 0; i < children; ++i) {
			MovementController controller = this.gameObject.transform.GetChild (i).GetComponent<MovementController> ();
			controller.walking = false;
			controller.rotateCounterClockwise = true;
		}


		//yield break; //behövs denna?
	}
}

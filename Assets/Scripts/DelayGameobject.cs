using UnityEngine;
using System.Collections;

public class DelayGameobject : MonoBehaviour {

	void Start () {
		if (gameObject.activeInHierarchy)
			gameObject.SetActive(false);

		StartCoroutine(LateCall());
	}

	IEnumerator LateCall()
	{
		//Wait for 5 sec
		yield return new WaitForSeconds(5);

		gameObject.SetActive(true);

	}


}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		print ("it works");
		SceneManager.LoadScene ("First");

	}


}

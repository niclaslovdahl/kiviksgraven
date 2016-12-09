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

    void Start() {
		//scene = SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
		//scene.allowSceneActivation = false;
		iTween.FadeTo (procession, 0.0f, 0.0f);
		StartCoroutine(Example());
		
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

		yield return new WaitForSeconds(4);
		iTween.FadeTo (procession, 0.0f, 2.0f);

		yield return new WaitForSeconds(4);
		//scene.allowSceneActivation = true;
	

	}

}

using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
	public float duration = 1.0F;
	public Light light;
	private bool changeLight = false;

	public AudioClip sound2;
	public GameObject procession;

    void Start() {

		iTween.FadeTo (procession, 0.0f, 0.0f);
		StartCoroutine(Example());
		
    }

    void FixedUpdate() {
		if (changeLight) {

			float phi = Time.time / duration * 2 * Mathf.PI;
			float amplitude = Mathf.Cos(phi) * 0.5F + 0.5F;
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
	

	}

}

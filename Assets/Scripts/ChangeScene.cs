using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public GameObject footsteps;
    private bool test = false;

	public GameObject graveStone;
	public Material stone2;
	public GameObject procession;
    private AsyncOperation scene;

    void Start() {
        scene = SceneManager.LoadSceneAsync("First", LoadSceneMode.Single);
        scene.allowSceneActivation = false;
    }

    void OnTriggerEnter(Collider other) {
        StartCoroutine(Example());
  
	}

    void FixedUpdate() {
        if(test) {
            RenderSettings.fogDensity += 0.00005F;
        }
    }

    IEnumerator Example() {
        yield return new WaitForSeconds(1);
        footsteps.SetActive(false);


//        yield return new WaitForSeconds(2);
//		graveStone.GetComponent <MeshRenderer> ().material = stone2;


		yield return new WaitForSeconds(2);

		iTween.FadeTo (procession, 1.0f, 2.0f);


		yield return new WaitForSeconds(6);
		test = true;
        yield return new WaitForSeconds(8);
        test = false;
        scene.allowSceneActivation = true;

    }


}

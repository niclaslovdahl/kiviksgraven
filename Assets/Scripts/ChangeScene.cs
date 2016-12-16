using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public GameObject footsteps;
    public GameObject trigger;
    public GameObject fader;
    private bool test = false;
//  private bool faderBool = true;
	public static bool changeSound = false;

    public GameObject graveStone;
    public Material stone2;
    public GameObject procession;
    //private AsyncOperation scene;

	//public GameObject sceneController;

    void Start() {
        //scene = SceneManager.LoadSceneAsync("First", LoadSceneMode.Single);
        //scene.allowSceneActivation = false;
        iTween.FadeTo(fader, 0f, 5f);
	
    }
		

    void OnTriggerEnter(Collider other) {
		
		//Change sound file in SceneManager
		GameObject.Find ("SceneManager").GetComponent<GraveSceneController> ().PlaySource2 ();

        GetComponent<BoxCollider>().enabled = false;


		StartCoroutine(Example());


    }

    void FixedUpdate() {
        if (test) {
            RenderSettings.fogDensity += 0.00002F;
        }
    }

    IEnumerator Example() {
		
		yield return new WaitForSeconds(1);
        footsteps.SetActive(false);


        //        yield return new WaitForSeconds(2);
        //		graveStone.GetComponent <MeshRenderer> ().material = stone2;


        yield return new WaitForSeconds(2);

        iTween.FadeTo(procession, 1.0f, 2.0f);


        yield return new WaitForSeconds(10);
        test = true;
        yield return new WaitForSeconds(2);
        iTween.FadeTo(fader, 1f, 5f);
        yield return new WaitForSeconds(3);
		GameObject.Find ("WindSound").GetComponent<FadeSound> ().FadeOut ();
		yield return new WaitForSeconds(2);
        test = false;
        //scene.allowSceneActivation = true;
        GameObject.Find("SceneManager").GetComponent<GraveSceneController>().ChangeScene();

    }


}

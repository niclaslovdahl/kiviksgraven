using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public GameObject footsteps;
    private bool test = false;

    void OnTriggerEnter(Collider other) {
        StartCoroutine(Example());
  
	}

    void Update() {
        if(test) {
            RenderSettings.fogDensity += 0.00005F;
        }
    }

    IEnumerator Example() {
        yield return new WaitForSeconds(1);
        footsteps.SetActive(false);
        yield return new WaitForSeconds(2);
        test = true;

        yield return new WaitForSeconds(5);
        test = false;
        SceneManager.LoadScene("First");

    }


}

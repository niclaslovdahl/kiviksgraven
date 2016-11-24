using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class sceneTrigger : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        RenderSettings.fogDensity += 0.00005F;
    }

    void OnTriggerEnter(Collider other) {
        StartCoroutine(sceneChange());
    }

    IEnumerator sceneChange() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Grave");
    }
}

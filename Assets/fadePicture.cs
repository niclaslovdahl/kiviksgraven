using UnityEngine;
using System.Collections;

public class fadePicture : MonoBehaviour {

    private GameObject footstep;

    // Use this for initialization
    void Start() {
        footstep = GameObject.FindGameObjectWithTag("test");
        footstep.SetActive(false);
        fadeMenu();
        StartCoroutine(footsteps());
    }

    // Update is called once per frame
    void Update() {

    }

    void fadeMenu() {
        GameObject[] menu = GameObject.FindGameObjectsWithTag("menuobjects");

        foreach (GameObject go in menu) {
            iTween.FadeTo(go, 0f, 3f);
        }

    }

    IEnumerator footsteps() {
        Debug.Log("before");
        yield return new WaitForSeconds(3);
        Debug.Log("after");
        footstep.SetActive(true);
    }
}

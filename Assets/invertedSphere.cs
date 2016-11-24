using UnityEngine;
using System.Collections;
using System.Linq;
public class invertedSphere : MonoBehaviour {

    // Use this for initialization
    void Start() {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.triangles = mesh.triangles.Reverse().ToArray();
        iTween.FadeTo(this.gameObject, 0f, 10f);
    }

    // Update is called once per frame
    void Update() {

    }
}

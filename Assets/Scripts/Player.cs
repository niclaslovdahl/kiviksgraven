
using UnityEngine;
using System.Collections;

/**
 * This script creates a player trigger collider for the HTC Vive head. Automatically imports needed components and values.
 */

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    private GameObject hmd;

    // Use this for initialization
    void Start() {
        GetComponent<CapsuleCollider>().radius = 0.16f;
        GetComponent<CapsuleCollider>().isTrigger = true;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        hmd = GameObject.Find("Camera (eye)");
    }

    // Update is called once per frame
    void Update() {

        Vector3 pos = new Vector3(hmd.transform.position.x, hmd.transform.position.y / 2, hmd.transform.position.z);
        transform.position = pos;
        Vector3 scale = new Vector3(transform.localScale.x, hmd.transform.position.y, transform.localScale.z);
        transform.localScale = scale;

    }
}
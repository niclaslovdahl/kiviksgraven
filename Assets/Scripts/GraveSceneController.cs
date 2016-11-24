using UnityEngine;
using System.Collections;

public class GraveSceneController : MonoBehaviour {


	public GameObject procession;


	void Start () {

		iTween.FadeTo (procession, 0.0f, 0.0f);

	}
	

	void Update () {
	
	}
}

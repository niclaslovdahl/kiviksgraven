using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {



	void Start () {
		

		RenderSettings.fogDensity = 0.01F;

	}
	

	void Update () {
		
		FogFadeOut ();
	}


	void FogFadeOut() {
		if (RenderSettings.fogDensity > 0.001F) {

			RenderSettings.fogDensity -= 0.00005F;
		}

	}




}

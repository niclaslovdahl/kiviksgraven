using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {



	void Start () {
		

		RenderSettings.fogDensity = 0.05F;

	}
	

	void FixedUpdate () {
		
		FogFadeOut ();
	}


	void FogFadeOut() {
		if (RenderSettings.fogDensity > 0.001F) {

			RenderSettings.fogDensity -= 0.0002F;
		}

	}




}

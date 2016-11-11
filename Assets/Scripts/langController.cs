using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//
//	1) In your scene you should have controllers attached to the camera rig, eg:
//	[CameraRig]
//	-- Controller (Left)
//
//	2) Ensure that controller has both a "SteamVR_TrackedObject" script AND "SteamVR_TrackedController" script
//
//	3) Add this script to the controller, and modify it as necessary
//
[RequireComponent (typeof(SteamVR_TrackedController))]
public class langController : MonoBehaviour
{

	public GameObject sweFlag;
	public GameObject bwSweFlag;
	public GameObject engFlag;
	public GameObject bwEngFlag;

	private bool lang = true; // true is swedish

	// Use this for initialization
	void OnEnable ()
	{
		SteamVR_TrackedController controller = GetComponent<SteamVR_TrackedController> ();
		controller.TriggerClicked += OnClickTrigger;
		controller.TriggerUnclicked += OnUnclickTrigger;
		controller.PadClicked += OnPadClicked;
	}

	void OnDisable ()
	{
		SteamVR_TrackedController controller = GetComponent<SteamVR_TrackedController> ();
		controller.TriggerClicked -= OnClickTrigger;
		controller.TriggerUnclicked -= OnUnclickTrigger;
		controller.PadClicked -= OnPadClicked;
	}

	void OnPadClicked (object sender, ClickedEventArgs e)
	{
		Debug.Log ("Pad Clicked! X: " + e.padX + " " + e.padY);
		sweFlag.SetActive (!sweFlag.activeSelf);
		bwSweFlag.SetActive (!bwSweFlag.activeSelf);
		engFlag.SetActive (!engFlag.activeSelf);
		bwEngFlag.SetActive (!bwEngFlag.activeSelf);
		lang = !lang;

		if (lang) {
			Debug.Log ("Swedish!");
		} else {
			Debug.Log ("English!");
		}
	}


	void OnUnclickTrigger (object sender, ClickedEventArgs e)
	{
		Debug.Log ("Unclicked trigger!");
	}

	void OnClickTrigger (object sender, ClickedEventArgs e)
	{
		Debug.Log ("Clicked trigger!");
		SceneManager.LoadScene ("test");
	}

}
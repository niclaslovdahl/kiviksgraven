using UnityEngine;
using System.Collections;
//
//	1) In your scene you should have controllers attached to the camera rig, eg:
//	[CameraRig]
//	-- Controller (Left)
//
//	2) Ensure that controller has both a "SteamVR_TrackedObject" script AND "SteamVR_TrackedController" script
//
//	3) Add this script to the controller, and modify it as necessary
//
[RequireComponent(typeof(SteamVR_TrackedController))]
public class ControllerManager : MonoBehaviour {

    // Use this for initialization
    void OnEnable() {
        SteamVR_TrackedController controller = GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += OnClickTrigger;
        controller.TriggerUnclicked += OnUnclickTrigger;
        controller.PadClicked += OnPadClicked;
    }

    void OnDisable() {
        SteamVR_TrackedController controller = GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked -= OnClickTrigger;
        controller.TriggerUnclicked -= OnUnclickTrigger;
        controller.PadClicked -= OnPadClicked;
    }

    void OnPadClicked(object sender, ClickedEventArgs e) {
        Debug.Log("Pad Clicked! X: " + e.padX + " " + e.padY);
    }

    void OnUnclickTrigger(object sender, ClickedEventArgs e) {
        Debug.Log("Unclicked trigger!");
    }

    void OnClickTrigger(object sender, ClickedEventArgs e) {
        Debug.Log("Clicked trigger!");
    }

}
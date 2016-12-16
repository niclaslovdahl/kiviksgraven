using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

	public Transform rightCurveCenter;
	public Transform leftCurveCenter;

	Transform hips;
	Transform hipsParent;
	Transform rotationDummy;

	float prevHipsLocalPositionZ;
	float positionDelta;

	float rotationAngle;
	float totalRotationAngle;

	string movementState;
	string direction;

	bool firstColliderEntered = false;
	bool secondColliderEntered = false;

	public bool walking = false;
	public bool rotateClockwise = false;
	public bool rotateCounterClockwise = false;


	int frame = 0;


	void Start () {

		hips = this.gameObject.transform.GetChild (0).GetChild (0).GetChild (1).GetChild (0);
		hipsParent = this.gameObject.transform.GetChild (0).GetChild (0);
		rotationDummy = this.gameObject.transform.GetChild (0);
		
		movementState = "walking";
		direction = "forward";

	}
		

	void Update () {

		frame++;



		//print ("frame " + frame + ": prev hips localPosition = " + prevHipsLocalPositionZ);
		//print ("hips position:" + hips.position);
		//print ("hipsParent position:" + hipsParent.position);

		MoveOnSpot ();


		switch (movementState) {
			case "walking":
				//Debug.Log ("walking!");
				WalkPath ();
				break;
			case "rotateClockwise":
				//Debug.Log ("rotateClockwise!");
				totalRotationAngle += rotationAngle;
				if (totalRotationAngle < 360.0f) {  //fixa!
					RotateClockwise ();
				} else {
					rotateClockwise = false;
					totalRotationAngle = 0;
				}
				break;
			case "rotateCounterClockwise":
				//Debug.Log ("rotateCounterClockwise!");
				totalRotationAngle += rotationAngle;
				if (totalRotationAngle < 120.0f) {  //fixa!
					RotateCounterClockwise ();
				} else {
					rotateCounterClockwise = false;
					totalRotationAngle = 0;
				}
				break;
		}


		//print ("frame " + frame + ": hips localPosition = " + hips.localPosition.z);
		//print ("frame " + frame + ": hipsParent localPosition = " + hipsParent.localPosition.z);
		//print ("frame " + frame + ": this localPosition = " + this.gameObject.transform.localPosition.x);



	}


	void MoveOnSpot () {
		
		Vector3 hipsLocalPosition = hips.localPosition;
		Vector3 hipsParentLocalPosition = new Vector3 (0, 0, -hipsLocalPosition.z);
		hipsParent.localPosition = hipsParentLocalPosition;

		positionDelta = hipsLocalPosition.z - prevHipsLocalPositionZ; //anv ej local

		if (Mathf.Abs(positionDelta) > 10.0f) {
			positionDelta = 0.002f;
		}

		prevHipsLocalPositionZ = hipsLocalPosition.z;
	}


	void WalkPath () {

		switch (direction) {
			case "right":
				//Debug.Log ("right!");
				this.gameObject.transform.LookAt (rightCurveCenter);
				this.gameObject.transform.Translate (-positionDelta, 0, 0);
				break;
			case "left":
				//Debug.Log ("left!");
				this.gameObject.transform.LookAt (leftCurveCenter);

			//print ("frame " + frame + ": positionDelta = " + positionDelta);

				this.gameObject.transform.Translate (positionDelta, 0, 0);
				break;
			case "forward":
				//Debug.Log ("forward!");
				this.gameObject.transform.Translate (positionDelta, 0, 0);
				break;
		}

	}


	void RotateClockwise() {
		rotationAngle = positionDelta / (2 * Mathf.PI) * 360;
		this.gameObject.transform.GetChild (0).Rotate (new Vector3 (0, rotationAngle, 0));
		totalRotationAngle = this.gameObject.transform.GetChild (0).localEulerAngles.y;
	}


	void RotateCounterClockwise() {
		rotationAngle = positionDelta / (2 * Mathf.PI) * 360;
		this.gameObject.transform.GetChild (0).Rotate (new Vector3 (0, -rotationAngle, 0));
		totalRotationAngle = this.gameObject.transform.GetChild (0).localEulerAngles.y;
	}

	void walkClockwise () {
		//rotateCounterClockwise = true;

	}

	void walkCounterClockwise () {
		//rotateClockwise = true;
	}


	void OnTriggerEnter(Collider other) {
		//print (other.gameObject.name);
		if (other.gameObject.name == "secondCollider" && !secondColliderEntered) {
			//print ("secondCollider!");
			direction = "left";
			rotationDummy.localEulerAngles = new Vector3 (0, 90.0f, 0);
		} else if (other.gameObject.name == "firstCollider" && !firstColliderEntered) {
			//print ("firstCollider!");
			direction = "right";
			rotationDummy.localEulerAngles = new Vector3 (0, -90.0f, 0);
		}
	}

}

using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour {

	public const float MINANGLETOLERANCE = 5f;
	public const float ROTATIONFACTOR = 2f;
	public const float MAXANGVEL = 75f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 10;

		Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

		float deltaX = transform.position.x - mouseWorldPos.x;
		float deltaY = transform.position.y - mouseWorldPos.y;

		float wantedAngle = (Mathf.Atan2 (-deltaX, deltaY) * (180.0f / Mathf.PI)) + 180;

		float currentAngle = transform.eulerAngles.z;

		float angleDifference = wantedAngle - currentAngle;

		float absAngleDiff = Mathf.Abs (angleDifference);

		//Set angle to be smallest angle to mouse
		if (absAngleDiff > 180) {
			angleDifference = angleDifference < 0 ? angleDifference + 360 : angleDifference - 360;
		}

		//Set velocity to move towards mouse if angle is large enough
		if (absAngleDiff > MINANGLETOLERANCE) {
			float angleVel = Mathf.Min(absAngleDiff, MAXANGVEL);

			angleVel = angleDifference < 0 ? -angleVel : angleVel;

			rigidbody2D.angularVelocity = angleVel * ROTATIONFACTOR;
		}


	
	}
}

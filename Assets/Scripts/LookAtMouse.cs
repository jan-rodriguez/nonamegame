using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

		float deltaX = transform.position.x - mousePos.x;
		float deltaY = transform.position.y - mousePos.y;

		float wantedAngle = Mathf.Atan2 (deltaY, deltaX);

		Debug.Log (wantedAngle);

		//rigidbody2D.AddTorque (wantedAngle);
	
	}
}

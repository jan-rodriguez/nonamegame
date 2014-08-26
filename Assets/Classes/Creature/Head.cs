using UnityEngine;
using System.Collections;

public class Head : BodyPart {

	private HingeJoint2D torsoJoint;

	// Use this for initialization
	void Awake () {
		//Define torso joint
		torsoJoint = this.GetComponent<HingeJoint2D> ();
	}

	//Connect the head to torso
	public void AttachTorso(GameObject torso) {
		//Attach torso joint
		torsoJoint.connectedBody = torso.rigidbody2D;
	}
}
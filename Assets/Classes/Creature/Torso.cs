using UnityEngine;
using System.Collections;

public class Torso : BodyPart {

	private HingeJoint2D connectingHingeJoint;

	// Use this for initialization
	void Awake () {
		connectingHingeJoint = gameObject.GetComponent<HingeJoint2D> ();
	}

	public void attachBodyPart (GameObject bodyPart) {
		connectingHingeJoint.connectedBody = bodyPart.rigidbody2D;
		//Give joint offset from the connected body's height
		float spriteHeight = bodyPart.collider2D.renderer.bounds.size.y;
		Vector2 newConnectPos = new Vector2(0, 11 * (spriteHeight / 40.0f));
		connectingHingeJoint.connectedAnchor = newConnectPos;
	}
}
using UnityEngine;
using System.Collections;

public class CreateCreture : MonoBehaviour {

	public GameObject head;
	public GameObject torso;

	// Use this for initialization
	void Start () {

		//Generate head and torso and set them as child object to this
		head = (GameObject)Instantiate(head);
		head.transform.parent = gameObject.transform;

		torso = (GameObject)Instantiate (torso);
		torso.transform.parent = gameObject.transform;

		head.GetComponent<Head> ().AttachTorso (torso);
		this.GetComponent<HingeJoint2D> ().connectedBody = head.rigidbody2D;
	}
}
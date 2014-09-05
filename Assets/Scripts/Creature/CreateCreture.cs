using UnityEngine;
using System.Collections;

public class CreateCreture : MonoBehaviour {

	public GameObject[] headList;
	public GameObject[] torsoList;
	public GameObject[] tailList;

	// Use this for initialization
	void Start () {

		//Generate head and torso and set them as child object to this
		GameObject randomHead = headList [Random.Range(0, headList.Length)];
		GameObject head = (GameObject)Instantiate(randomHead);
		head.transform.parent = gameObject.transform;

		GameObject randomTorso = torsoList [Random.Range (0, torsoList.Length)];
		GameObject torso = (GameObject)Instantiate (randomTorso);
		torso.transform.parent = gameObject.transform;

		GameObject randomTail = tailList [Random.Range (0, tailList.Length)];
		GameObject tail = (GameObject)Instantiate (randomTail);
		tail.transform.parent = gameObject.transform;

		head.GetComponent<Head> ().AttachTorso (torso);
		torso.GetComponent<Torso> ().attachBodyPart (tail);
		this.GetComponent<HingeJoint2D> ().connectedBody = head.rigidbody2D;
	}
}
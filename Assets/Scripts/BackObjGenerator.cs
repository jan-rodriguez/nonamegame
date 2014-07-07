using UnityEngine;
using System.Collections;

public class BackObjGenerator : MonoBehaviour {

	public const float GENERATEPERCENTAGE = 2f;
	public Transform bubble;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.Range (0f, 100.0f) < GENERATEPERCENTAGE) {
			//Create a bubble and set the background to be the parent
			Transform newObj = (Transform)Instantiate(bubble);
			newObj.transform.parent = transform;
		}
	}
}

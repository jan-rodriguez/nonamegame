using System.Collections;
using UnityEngine;

public class Bubble : BackgroundImage
{

	private const float _MAXFLOATSPEED = .05f;
	private const float _MINFLOATSPEED = .01f;

	private float _FLOATSPEED;

	new void Start () {
		base.Start ();

		_FLOATSPEED = Random.Range (_MINFLOATSPEED, _MAXFLOATSPEED);
	}

	new void Update () {
		FloatUp ();
	} 

	private void FloatUp() {
		this.transform.Translate (new Vector3 (0, _FLOATSPEED));
	}
	
}


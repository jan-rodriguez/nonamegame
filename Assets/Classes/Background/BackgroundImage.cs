using UnityEngine;
using System.Collections;

public class BackgroundImage : MonoBehaviour {

	//CONSTANTS
	protected const float _MAXVIEWDISTANCE = 30F;
	protected const float _MINVIEWDISTANCE = 7f;
	protected const float _DESTROYTIMER = 2f;
	protected const float _SIDEBUFFER = 0.5f;

	public static Transform player;

	protected bool _isVisible = false;
	protected float _viewDistance;


	// Use this for initialization
	protected void Start () {

		//Only define the player's transform once
		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player").transform;
		}

		this._viewDistance = Random.Range (_MINVIEWDISTANCE, _MAXVIEWDISTANCE);

		Vector3 pos;
		float xPos;
		float yPos;

		bool vertical = Random.Range (0f, 1.0f) > .5f;

		//Bubble spawn in the top or bottom
		if (vertical) {
			xPos = Random.Range (0f, 1.0f);
			yPos = Random.Range (0f, 1.0f) > .5f ? -.1f : 1.1f;
		}else{ //Bubble spawns in right or left side
			xPos = Random.Range (0f, 1.0f) > .5f ? -.1f : 1.1f;
			yPos = Random.Range (0f, 1.0f);
		}

		pos = Camera.main.ViewportToWorldPoint(new Vector3(xPos, yPos, this._viewDistance));

		this.transform.position = pos;

		//Destoy if spawned outside of camera and not visible
		StartCoroutine (DelayedDestroyObject());
	
	}
	
	// Update is called once per frame
	protected void Update () {}

	//Kill bubbles when they become invisible
	public void OnBecameInvisible () {
		this._isVisible = false;
		StartCoroutine (DelayedDestroyObject());
	}

	//Make object visible again when it return to screen to not be destroyed
	public void OnBecameVisible () {
		this._isVisible = true;
	}

	//Destoy the game object if it is not visible after a short amount of time
	protected IEnumerator DelayedDestroyObject () {
		yield return new WaitForSeconds (_DESTROYTIMER);
		if (!this._isVisible) {
			GameObject.Destroy (gameObject);
		}
		yield return null;
	}
}

using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]

public class Player : Creature
{

	private Rigidbody2D rigidBody;
	private float movementMultiplier = 10f;

	public override void Start () {
		//Initialize health
		this._health = Creature._maxHealth;

		rigidBody = this.GetComponent<Rigidbody2D> ();
	}

	new public void Update () {

		float speed = base.GetSpeed ();

		//Sets previous x and y position
		base.Update ();

		bool atMaxSpeed = speed > _MAXSPEED;
	
		//Below maximum speed, update movements
		if (!atMaxSpeed) {
			float xInp = Input.GetAxis ("Horizontal");
			float yInp = Input.GetAxis ("Vertical");
			if (xInp != 0) {
				rigidBody.AddForce(new Vector2(xInp * movementMultiplier, 0));
			}
			if (yInp != 0) {
				rigidBody.AddForce(new Vector2(0, yInp * movementMultiplier));
			}
		}

	}

	protected override void Attack() {}

	protected override void Die () {}


}
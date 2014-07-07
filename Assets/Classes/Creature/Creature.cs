/*
 * CREATURE CLASS
 * 
 * Base class for player and all enemies in the game.
 * 
 * The creature is an evolvable entity that attacks other creatures to
 * inherit or gather other creatures power ups.
 */
using UnityEngine;
using System.Collections;

public abstract class Creature : MonoBehaviour {


	protected const int _maxHealth = 10;
	protected int _health = 10;
	protected const float _MAXSPEED = .1f;
	protected float prevX = 0;
	protected float prevY = 0;
	protected ArrayList _adaptations = new ArrayList();

	// Use this for initialization
	abstract public void Start ();
	
	// Update is called once per frame
	public void Update () {
		this.prevX = this.transform.position.x;
		this.prevY = this.transform.position.y;
	}

	abstract protected void Die ();

	abstract protected void Attack ();

	public void TakeDamage(int amount) {
		_health -= amount;
		
		if (_health <= 0) {
			this.Die();
		}
	}

	public float GetSpeed() {
		float curX = this.transform.position.x;
		float curY = this.transform.position.y;

		return Mathf.Sqrt (Mathf.Pow((prevX - curX), 2) + Mathf.Pow((prevY - curY), 2));
	}
}

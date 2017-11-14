using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Control : MonoBehaviour {

	public float maxSpd = 10f;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float stunDuration;
	public bool nudged;
	public bool stunned;
	public Rigidbody2D rb2d;

	public int health = 10;

	private float nextFire;
	private float stunTime;
	private float nudgeTime;

	// Update is called once per frame
	void FixedUpdate () {
		if (!stunned) {
			//Take position of ship
			Vector3 pos = transform.position;

			//Vertical movement of ship
			pos.y += maxSpd * Time.deltaTime * Input.GetAxis ("Vertical_P2");

			//Horizontal movement of ship
			pos.x += maxSpd * Time.deltaTime * Input.GetAxis ("Horizontal_P2");

			//Change position
			transform.position = pos;
		}
	}

	// Checking hitting something
	void OnTriggerEnter2D(Collider2D col){
		if (!(col.CompareTag ("Wall"))) {
			if ((col.CompareTag ("Enemy") && (health > 1)) || (col.CompareTag("HazardToP2"))) {
				Debug.Log ("tes");
				health--;	
			}
			if (col.CompareTag ("Enemy")){
				NudgeShip ();
				stunned = true;
				nudged = true;
				stunTime = Time.time + stunDuration;
				nudgeTime = Time.time + 0.1f;
			}
		}
	}

	void NudgeShip(){
		rb2d.AddForce (new Vector2(-50f,20f));
	}

	// Destroy game	
	void Destroyed(){
		Destroy (gameObject);
	}


	void Update(){
		if (Input.GetButton ("Shoot_P2") && Time.time > nextFire) {
			Debug.Log ("schut");
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}

		if (stunned) {
			if (Time.time > stunTime) {
				stunned = false;
			}
			if (Time.time > nudgeTime) {
				nudged = false;
				rb2d.velocity = Vector2.zero;
			}
		}

		if (health <= 0) {
			Destroyed();
		}
	}
}

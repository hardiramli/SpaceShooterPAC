using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Control : MonoBehaviour {

	public float maxSpd = 10f;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float stunDuration;
	public bool stunned;

	public int health = 1;

	private float nextFire;
	private float stunTime;

	// Update is called once per frame
	void FixedUpdate () {
		if (!stunned) {
			//Take position of ship
			Vector3 pos = transform.position;

			//Vertical movement of ship
			pos.y += maxSpd * Time.deltaTime * Input.GetAxis ("Vertical_P1");

			//Horizontal movement of ship
			pos.x += maxSpd * Time.deltaTime * Input.GetAxis ("Horizontal_P1");

			//Change position
			transform.position = pos;
		}
	}

	// Checking hitting something
	void OnTriggerEnter2D(Collider2D col){
		if (!(col.CompareTag ("Wall"))) {
			if ((col.CompareTag ("Enemy") && (health > 1)) || (col.CompareTag("HazardToP1"))) {
				Debug.Log ("tes");
				health--;	
			}
			if (col.CompareTag ("Enemy")){
				stunned = true;
				stunTime = Time.time + stunDuration;
			}
		}
	}

	// Destroy game	
	void Destroyed(){
		Destroy (gameObject);
	}

	
	void Update(){
		if (Input.GetButton ("Shoot_P1") && Time.time > nextFire) {
			Debug.Log ("schut");
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}

		if (stunned && Time.time > stunTime) {
			stunned = false;
		}

		if (health <= 0) {
			Destroyed();
		}
	}
}

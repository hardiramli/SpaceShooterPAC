using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Control : MonoBehaviour {

	float maxSpd = 10f;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	// Update is called once per frame
	void FixedUpdate () {
		//Take position of ship
		Vector3 pos = transform.position;

		//Vertical movement of ship
		pos.y += maxSpd * Time.deltaTime * Input.GetAxis("Vertical_P2");

		//Horizontal movement of ship
		pos.x += maxSpd * Time.deltaTime * Input.GetAxis("Horizontal_P2");

		//Change position
		transform.position = pos;
	}

	void Update(){
		if (Input.GetButton ("Shoot_P2") && Time.time > nextFire) {
			Debug.Log ("schut");
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

}

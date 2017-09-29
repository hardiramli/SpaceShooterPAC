using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float maxSpd = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate () {
		//Take position of ship
		Vector3 pos = transform.position;

		//Horizontal movement of ship
		pos.x -= maxSpd * Time.deltaTime;


		//Change position
		transform.position = pos;

	}

}

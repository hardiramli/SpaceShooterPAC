using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	public float maxSpd = 10f;

	public int health = 1;

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log("tes");
		health--;	
	}

	void Update(){
		if (health <= 0) {
			Destroyed();
		}
	}

	void Destroyed(){
		Destroy (gameObject, 0.1f);
	}

	void FixedUpdate () {
		//Take position of ship
		Vector3 pos = transform.position;

		//Horizontal movement of ship
		pos.x += maxSpd * Time.deltaTime;

		//Change position
		transform.position = pos;

		if (pos.x >= 20f) {
			Destroy (this.gameObject);
			Debug.Log ("destroyed");
		}
	}


}

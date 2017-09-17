using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageHandler : MonoBehaviour {

	public int health = 1;

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("BulletPlayer")) {
			Debug.Log("tes");
			health--;	
		}
	}

	void Update(){
		if (health <= 0) {
			Destroyed();
		}
	}

	void Destroyed(){
		Destroy (gameObject);
	}
}

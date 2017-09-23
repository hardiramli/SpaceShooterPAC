using UnityEngine;
using System.Collections;

public class BulletDamageHandler : MonoBehaviour {

	public int health = 1;

	void OnTriggerEnter2D(Collider2D col){
		if (!(col.CompareTag ("Wall"))) {
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
		Destroy (gameObject,0.1f);
	}
}

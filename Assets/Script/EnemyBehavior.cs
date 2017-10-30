using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

	public int health = 4;
	public GameObject hazardtoP1;
	public GameObject hazardtoP2;
	public bool special;

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("BulletPlayer")||col.CompareTag ("BulletPlayer2")) {
			Debug.Log("tes");
			health--;	
		}
		if (col.CompareTag("Destroyer")){
			Destroyed ();
		}
	}

	//TODO create if destroyed gain energy

	void SpawnHazard(){
		if (this.transform.position.y >= 0) {
			Instantiate (hazardtoP2, this.transform.position, this.transform.rotation);
		} else if (this.transform.position.y < 0) {
			Instantiate (hazardtoP1, this.transform.position, this.transform.rotation);
		}
	}

	void Update(){
		if (health <= 0) {
			Destroyed();
			if (special) {
				SpawnHazard();
			}
		}
	}

	void Destroyed(){
		OnDestroy ();
		Destroy (gameObject);
	}

	private void OnDestroy ()
	{
		if (transform.parent != null) // if object has a parent
		{
			if (transform.childCount <= 1) // if this object is the last child
			{
				Destroy (transform.parent.gameObject, 0.1f); // destroy parent a few frames later
			}
		}
	}
}

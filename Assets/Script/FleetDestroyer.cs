using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 pos = transform.position;

		if (pos.x <= -20f) {
			Destroy (this.gameObject);
			Debug.Log ("destroyed");
		}
	}
}

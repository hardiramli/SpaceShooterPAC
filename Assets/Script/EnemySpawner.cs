using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] fleet;
	public float spawnTime;

	private float timeLeft;

	// Use this for initialization
	void Start () {
		timeLeft = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeLeft <= 0) {
			CreateFleet ();
			timeLeft = spawnTime;
			Debug.Log("spawn enemy");
		}
		timeLeft -= Time.deltaTime;
	}

	void CreateFleet(){
		int rand = (int)Mathf.Floor (Random.Range (0.0f, fleet.Length));
		Instantiate (fleet [rand], this.transform.position, this.transform.rotation);
	}
}

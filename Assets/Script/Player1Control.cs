using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Control : MonoBehaviour {

	public float maxSpd = 10f;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float stunDuration;
	public float immuneDuration;
	public bool nudged;
	public bool stunned;
	public bool immune;
	public Rigidbody2D rb2d;
	public Text debugHealth;
	public Text debugSuper;

	public int super;
	public int health = 5;

	private float nextFire;
	private float stunTime;
	private float nudgeTime;
	private float immuneTime;

	// Update is called once per frame
	void FixedUpdate () {
		if (immune) {
			gameObject.layer = 19;
		} else
		{
			gameObject.layer = 8;
			//gameObject.layer = 9 buat p2
		}
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
		SetHealth ();
		SetSuper ();
	}

	// Checking hitting something
	void OnTriggerEnter2D(Collider2D col){
		if (!(col.CompareTag ("Wall"))) {
			if ((col.CompareTag("HazardToP1"))) {
				if(!immune){
					Debug.Log ("tes");
					health--;
					SetHealth ();
					stunned = true;
					immune = true;
					stunTime = Time.time + stunDuration;
					immuneTime = Time.time + immuneDuration;
				//ganti layer jadi immune tembus
				//become immune few seconds
				}
			}
			if (col.CompareTag ("Enemy")){
				if (!stunned && (health > 1)) {
					health--;
					SetHealth ();
				}
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

	void SetHealth(){
		debugHealth.text = "health = "+health.ToString();
	}

	void SetSuper(){
		debugSuper.text = "super = "+super.ToString();
	}

	public void addSuper(int n){
		super += n;
		SetSuper ();
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

		if (stunned) {
			if (Time.time > stunTime) {
				stunned = false;
			}
			if (Time.time > nudgeTime) {
				nudged = false;
				rb2d.velocity = Vector2.zero;
			}
		}

		if (immune) {
			if (Time.time > immuneTime) {
				immune = false;
			}
		}

		if (health <= 0) {
			Destroyed();
		}
	}
}

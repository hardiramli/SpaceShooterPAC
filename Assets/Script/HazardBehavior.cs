using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardBehavior : MonoBehaviour {

	public Vector2 ballMaxSpeed;
	public Rigidbody2D rb2D;
	public float velocityMultiplier;
	public float speedX;
	public float speedY;
	public GameObject meteor;

	void Start() {
		rb2D = GetComponent<Rigidbody2D>();
		rb2D.velocity = new Vector2 (speedX, speedY);
	}

	void FixedUpdate() {
		float currentXVelocity = rb2D.velocity.x;
		float maxYSpeed = rb2D.velocity.y;
		if(Mathf.Abs(rb2D.velocity.y) < maxYSpeed)
		{
			if(rb2D.velocity.y <= 0)
			{
				rb2D.velocity = new Vector2(currentXVelocity, -maxYSpeed);
			}
			else
			{
				rb2D.velocity = new Vector2(currentXVelocity, maxYSpeed);
			}
		}
		//rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (!(col.CompareTag ("Wall"))) {
			if (col.CompareTag ("BulletPlayer")){
				Instantiate (meteor, this.transform.position, this.transform.rotation);
				Destroy (gameObject);
			}
			if (col.CompareTag ("BulletPlayer2")){
				Instantiate (meteor, this.transform.position, this.transform.rotation);
				Destroy (gameObject);
			}
		}
	}
		
}

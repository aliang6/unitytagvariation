using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour {

	private float QCOOLDOWN = 10.0f;
	private float ECOOLDOWN = 10.0f;

	public float speed;
	private int tagCount;
	private Rigidbody2D rb2d;
	private float qCooldownTimer, eCooldownTimer;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		tagCount = 0;
	}

	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal2");
		float moveVertical = Input.GetAxis ("Vertical2");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement);
		if (Input.GetKey (KeyCode.Q) && qCooldownTimer <= 0) {
			rb2d.AddForce (movement * 3, ForceMode2D.Impulse);
			qCooldownTimer= QCOOLDOWN;
		}
		if (Input.GetKey (KeyCode.E) && eCooldownTimer <= 0) {
			Vector3 velocity = rb2d.velocity;
			rb2d.velocity *= -1;
			eCooldownTimer= ECOOLDOWN;
		}
	}	

	void Update () {
		qCooldownTimer-= Time.deltaTime;
		eCooldownTimer-= Time.deltaTime;
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	private float ENTERCOOLDOWN = 10.0f;
	private float SHIFTCOOLDOWN = 10.0f;

	public float speed;
	public Rigidbody2D rb2d2;
	public UnityEngine.UI.Text speedText;

	private bool collide;
	private int tagCount;
	private Rigidbody2D rb2d;

	private float enterCooldownTimer, shiftCooldownTimer;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		tagCount = 0;
		speedText.text = ((int)(rb2d.velocity.magnitude)).ToString();
		collide = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement);

		if ((Input.GetKey (KeyCode.Return) ||
			Input.GetKey (KeyCode.KeypadEnter)) 
			&& enterCooldownTimer <=0) {
			rb2d.AddForce (movement * 3, ForceMode2D.Impulse);
			enterCooldownTimer= ENTERCOOLDOWN;
		}
		if (Input.GetKey (KeyCode.RightShift) && shiftCooldownTimer <= 0) {
			Vector3 velocity = rb2d.velocity;
			rb2d.velocity *= -1;
			shiftCooldownTimer= SHIFTCOOLDOWN;
		}

		speedText.text = ((int)(rb2d.velocity.magnitude)).ToString();
	}

	void Update () {
		enterCooldownTimer-= Time.deltaTime;
		shiftCooldownTimer-= Time.deltaTime;
	}

	/*void OnCollisionEnter (Rigidbody2D rdbd2) {
		
	} */

}

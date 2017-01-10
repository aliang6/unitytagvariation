using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : Player {

	private float ENTERCOOLDOWN = 2.0f;
	private float SHIFTCOOLDOWN = 2.0f;
	private float SLASHCOOLDOWN = 3.0f;
	private float IMMUNEDURATION = 1.0f;

	public UnityEngine.UI.Text enterCooldown, shiftCooldown, rotation;

	private float enterCooldownTimer, shiftCooldownTimer, slashCooldownTimer;

	private float direction; 


	// Use this for initialization
	void Start () {

		base.Start();

		enterCooldown.text = enterCooldownTimer.ToString ();
		shiftCooldown.text = shiftCooldownTimer.ToString ();
		rotation.text = rb2d.rotation.ToString ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		/*float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);*/

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (0, moveVertical);

		if (Input.GetKey (KeyCode.UpArrow)) {
			rb2d.AddForce (transform.up * speed);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			rb2d.rotation -= 180 * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			rb2d.rotation += 180 * Time.deltaTime;
		}
			
		if (Input.GetKey (KeyCode.RightShift) && shiftCooldownTimer <= 0){
			immune = true;
			rb2d.AddForce (transform.up * 5, ForceMode2D.Impulse);
			immuneCooldownTimer = IMMUNEDURATION;
			shiftCooldownTimer= SHIFTCOOLDOWN;
		}
		if ((Input.GetKey (KeyCode.Return) ||
			Input.GetKey (KeyCode.KeypadEnter)) 
			&& enterCooldownTimer <=0)  {
			Vector3 velocity = rb2d.velocity;
			rb2d.velocity *= 0;
			rb2d.AddForce (transform.up * -3, ForceMode2D.Impulse);
			enterCooldownTimer= ENTERCOOLDOWN;

		}
	
		if (Input.GetKey(KeyCode.Slash) && slashCooldownTimer <=0){
			GameObject projObj = Instantiate(Resources.Load("Projectile") as GameObject, rb2d.transform.position, rb2d.transform.rotation);
			projObj.GetComponent<Rigidbody2D>().velocity = rb2d.velocity;
			slashCooldownTimer= SLASHCOOLDOWN;
		}

		base.FixedUpdate();

	}

	
	void Update () {
		

		if (enterCooldownTimer <= 0) {
			enterCooldownTimer = 0;
		}
		else {
			enterCooldownTimer -= Time.deltaTime;
		}

		if (shiftCooldownTimer <= 0) {
			shiftCooldownTimer = 0;
		}
		else {
			shiftCooldownTimer -= Time.deltaTime;
		}

		if (slashCooldownTimer <= 0) {
			slashCooldownTimer = 0;
		} 
		else {
			slashCooldownTimer -= Time.deltaTime;
		}

		if (immuneCooldownTimer <= 0) {
			immune = false;
			immuneCooldownTimer = 0;
		} 
		else {
			immuneCooldownTimer -= Time.deltaTime;
		}
		rotation.text = rb2d.rotation.ToString ();
		enterCooldown.text = (Mathf.CeilToInt(enterCooldownTimer)).ToString ();
		shiftCooldown.text = (Mathf.CeilToInt(shiftCooldownTimer)).ToString ();
	}
		
	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Player" && immune == false) {
			tagCount++;
			other.rigidbody.velocity = new Vector2(0,0);
			rb2d.AddForce (other.rigidbody.velocity, ForceMode2D.Impulse);
		}
		tagNumber.text = tagCount.ToString ();
	} 

	//Direction functions===============================================

	//==================================================================
}

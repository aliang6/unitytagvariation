using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : Player {

	private float ENTERCOOLDOWN = 2.0f;
	private float SHIFTCOOLDOWN = 2.0f;
	private float SLASHCOOLDOWN = 3.0f;
	private float IMMUNEDURATION = 1.0f;
	/*
	public float speed;
	public Rigidbody2D rb2d2;
	public UnityEngine.UI.Text speedText,*/
	public UnityEngine.UI.Text enterCooldown, shiftCooldown;//, tagNumber;
/*
	public Rigidbody2D projectile;

	private bool immune;
	private int tagCount;
	private Rigidbody2D rb2d;
*/
	//private float immuneCooldownTimer, 
	private float enterCooldownTimer, shiftCooldownTimer, slashCooldownTimer;


	// Use this for initialization
	void Start () {
		/*
		rb2d = GetComponent<Rigidbody2D> ();
		tagCount = 0;
		immune = false;
		tagNumber.text = tagCount.ToString ();
		speedText.text = (Mathf.CeilToInt(rb2d.velocity.magnitude)).ToString();
		*/
		base.Start();
		enterCooldown.text = enterCooldownTimer.ToString ();
		shiftCooldown.text = shiftCooldownTimer.ToString ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);

		if ((Input.GetKey (KeyCode.Return) ||
			Input.GetKey (KeyCode.KeypadEnter)) 
			&& enterCooldownTimer <=0) {
			immune = true;
			rb2d.AddForce (movement * 5, ForceMode2D.Impulse);
			immuneCooldownTimer = IMMUNEDURATION;
			enterCooldownTimer= ENTERCOOLDOWN;
		}
		if (Input.GetKey (KeyCode.RightShift) && shiftCooldownTimer <= 0) {
			Vector3 velocity = rb2d.velocity;
			rb2d.velocity *= -1;
			shiftCooldownTimer= SHIFTCOOLDOWN;
		}
		if (Input.GetKey(KeyCode.Slash) && slashCooldownTimer <=0){
			//Instantiate (projectile, rb2d.transform.position, rb2d.transform.rotation);
			Rigidbody2D proj = Instantiate (projectile, rb2d.transform.position, rb2d.transform.rotation);
			proj.SendMessage("Shoot",rb2d.velocity);
			slashCooldownTimer= SLASHCOOLDOWN;
		}
		base.FixedUpdate();
		//speedText.text = (Mathf.CeilToInt(rb2d.velocity.magnitude)).ToString();
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
}

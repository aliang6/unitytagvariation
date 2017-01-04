using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Movement : MonoBehaviour {

	private float QCOOLDOWN = 2.0f;
	private float ECOOLDOWN = 2.0f;
	private float RCOOLDOWN = 3.0f;
	private float IMMUNEDURATION = 1.0f;

	public Rigidbody2D projectile;
	public float speed;
	public Rigidbody2D rb2d2;
	public UnityEngine.UI.Text speedText, qCooldown, eCooldown, tagNumber;

	private bool immune;
	private int tagCount;
	private Rigidbody2D rb2d;
	private float immuneCooldownTimer, qCooldownTimer, eCooldownTimer, rCooldownTimer;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		tagCount = 0;
		immune = false;
		tagNumber.text = tagCount.ToString ();
		speedText.text = (Mathf.CeilToInt(rb2d.velocity.magnitude)).ToString();
		qCooldown.text = qCooldownTimer.ToString ();
		eCooldown.text = eCooldownTimer.ToString ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal2");
		float moveVertical = Input.GetAxis ("Vertical2");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);

		if (Input.GetKey (KeyCode.Q) && qCooldownTimer <= 0) {
			immune = true;
			rb2d.AddForce (movement * 5, ForceMode2D.Impulse);
			immuneCooldownTimer = IMMUNEDURATION;
			qCooldownTimer= QCOOLDOWN;
		}

		if (Input.GetKey (KeyCode.E) && eCooldownTimer <= 0) {
			Vector3 velocity = rb2d.velocity;
			rb2d.velocity *= -1;
			eCooldownTimer= ECOOLDOWN;
		}
		if (Input.GetKey (KeyCode.R) && rCooldownTimer <= 0) {
			Instantiate (projectile, rb2d.transform.position, rb2d.transform.rotation);
			rCooldownTimer= RCOOLDOWN;
		}
		speedText.text = (Mathf.CeilToInt(rb2d.velocity.magnitude)).ToString();
	}	

	void Update () {
		if (qCooldownTimer <= 0) {
			qCooldownTimer = 0;
		} 
		else {
			qCooldownTimer -= Time.deltaTime;
		}
		if (eCooldownTimer <= 0) {
			eCooldownTimer = 0;
		} 
		else {
			eCooldownTimer -= Time.deltaTime;
		}
		if (rCooldownTimer <= 0) {
			rCooldownTimer = 0;
		} 
		else {
			rCooldownTimer -= Time.deltaTime;
		}
		if (immuneCooldownTimer <= 0) {
			immune = false;
			immuneCooldownTimer = 0;
		} 
		else {
			immuneCooldownTimer -= Time.deltaTime;
		}
		qCooldown.text = (Mathf.CeilToInt(qCooldownTimer)).ToString ();
		eCooldown.text = (Mathf.CeilToInt(eCooldownTimer)).ToString ();
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Player") {
			tagCount++;
		}
		tagNumber.text = tagCount.ToString ();
	} 
}

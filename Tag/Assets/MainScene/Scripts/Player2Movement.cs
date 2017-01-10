using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Movement : Player {

	private float QCOOLDOWN = 2.0f;
	private float ECOOLDOWN = 2.0f;
	private float RCOOLDOWN = 3.0f;
	private float IMMUNEDURATION = 1.0f;

	public UnityEngine.UI.Text qCooldown, eCooldown;

	private float qCooldownTimer, eCooldownTimer, rCooldownTimer;

	// Use this for initialization
	new void Start () {

		base.Start();
		qCooldown.text = qCooldownTimer.ToString ();
		eCooldown.text = eCooldownTimer.ToString ();
	}

	// Update is called once per frame
	new void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal2");
		float moveVertical = Input.GetAxis ("Vertical2");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		if (Input.GetKey (KeyCode.W)) {
			rb2d.AddForce (transform.up * speed);
		}
		if (Input.GetKey (KeyCode.D)) {
			rb2d.rotation -= 180 * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.A)) {
			rb2d.rotation += 180 * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.Q) && qCooldownTimer <= 0) {
			immune = true;
			rb2d.AddForce (transform.up * 5, ForceMode2D.Impulse);
			immuneCooldownTimer = IMMUNEDURATION;
			qCooldownTimer= QCOOLDOWN;
		}

		if (Input.GetKey (KeyCode.E) && eCooldownTimer <= 0) {
			Vector3 velocity = rb2d.velocity;
			rb2d.velocity *= 0;
			rb2d.AddForce (transform.up * -3, ForceMode2D.Impulse);
			eCooldownTimer= ECOOLDOWN;
		}
		/*if (Input.GetKey (KeyCode.R) && rCooldownTimer <= 0) {
			Instantiate (projectile, rb2d.transform.position, rb2d.transform.rotation);
			rCooldownTimer= RCOOLDOWN;
		}*/
		if (Input.GetKey (KeyCode.R) && rCooldownTimer <= 0) {
			Vector3 pos = rb2d.transform.position;
			pos += (Vector3)(rb2d.transform.up);
			GameObject projObj = Instantiate (Resources.Load ("Projectile") as GameObject, pos, rb2d.transform.rotation);
			projObj.GetComponent<Rigidbody2D> ().velocity = rb2d.transform.up * 30;
			//rCooldownTimer = RCOOLDOWN;
		}
		base.FixedUpdate();
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
		if (other.gameObject.tag == "Player" && immune == false) {
			tagCount++;
			other.rigidbody.velocity = new Vector2(0,0);
			rb2d.AddForce (other.rigidbody.velocity, ForceMode2D.Impulse);
		}
		tagNumber.text = tagCount.ToString ();
	} 
}

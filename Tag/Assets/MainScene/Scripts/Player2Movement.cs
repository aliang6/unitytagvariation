using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Movement : MonoBehaviour {

	private float QCOOLDOWN = 2.0f;
	private float ECOOLDOWN = 2.0f;

	public float speed;
	public Rigidbody2D rb2d2;
	public UnityEngine.UI.Text speedText, qCooldown, eCooldown, tagNumber;

	private bool collide;
	private int tagCount;
	private Rigidbody2D rb2d;
	private float qCooldownTimer, eCooldownTimer;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		tagCount = 0;
		tagNumber.text = tagCount.ToString ();
		speedText.text = (Mathf.CeilToInt(rb2d.velocity.magnitude)).ToString();
		qCooldown.text = qCooldownTimer.ToString ();
		eCooldown.text = eCooldownTimer.ToString ();
		collide = false;
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
		qCooldown.text = (Mathf.CeilToInt(qCooldownTimer)).ToString ();
		eCooldown.text = (Mathf.CeilToInt(eCooldownTimer)).ToString ();
	}
}

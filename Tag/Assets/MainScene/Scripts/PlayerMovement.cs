using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	private float ENTERCOOLDOWN = 2.0f;
	private float SHIFTCOOLDOWN = 2.0f;
	private float SLASHCOOLDOWN = 10.0f;

	public float speed;
	public Rigidbody2D rb2d2;
	public UnityEngine.UI.Text speedText, enterCooldown, shiftCooldown, tagNumber;

	public Rigidbody2D projectile;

	private bool collide;
	private int tagCount;
	private Rigidbody2D rb2d;

	private float enterCooldownTimer, shiftCooldownTimer, slashCooldownTimer;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		tagCount = 0;

		speedText.text = (Mathf.CeilToInt(rb2d.velocity.magnitude)).ToString();
		enterCooldown.text = enterCooldownTimer.ToString ();
		shiftCooldown.text = shiftCooldownTimer.ToString ();
		collide = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * 3);

		if ((Input.GetKey (KeyCode.Return) ||
			Input.GetKey (KeyCode.KeypadEnter)) 
			&& enterCooldownTimer <=0) {
			rb2d.AddForce (movement * 5, ForceMode2D.Impulse);
			enterCooldownTimer= ENTERCOOLDOWN;
		}
		if (Input.GetKey (KeyCode.RightShift) && shiftCooldownTimer <= 0) {
			Vector3 velocity = rb2d.velocity;
			rb2d.velocity *= -1;
			shiftCooldownTimer= SHIFTCOOLDOWN;
		}
		if (Input.GetKey(KeyCode.Slash) && slashCooldownTimer <=0){
			Instantiate (projectile, rb2d.transform.position, rb2d.transform.rotation);
			slashCooldownTimer= SLASHCOOLDOWN;
		}

		speedText.text = (Mathf.CeilToInt(rb2d.velocity.magnitude)).ToString();
	}

	void Update () {
		slashCooldownTimer-= Time.deltaTime;
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
		enterCooldown.text = (Mathf.CeilToInt(enterCooldownTimer)).ToString ();
		shiftCooldown.text = (Mathf.CeilToInt(shiftCooldownTimer)).ToString ();
	}

	/*void OnCollisionEnter (Rigidbody2D rdbd2) {
		
	} */

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public Rigidbody2D rb2d2;
	public UnityEngine.UI.Text speedText;

	private bool collide;
	private int tagCount;
	private Rigidbody2D rb2d;

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

		if (Input.GetKey (KeyCode.Return) ||
		    Input.GetKey (KeyCode.KeypadEnter)) {
			rb2d.AddForce (movement * 2, ForceMode2D.Impulse);
			speedText.text = ((int)(rb2d.velocity.magnitude)).ToString();
		}
			
		speedText.text = ((int)(rb2d.velocity.magnitude)).ToString();
	}

	/*void OnCollisionEnter (Rigidbody2D rdbd2) {
		
	} */

}

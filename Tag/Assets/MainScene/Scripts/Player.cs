using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Rigidbody2D projectile;
	public float speed;
	
	public Rigidbody2D rb2d2;
	
	public UnityEngine.UI.Text speedText, tagNumber;

	public bool immune;
	public int tagCount;
	public Rigidbody2D rb2d;
	public float immuneCooldownTimer;//, qCooldownTimer, eCooldownTimer, rCooldownTimer;

	// Use this for initialization
	public void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		tagCount = 0;
		immune = false;
		tagNumber.text = tagCount.ToString ();
		speedText.text = (Mathf.CeilToInt(rb2d.velocity.magnitude)).ToString();

	}
	
	// Update is called once per frame
	public void FixedUpdate () {
		speedText.text = (Mathf.CeilToInt(rb2d.velocity.magnitude)).ToString();
	}
}

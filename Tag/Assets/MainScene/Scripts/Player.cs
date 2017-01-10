using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Rigidbody2D projectile;
	protected float speed;
	
	public UnityEngine.UI.Text speedText, tagNumber;

	protected bool immune;
	protected int tagCount;
	protected Rigidbody2D rb2d;
	protected float immuneCooldownTimer;
	
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

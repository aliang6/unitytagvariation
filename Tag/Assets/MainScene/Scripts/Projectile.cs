using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public int speed;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Shoot(Vector3 vec) {
		vec.Normalize();
		rb2d.AddForce(speed*vec);
		print(vec);
		Debug.Log("HI");
	}
}

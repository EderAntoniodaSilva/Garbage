using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		
		rb2d = GetComponent<Rigidbody2D> ();	
	}
	
	void FixedUpdate () {
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float jump = 0;

		if (Input.GetKey(KeyCode.Space))
			jump = speed - rb2d.position.y;
		
		Vector3 movement = new Vector3 (moveHorizontal, jump, moveVertical);

		rb2d.AddForce (movement * speed);
		jump = 0;
	}
}
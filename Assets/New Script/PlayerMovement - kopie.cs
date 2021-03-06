﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMovement : MonoBehaviour
{

	public int playerSpeed = 10;
	private bool facingRight = false;
	public int playerJumpPower = 1250;
	private float moveX;
	public bool isGrounded;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMove();
	}

	void PlayerMove()
	{
		//Controls
		moveX = Input.GetAxis("Horizontal");
		if (Input.GetButtonDown("Jump"))
		{
			Jump();
		}
		
		//Animations
		//Player Direction

		if (moveX < 0.0f && facingRight == false)
		{
			FlipPlayer();
		}
		else if (moveX > 0.0f && facingRight == true)
		{
			FlipPlayer();
		}
		//Physics
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);


	}

	void Jump()
	{
		GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
		isGrounded = false;
	}

	void FlipPlayer()
	{
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log("Player has collided with " + col.collider.name );
		if (col.gameObject.tag == "ground")
		{
			isGrounded = true;
		}
	}
}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : Entity {


	public float accTime = 0;
	// Player Handling
	public float gravity = 20;
	public float speed = 2;
	public float acceleration = 3;
	public float jumpHeight = 12;
	
	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;
	
	private PlayerPhysics playerPhysics;

	private bool jump = false;

	private GameManager manager;


	void Start () {
		playerPhysics = GetComponent<PlayerPhysics>();
		manager = Camera.main.GetComponent<GameManager>();

	}
	
	void Update () {

		
		// If player is touching the ground
		if (playerPhysics.grounded) {
			amountToMove.y = 0;
			
			// Jump
			if (Input.GetButtonDown("Jump")) {
				amountToMove.y = jumpHeight;
			}

		}

		/*
		// Input
		targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
		currentSpeed = IncrementTowards(currentSpeed, targetSpeed,acceleration);
		*/


		accTime += Time.deltaTime;
		if (accTime > 3 && speed <= 10) {	
			accTime = 0;
			speed *= 1.1f;
		}


		currentSpeed = IncrementTowards (currentSpeed, speed, acceleration);
		// Set amount to move
		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		playerPhysics.Move(amountToMove * Time.deltaTime);

	}
	
	// Increase n towards target by speed
	private float IncrementTowards(float n, float target, float a) {
		if (n == target) {		
			return n;	
		}
		else {
			float dir = Mathf.Sign(target - n); // must n be increased or decreased to get closer to target
			n += a * Time.deltaTime * dir;
			return (dir == Mathf.Sign(target-n))? n: target; // if n has now passed target then return target, otherwise return n
		}
	}
	
	void OnTriggerEnter(Collider c) {
		if (c.tag == "finish") {
			manager.EndLevel();
		}
	}

}

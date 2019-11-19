using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float kecGerak;
	private float moveSpeedStore;
	public float speedMultiplier;

	public float speedIncreaseMilestone;
	private float speedIncreaseMilestoneStore;

	private float speedMilestoneCount;
	private float speedMilestoneCountStore;

	public float powerLompat;

	public float jumpTime;
	private float jumpTimeCounter;

	private bool stoppedJumping;
	private bool canDoubleJump;

	private Rigidbody2D myRigidBody;
	//private Collider2D myCollider;
	private Animator myAnimator;

	public GameManager theGameManager;

	public AudioSource jumpSound;
	public AudioSource deathSound;

	public bool tapak;
	public LayerMask layerTanah;
	public Transform groundCheck;
	public float groundCheckRadius;

	public bool jump;


	// Use this for initialization

	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();

		//myCollider = GetComponent<Collider2D> ();

		myAnimator = GetComponent<Animator>();

		jumpTimeCounter = jumpTime;

		speedMilestoneCount = speedIncreaseMilestone;

		moveSpeedStore = kecGerak;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;

		stoppedJumping = true;
	}

	// Update is called once per frame
	void Update () {

		//tapak = Physics2D.IsTouchingLayers (myCollider, layerTanah);

		tapak = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, layerTanah);	

		if (transform.position.x > speedMilestoneCount) 
		{
			speedMilestoneCount += speedIncreaseMilestone;

			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			kecGerak = kecGerak * speedMultiplier;
		}

		myRigidBody.velocity = new Vector2 (kecGerak, myRigidBody.velocity.y);

		if (Input.GetKeyDown (KeyCode.Space)|| (jump==true)) 
		{
			if(tapak)
			{
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, powerLompat);
				stoppedJumping = false;
				jumpSound.Play();
			}

			if(!tapak && canDoubleJump)
			{
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, powerLompat);
				jumpTimeCounter = jumpTime;
				stoppedJumping = false;
				canDoubleJump = false;
				jumpSound.Play();
			}
		}

		if ((Input.GetKey (KeyCode.Space)|| (jump==true))  && !stoppedJumping) 
		{
			if (jumpTimeCounter > 0) 
			{
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, powerLompat);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if (Input.GetKeyUp (KeyCode.Space)|| (jump==true)) 
		{
			jumpTimeCounter = 0;
			stoppedJumping = true;
		}

		if (tapak) 
		{
			jumpTimeCounter = jumpTime;
			canDoubleJump = true;
		}  
		myAnimator.SetFloat ("Speed", myRigidBody.velocity.x);
		myAnimator.SetBool ("Grounded", tapak);
	}

	public void pressjump()
	{
		jump = true;
	}
	public void dropjump()
	{
		jump = false;
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "killbox") 
		{

			theGameManager.RestartGame ();
			kecGerak = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
			deathSound.Play ();
		}
	}
}

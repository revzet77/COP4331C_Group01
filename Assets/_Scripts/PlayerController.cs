using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* TODO:
    1. Tie Player states into this (ie. target speed should account if the player state is running or not)
    2. 
    */
public class PlayerController : MonoBehaviour
{
    private PlayerStats playerStats;
    private CharacterController player;
    private Animator animator;
    private Transform cameraT;

	float turnVelocity;
	float velocity;
    float velocityY;
    float speed;

    /* TODO:
        1. Add bumper sphere support (Will change moveDir based off of if the player is running into a wall.)
     */
    void Start()
    {
        cameraT = GameObject.Find("Main Camera").GetComponent<Transform>();
        playerStats = gameObject.GetComponent<PlayerStats>();
        player = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
        velocityY = 0;

    }

    

    // void Update()
    public void ReceiveInput(InputHandler.KeyboardInput movement)
    {
        Move(movement.inputWASD, movement.isSprinting);
        if (movement.isJumping)
        {
            Jump();
        }
    }

    void Move(Vector2 inputDir, bool sprint){
        // create the rotation we need to be in to look at the target (Based off of the camera's y-rotation)
        // smooth damp it based off our smooth speed to make a visually nice transition
        if (inputDir != Vector2.zero) {
            float targetRotation = Mathf.Atan2 (inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnVelocity, playerStats.turnSmoothTime);
		}

        // Set our Target Speed
        if (velocityY > playerStats.gravity){
            velocityY += Time.deltaTime * playerStats.gravity;
        }
        float tgtSpeed;
        if (sprint){
            tgtSpeed = playerStats.runSpeed * inputDir.magnitude;
        } else {
            tgtSpeed = playerStats.walkSpeed * inputDir.magnitude;
        }
		speed = Mathf.SmoothDamp (speed, tgtSpeed, ref velocity, playerStats.speedSmoothTime);
        Vector3 vel = (transform.forward * speed + Vector3.up * velocityY) * Time.deltaTime;
        player.Move(vel);
    }

    void Jump(){
        if (player.isGrounded)
        {
            float jumpVelocity = Mathf.Sqrt (-2 * playerStats.gravity * playerStats.jumpHeight);
			velocityY = jumpVelocity;
		}
    }

}

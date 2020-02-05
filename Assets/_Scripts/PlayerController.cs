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
    private CharacterController playerC;
    private Transform cameraT;
    private float vInput, hInput;
    Vector2 inputDir;

	float turnVelocity;
	float velocity;
    float speed;

    /* TODO:
        1. Add bumper sphere support (Will change moveDir based off of if the player is running into a wall.)
     */
    void Start()
    {
        cameraT = GameObject.Find("Main Camera").GetComponent<Transform>();
        playerStats = gameObject.GetComponent<PlayerStats>();
        playerC = gameObject.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        //handle inputs from the user (Will need to add handling here)
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
        inputDir = new Vector2 (hInput, vInput);

        // create the rotation we need to be in to look at the target (Based off of the camera's y-rotation)
        // smooth damp it based off our smooth speed to make a visually nice transition
        if (inputDir != Vector2.zero) {
			float targetRotation = Mathf.Atan2 (inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnVelocity, playerStats.turnSmoothTime);
		}

        // Set our Target Speed
        float tgtSpeed = playerStats.runSpeed * inputDir.magnitude;
		speed = Mathf.SmoothDamp (speed, tgtSpeed, ref velocity, playerStats.speedSmoothTime);
        playerC.Move(transform.forward * Time.deltaTime * speed);

    }

}

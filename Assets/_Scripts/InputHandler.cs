using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour{

    private PlayerController player;
    private CameraController camera;
    private AnimationController animations;
    

    // Keyboard and Mouse Inputs from the player
    public struct PlayerInput {
        public float vertMouseInput, horzMouseInput;
        public Vector2 inputWASD;
        public bool isShooting;
        public bool isAiming;
        public bool isSprinting;
        public bool isJumping;
        public float weaponSelect;
    }

    // private KeyboardInput keyboard;
    private PlayerInput playerInput;

    void Start(){
        player = GameObject.Find("PlayerController").GetComponent<PlayerController>();
        camera = GameObject.Find("Main Camera").GetComponent<CameraController>();
        animations = GameObject.Find("PlayerController").GetComponent<AnimationController>();
    }

    void Update(){
        // TODO: Add states from GameManager to determine how the input is interpreted and sent to other scripts
        // at the moment, it only takes into account inputs as movement.

        // take inputs related to keyboard
        playerInput.inputWASD = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        

        playerInput.isSprinting = Input.GetButton("Sprint");

        playerInput.isJumping = Input.GetButtonDown("Jump");

        playerInput.isShooting = Input.GetButton("Fire1");

        playerInput.isAiming = Input.GetButton("Aim");

        if(Input.GetButtonDown("Weapon1"))
            playerInput.weaponSelect = 1;

        if(Input.GetButtonDown("Weapon2"))
            playerInput.weaponSelect = 2;

        if(Input.GetButtonDown("Weapon3"))
            playerInput.weaponSelect = 3;


        // send keyboard inputs to PlayerController script.
        player.ReceiveInput(playerInput);
        animations.ReceiveInput(playerInput);
    }

    void LateUpdate(){
        
        // take inputs related to mouse movement.
        playerInput.horzMouseInput += Input.GetAxis("Mouse X");
        playerInput.vertMouseInput -= Input.GetAxis("Mouse Y");


        // Send mouse input to CameraController script.
        camera.ReceiveInput(playerInput);
    }

    public bool TestInputs(){
        return !( playerInput.Equals(default(PlayerInput))) ;
    }
}
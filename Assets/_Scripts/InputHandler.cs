using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour{

    private PlayerController player;
    private CameraController camera;
    private Animator animator;
    
    //Keyboard Inputs
    public struct KeyboardInput{
        public Vector2 inputWASD;
        public bool isSprinting;
        public bool isJumping;
    }
    // mouse inputs for camera
    public struct MouseInput{
        public float vertInput, horzInput;
    }

    private KeyboardInput keyboard;
    private MouseInput mouse;

    void Start(){
        player = GameObject.Find("PlayerController").GetComponent<PlayerController>();
        camera = GameObject.Find("Main Camera").GetComponent<CameraController>();
        animator = player.GetComponent<Animator>();
    }

    void Update(){
        // TODO: Add states from GameManager to determine how the input is interpreted and sent to other scripts
        // at the moment, it only takes into account inputs as movement.

        // take inputs related to keyboard
        keyboard.inputWASD = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        animator.SetBool("IsMoving", (keyboard.inputWASD != Vector2.zero));         

        keyboard.isSprinting = Input.GetButton("Sprint");
        animator.SetBool("IsSprinting", keyboard.isSprinting);

        keyboard.isJumping = Input.GetButtonDown("Jump");
        if (keyboard.isJumping)
            animator.SetTrigger("JumpTrigger");

        // send keyboard inputs to PlayerController script.
        player.ReceiveInput(keyboard);
    }

    void LateUpdate(){
        // take inputs related to mouse movement.
        mouse.horzInput += Input.GetAxis("Mouse X");
        mouse.vertInput -= Input.GetAxis("Mouse Y");

        // Send mouse input to CameraController script.
        camera.ReceiveInput(mouse);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour{

    private PlayerController player;
    private CameraController camera;
    private AnimationController animations;
    
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
        animations = GameObject.Find("PlayerController").GetComponent<AnimationController>();
    }

    void Update(){
        // TODO: Add states from GameManager to determine how the input is interpreted and sent to other scripts
        // at the moment, it only takes into account inputs as movement.

        // take inputs related to keyboard
        keyboard.inputWASD = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        keyboard.isSprinting = Input.GetButton("Sprint");

        keyboard.isJumping = Input.GetButtonDown("Jump");

        // send keyboard inputs to PlayerController script.
        player.ReceiveInput(keyboard);
        animations.ReceiveInput(keyboard);
    }

    void LateUpdate(){
        
        // take inputs related to mouse movement.
        mouse.horzInput += Input.GetAxis("Mouse X");
        mouse.vertInput -= Input.GetAxis("Mouse Y");

        // Send mouse input to CameraController script.
        camera.ReceiveInput(mouse);
    }

    public bool TestInputs(){
        return !( keyboard.Equals(default(KeyboardInput))) ;
    }
}
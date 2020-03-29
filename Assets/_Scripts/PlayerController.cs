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
    private GunController gunC;

    private Gun[] gunList = new Gun[3];
    private Gun activeGun;

    private Transform cameraT;
    private Transform bullet;
    
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
        gunC = GameObject.Find("GameManager").GetComponent<GunController>();
        bullet = GameObject.Find("BulletRelease").GetComponent<Transform>();
        velocityY = 0;
        
        gunList[0] = new Gun( "AK74", 1, 0.1f, true );
        gunList[1] = new Gun( "M107", 1, 0.0f, false );
        gunList[2] = new Gun( "Bennelli_M4", 1, 0.3f, true);
        activeGun = gunList[0];
        
    }

    

    // void Update()
    public void ReceiveInput(InputHandler.PlayerInput inputP)
    {
        Move(inputP.inputWASD, inputP.isSprinting, inputP.isAiming);
        if (inputP.isJumping)
        {
            Jump();
        }
        
        if ( inputP.weaponSelect != -1 ){
            SwapWeapon(inputP.weaponSelect);
        }

        if ( inputP.firstPull ) { Shoot(); }
        if ( inputP.triggerRelease ) { activeGun.timeSinceLastShot = 0.0f; }
        if ( inputP.isShooting && activeGun.GetIsAuto() ){
            if ( activeGun.timeSinceLastShot >= activeGun.GetRPM() ){
                Shoot();
            } else {
                activeGun.timeSinceLastShot += Time.deltaTime;
            }
        }
    }

    void Move(Vector2 inputDir, bool sprint, bool aiming){
        // create the rotation we need to be in to look at the target (Based off of the camera's y-rotation)
        // smooth damp it based off our smooth speed to make a visually nice transition
        if (inputDir != Vector2.zero || aiming) {
            float targetRotation = Mathf.Atan2 (inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnVelocity, playerStats.turnSmoothTime);
		}
        if (aiming) {
            bullet.eulerAngles = cameraT.eulerAngles;
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

    void Shoot(){
        // use the active gun's RPM to calculate the time between each shot
        // tbs = 1 / (rpm / 60)
        gunC.ShootGun(bullet.transform, activeGun);
        activeGun.timeSinceLastShot = 0.0f;
    }

    void SwapWeapon(int weaponNum){
        activeGun.HideGun();
        
        //set new activeGun
        activeGun = gunList[weaponNum];
        Debug.Log(activeGun.getInGameObject());

        activeGun.ShowGun();
        
    }
    public PlayerStats GetPlayerStats(){
        return playerStats;
    }

    public CharacterController GetCharacterController(){
        return player;
    }

    public Transform GetCameraTransform(){
        return cameraT;
    }

}

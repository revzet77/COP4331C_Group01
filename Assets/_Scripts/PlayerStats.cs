using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float runSpeed = 7.0f;
    public float walkSpeed = 5.0f;
    public float rotateSpeed = 7.0f;
    public float moveAcceleration = 0.1f;
    public float speedSmoothTime = 0.1f;
    public float turnSmoothTime = 0.2f;
    public float gravity = -5f;
    public float jumpHeight = 1f;
    public float health;
}

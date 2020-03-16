using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStats : MonoBehaviour
{
    public bool lockCursor;
    public float mouseSensitivity = 5.0f;
    public Vector2 verticalClamp = new Vector2(-50.0f, 85.0f);
    public Vector2 offset = new Vector2(5.0f, 4.0f);
    public float distToCameraX = 5.0f;
    public float distToCameraY = 2.0f;
    public float distToCameraZ = 0.0f;
    public float distToCameraXAiming = 2.0f;
    public float distToCameraYAiming = 2.5f;
    public float distToCameraZAiming = 0.5f;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerT;
    private CameraStats cStats;
    private Vector3 targetPos;
    
    float vertInput, horzInput;

    void Start()
    {
        playerT = GameObject.Find("PlayerController").GetComponent<Transform>();
        cStats = GetComponent<CameraStats>();
        if (cStats.lockCursor) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
    }

    void LateUpdate()
    {
        horzInput += Input.GetAxis("Mouse X") * cStats.mouseSensitivity;
        vertInput -= Input.GetAxis("Mouse Y") * cStats.mouseSensitivity;
        vertInput = Mathf.Clamp(vertInput, cStats.verticalClamp.x, cStats.verticalClamp.y);

        Vector3 rotAnglesCam = new Vector3(vertInput, horzInput, 0);
        transform.eulerAngles = rotAnglesCam;
        targetPos = playerT.position - (transform.forward * cStats.distToCameraX) + (Vector3.up * cStats.distToCameraY);
        transform.position = targetPos;
    }

}

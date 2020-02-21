using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerT;
    private CameraStats cStats;
    private Vector3 targetPos;
    
    void Start()
    {
        playerT = GameObject.Find("PlayerController").GetComponent<Transform>();
        cStats = GetComponent<CameraStats>();
        if (cStats.lockCursor) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
    }

    public void ReceiveInput(InputHandler.MouseInput mouse)
    {
        mouse.horzInput *= cStats.mouseSensitivity;
        mouse.vertInput *= cStats.mouseSensitivity;
        mouse.vertInput = Mathf.Clamp(mouse.vertInput, cStats.verticalClamp.x, cStats.verticalClamp.y);

        Vector3 rotAnglesCam = new Vector3(mouse.vertInput, mouse.horzInput, 0);
        transform.eulerAngles = rotAnglesCam;
        targetPos = playerT.position - (transform.forward * cStats.distToCameraX) + (Vector3.up * cStats.distToCameraY);
        transform.position = targetPos;
    }

    public Transform GetPlayerTransform(){
        return playerT;
    }

    public Vector3 GetTargetPosition(){
        return targetPos;
    }

    public CameraStats GetCameraStats(){
        return cStats;
    }

}

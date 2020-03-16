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

    public void ReceiveInput(InputHandler.PlayerInput input)
    {
        input.horzMouseInput *= cStats.mouseSensitivity;
        input.vertMouseInput *= cStats.mouseSensitivity;
        input.vertMouseInput = Mathf.Clamp(input.vertMouseInput, cStats.verticalClamp.x, cStats.verticalClamp.y);

        Vector3 rotAnglesCam = new Vector3(input.vertMouseInput, input.horzMouseInput, 0);
        transform.eulerAngles = rotAnglesCam;
        if ( input.isAiming ){
            targetPos = playerT.position - (transform.forward * cStats.distToCameraXAiming) + (Vector3.up * cStats.distToCameraYAiming) + (transform.right * cStats.distToCameraZAiming);
        } else {
            targetPos = playerT.position - (transform.forward * cStats.distToCameraX) + (Vector3.up * cStats.distToCameraY) + (Vector3.left * cStats.distToCameraZ);
        }

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

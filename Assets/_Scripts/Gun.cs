using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private string name;            // Name of the weapon
    private float damage;           // damage per single shot hit
    private float rpm;                // time between shots
    private bool isAuto;            // is automatic weapon?
    private GameObject inGameObject;
    private int idNum;


    public float timeSinceLastShot;


    public Gun( string n, int id, int dmg, float RPM, bool auto){
        name = n;
        idNum = id;
        damage = dmg;
        rpm =  RPM;
        isAuto = auto;
        inGameObject = GameObject.Find("B_R_Hand/"+n);
        timeSinceLastShot = 0.0f;
    }

    public float GetDamage(){
        return damage;
    }

    public float GetRPM(){
        return rpm;
    }
    
    public bool GetIsAuto(){
        return isAuto;
    }

    public int GetID(){
        return idNum;
    }

    public void HideGun(){
        // make current weapon no longer visible
        inGameObject.GetComponent<MeshRenderer>().enabled = false;
        //make all of it's inner components invisible as well
        foreach( MeshRenderer mesh in inGameObject.GetComponentsInChildren(typeof(MeshRenderer)) ){
            mesh.enabled = false;
        }
    }

    public void ShowGun(){
        //make main mesh visible
        inGameObject.GetComponent<MeshRenderer>().enabled = true;
        foreach( MeshRenderer mesh in inGameObject.GetComponentsInChildren(typeof(MeshRenderer), true) ){
            mesh.enabled = true;
        }
    }

    public GameObject getInGameObject(){
        return inGameObject;
    }
    
}

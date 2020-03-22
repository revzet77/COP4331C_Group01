using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private float damage;       // damage per single shot hit
    private int rpm;            // time between shots
    private bool isAuto;        // is automatic weapon?


    public Gun( int dmg, int RPM, bool auto){
        damage = dmg;
        rpm =  RPM;
        isAuto = auto;
    }

    public float GetDamage(){
        return damage;
    }

    public int GetRPM(){
        return rpm;
    }
    
    public bool GetIsAuto(){
        return isAuto;
    }
    
}

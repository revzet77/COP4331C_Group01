using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyid : MonoBehaviour
{
    public int Id;

     void Start()
    {

    }

    public void setID(int setid){
        Id = setid;
    }

    public int getID(){
        return Id;
    }
}

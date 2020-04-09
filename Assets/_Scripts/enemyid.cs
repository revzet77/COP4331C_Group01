using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyid : MonoBehaviour
{
    int id;

     void Start()
    {

    }

    public void setID(int setid){
        id = setid;
    }

    public int getID(){
        return id;
    }
}

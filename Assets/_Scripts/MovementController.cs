using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player MUST be named player controller
public class MovementController : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
   
    public MovementController(UnityEngine.AI.NavMeshAgent enagent)
    {
        agent = enagent;
    }

    // Update is called once per frame
    public void moveToPlayer()
    {
        Transform playerpos = GameObject.Find("PlayerController").GetComponent<Transform>();
        agent.SetDestination(playerpos.position);

    }
}

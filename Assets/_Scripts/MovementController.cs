using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent meleeRange;
    public UnityEngine.AI.NavMeshAgent midRange;
    public UnityEngine.AI.NavMeshAgent longRange;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        meleeRange.SetDestination(player.GetComponent<Transform>().position);
        midRange.SetDestination(player.GetComponent<Transform>().position);
        longRange.SetDestination(player.GetComponent<Transform>().position);
    }
}

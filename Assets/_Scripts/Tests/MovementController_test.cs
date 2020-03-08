using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent meleeRange;
    public UnityEngine.AI.NavMeshAgent midRange;
    public UnityEngine.AI.NavMeshAgent longRange;
    public GameObject player;
    private Animator animator1;
    // Start is called before the first frame update
    void Start()
    {
        animator1 = meleeRange.GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {

        //meleeRange.hasPath;

        meleeRange.SetDestination(player.GetComponent<Transform>().position);
        midRange.SetDestination(player.GetComponent<Transform>().position);
        longRange.SetDestination(player.GetComponent<Transform>().position);
    }
}

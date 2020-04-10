using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AIAnimationController : MonoBehaviour
{
    private Animator animator;
    UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void Initialize(UnityEngine.AI.NavMeshAgent enagent)
    {
        agent = enagent;
    }

    void Update()
    {   
        animator.SetBool("moving", (agent.velocity != Vector3.zero));
        animator.SetFloat("angularspeed", agent.angularSpeed);
        animator.SetFloat("speed", agent.speed);
    }

    public void TakeDamage()
    {
        animator.SetTrigger("damage");
    }

    public void Attack()
    {
        animator.SetTrigger("attack");
    }

    public void Die()
    {
        animator.SetTrigger("death");
    }

    public Animator GetAnimator()
    {
        return animator;
    }

}
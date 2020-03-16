using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();        
    }


    public void ReceiveInput(InputHandler.PlayerInput inputP)
    {
        animator.SetBool("IsMoving", (inputP.inputWASD != Vector2.zero));

        animator.SetBool("IsSprinting", inputP.isSprinting);

        if (inputP.isJumping)
            animator.SetTrigger("JumpTrigger");
    }


    void SetAnimationStates()
    {

    }

    public Animator GetAnimator(){
        return animator;
    }

}

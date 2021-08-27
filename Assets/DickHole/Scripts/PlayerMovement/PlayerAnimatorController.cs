using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void PlayerInMove(bool isMove){
        animator.SetBool("Move",isMove);
    }

    public void Jump(){
        animator.SetTrigger("Jump");
    }

    public void Falling(bool falling){
        animator.SetBool("Falling", falling);
    }

    public void Attack(){
        animator.SetTrigger("Attack");
    }
}

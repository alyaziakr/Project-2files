using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerController : MonoBehaviour 
{

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnPointerEnter()
    {
        Debug.Log("pointer enter!");
        animator.SetTrigger("stop");
        animator.SetFloat("walkspeed", 0f);
    }
    public void OnPointerExit()
    {
        Debug.Log("pointer exit!");
        animator.SetTrigger("resume");
        animator.SetFloat("walkspeed", 1f);
    }
}

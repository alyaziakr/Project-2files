using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petting : MonoBehaviour
{
	Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        
    }
    public void OnTouchDown()
    {
        Debug.Log("on touch down sleep");
        animator.SetBool("goSleep",true);
    }
    public void OnTouchUp()
    {
        Debug.Log("on touch up");
        animator.SetBool("goSleep",false);
    }
}

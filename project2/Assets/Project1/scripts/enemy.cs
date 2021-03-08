using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnPointerClick()
    {
        Debug.Log("it works");
        anim.SetTrigger("isHit");
        Destroy(GameObject.FindWithTag("light"));
    }
}

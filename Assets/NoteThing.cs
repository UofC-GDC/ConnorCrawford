using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteThing : Thing 
{
    [SerializeField] private Animator animator;

    private void OnEnable()
    {
        animator.SetTrigger("fall");
    }
}

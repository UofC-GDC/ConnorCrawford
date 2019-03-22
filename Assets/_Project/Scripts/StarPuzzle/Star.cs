using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour 
{
    [SerializeField] private Animator animator;

	private void Update () 
    {
        if (Random.value > .999f && !animator.GetCurrentAnimatorStateInfo(0).IsName("Twinkle"))
        {
            animator.SetTrigger("Twinkle");
        }
	}
}

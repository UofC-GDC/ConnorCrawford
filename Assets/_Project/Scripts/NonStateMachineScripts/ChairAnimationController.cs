using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairAnimationController : MonoBehaviour 
{

    [SerializeField] private Animator animator;
    [SerializeField] private new Rigidbody rigidbody;

	private void Update () 
    {
        animator.SetFloat("Speed", rigidbody.velocity.magnitude);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DIYAnimationController : MonoBehaviour 
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
	
	private void Update () 
    {
        var vel = new Vector2(agent.velocity.normalized.x, agent.velocity.normalized.z);
        float angle = FindDegree(vel);

        animator.SetFloat("Angle", angle);
        animator.SetBool("Stopped", vel.sqrMagnitude == 0);

        var velMagNorm = agent.velocity.magnitude / 1.6f;
        var animSpeed = .2f * velMagNorm;
        animator.SetFloat("Speed", animSpeed);

    }

    private static float FindDegree(Vector2 vector2)
    {
        float x = vector2.x;
        float y = vector2.y;

        float value = (float)((Mathf.Atan2(x, y) / System.Math.PI) * 180f);
        if (value < 0) value += 360f;

        return value;
    }
}

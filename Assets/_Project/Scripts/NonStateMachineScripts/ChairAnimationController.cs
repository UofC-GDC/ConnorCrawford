using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairAnimationController : MonoBehaviour 
{

    [SerializeField] private Animator animator;
    [SerializeField] private new Rigidbody rigidbody;

    [SerializeField] private AudioSource chairMovingAudioSource;

    private void Start()
    {
        if (chairMovingAudioSource != null)
        {
            chairMovingAudioSource.loop = true;
        }
    }

    private void Update () 
    {
        animator.SetFloat("Speed", rigidbody.velocity.magnitude);
        PlayMovingSoundEffect();
	}

    private void PlayMovingSoundEffect()
    {
        if(rigidbody.velocity.magnitude > 0 && !chairMovingAudioSource.isPlaying)
        {
            chairMovingAudioSource.volume = Random.Range(.8f, 1);
            chairMovingAudioSource.pitch = Random.Range(.8f, 1.1f);
            chairMovingAudioSource.Play();
        }

        if(rigidbody.velocity.magnitude == 0 && chairMovingAudioSource.isPlaying)
        {
            chairMovingAudioSource.Stop();
        }
    }
}

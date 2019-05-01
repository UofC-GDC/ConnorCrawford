using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioTalk : MonoBehaviour 
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AnimationCurve curve;

    float startPitch = 1;

    private void Start () 
    {
        startPitch = audioSource.pitch;
    }
	
	private void Update () 
    {
        if(!start)
            StartCoroutine(enumerator());
	}

    bool start = false;

    public IEnumerator enumerator()
    {
        yield return new WaitForSecondsRealtime(3f);

        start = true;
        foreach (var character in "Incoming walkie talkie transmission: The code is 4239")
        {
            #region Audio Playing
            if (character.Equals('?') || character.Equals('!'))
            {
                audioSource.pitch = startPitch + curve.Evaluate(1) + .1f;
                audioSource.Play();
            }
            else if (!System.Char.IsWhiteSpace(character))
            {
                audioSource.pitch = startPitch + curve.Evaluate(Random.value);
                if(audioSource.enabled)
                    audioSource.Play();
            }
            #endregion

            var waitForSeconds = 0.05f;

            #region Waiting
            yield return new WaitForSecondsRealtime(waitForSeconds);

            if (character.Equals(','))
            {
                yield return new WaitForSecondsRealtime(waitForSeconds * 2);
            }
            if (character.Equals('.'))
            {
                yield return new WaitForSecondsRealtime(waitForSeconds * 4);
            }
            #endregion
        }
        start = false;
    }
}

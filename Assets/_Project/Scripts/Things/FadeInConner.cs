using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInConner : Thing
{

    [SerializeField] private Animator connerAnimator;

    private bool start = false;
    private bool done = false;

    public override State Action(StateManager.Env env, ref Player player)
    {
        if (!start)
            StartCoroutine(FadeOut());
        if (done)
            return null;

        return new DoInteractionState();
    }

    public IEnumerator FadeOut()
    {
        start = true;
        connerAnimator.SetTrigger("FadeIn");

        while (!connerAnimator.GetCurrentAnimatorStateInfo(0).IsName("IdleSouth"))
        {
            yield return null;
        }

        connerAnimator.SetBool("Cutscene", false);
        done = true;
    }
}

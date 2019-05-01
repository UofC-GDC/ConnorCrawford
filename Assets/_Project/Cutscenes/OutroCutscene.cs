using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroCutscene : Thing
{
    [SerializeField] private Animator fadeInOutPanelAnimator;
    [SerializeField] private Animator connerAnimator;
    [SerializeField] private PlayAllTheSoundEffects playAllTheSoundEffeccts;
    [SerializeField] private Door door;

    [Header("New")]
    [SerializeField] private GameObject FlashLight;
    [SerializeField] private GameObject newFlashLightParent;
    [Header("New New")]
    [SerializeField] private GameObject timeMachine;
    [SerializeField] private GameObject flashLight;
    [SerializeField] private BatteryInteract batteries;

    private bool letsGo = false;
    private bool allDone = false;

    [HideInInspector] public bool doneSounds = false;

    public override State Action(StateManager.Env env, ref Player player)
    {
        //Put Back Flash light
        FlashLight.transform.SetParent(newFlashLightParent.transform);
        FlashLight.transform.localPosition = new Vector3(0.985f, -1.51f, 14.3583f);
        DarknessManager.Instance.ResetFlashlight();

        if (!letsGo && !allDone)
        { 
            StartCoroutine(action(env, player));
            return new DoInteractionState();
        }
        else if (letsGo)
        {
            if (donePart1 && !leggo2 && !doneSounds)
            {
                return playAllTheSoundEffeccts.Action(env, ref player);
            }
            else if (doneSounds && !leggo2)
            {
                StartCoroutine(actionPart2(env, player));
            }
            else if (leggo2)
            {
                return new DoInteractionState();
            }
            return new DoInteractionState();
        }
        else
            return null;
    }

    private bool donePart1 = false;

    private IEnumerator action(StateManager.Env env, Player player)
    {
        letsGo = true;

        connerAnimator.SetBool("Cutscene", true);
        connerAnimator.SetTrigger("FadeOut");

        while (!connerAnimator.GetCurrentAnimatorStateInfo(0).IsName("FadedOut"))
        {
            yield return null;
        }

        //Close door 
        door.Action(env, ref player);

        fadeInOutPanelAnimator.SetTrigger("FadeToBlack");

        while (!fadeInOutPanelAnimator.GetCurrentAnimatorStateInfo(0).IsName("Black"))
        {
            yield return null;
        }

        donePart1 = true;
    }

    private bool leggo2 = false;

    private IEnumerator actionPart2(StateManager.Env env, Player player)
    {
        leggo2 = true;
        timeMachine.SetActive(false);
        flashLight.SetActive(false);
        batteries.battery1 = true;
        batteries.battery2 = true;
        DarknessManager.Instance.SetTimeToNight();

        fadeInOutPanelAnimator.SetTrigger("FadeFromBlack");

        while (!fadeInOutPanelAnimator.GetCurrentAnimatorStateInfo(0).IsName("Transparent"))
        {
            yield return null;
        }

        door.Action(env, ref player);

        connerAnimator.SetTrigger("FadeIn");

        while (!connerAnimator.GetCurrentAnimatorStateInfo(0).IsName("IdleSouth"))
        {
            yield return null;
        }

        connerAnimator.SetBool("Cutscene", false);

        letsGo = false;
        allDone = true;
        yield break;
    }
}

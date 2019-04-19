using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMachine : Thing
{
    private bool open = false;
    private bool unlocked = false;
    public bool readyToTimeTravel = false;
    [SerializeField] private Animator lidAnimator;
    [SerializeField] private Animator steamAnimator;
    [SerializeField] private GameObject manual;

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject starPuzzle;
    [SerializeField] private Animator fadeInOutPanelAnimator;

    [SerializeField] private Animator gearsAnimator;
    [SerializeField] private List<GameObject> LEDs;
    [SerializeField] private Animator clockAnimator;

    [SerializeField] private Animator realClockAnimator;
    [SerializeField] private AudioSource whirring;

    [SerializeField] private Animator galaxy;

    [Header("new")]
    [SerializeField] private Thing fadeOutPanel;
    [SerializeField] private Thing credits;
    [SerializeField] private Thing timeMachineInsight;

    private float heldTime = 0f;

    private bool blink1 = false;
    private bool blink2 = false;
    private bool blink3 = false;

    public override State Action(StateManager.Env env, ref Player player)
    {
        if (!open)
        {
            lidAnimator.SetTrigger("Open");
            steamAnimator.SetTrigger("Steam");
            StartCoroutine(BookTurnOn());
            return null;
        }
        else if (!unlocked)
        {
            //unlocked = true;
            //return null;
            if (heldTime >= 3f && !Input.GetMouseButtonDown(1) || heldTime >= 4.1f)
            {
                //Unlock Time Machine
                unlocked = true;
                gearsAnimator.SetTrigger("Gears");
                foreach (var LED in LEDs)
                {
                    LED.SetActive(true);
                    LED.GetComponent<BlinkingLight>().enabled = true;
                }
                return new DisplayInsight(StateManager.Instance.storySpeechBubble, StateManager.Instance.storyNextButton, timeMachineInsight, StateManager.Instance.storyTextMesh, StateManager.Instance.connerAudioSource, StateManager.Instance.connerAudioCurve);
            }
            else if (Input.GetMouseButton(1))
            {
                heldTime += Time.deltaTime;

                #region Blink1
                if (heldTime >= 1f && !blink1)
                {
                    foreach (var LED in LEDs)
                    {
                        LED.SetActive(true);
                    }
                    LEDs[0].GetComponent<AudioSource>().Play();
                    blink1 = true;
                }
                if (heldTime >= 1.2f && blink1 && !blink2 && !blink3)
                {
                    foreach (var LED in LEDs)
                    {
                        LED.SetActive(false);
                    }
                }
                #endregion  

                #region Blink2
                if (heldTime >= 2f && !blink2)
                {
                    foreach (var LED in LEDs)
                    {
                        LED.SetActive(true);
                    }
                    LEDs[0].GetComponent<AudioSource>().Play();
                    blink2 = true;
                }
                if (heldTime >= 2.2f && blink2 && !blink3)
                {
                    foreach (var LED in LEDs)
                    {
                        LED.SetActive(false);
                    }
                }
                #endregion

                #region Blink3
                if (heldTime >= 3f && !blink3)
                {
                    foreach (var LED in LEDs)
                    {
                        LED.SetActive(true);
                    }
                    LEDs[0].GetComponent<AudioSource>().Play();
                    blink3 = true;
                }
                if (heldTime >= 3.2f && blink3)
                {
                    foreach (var LED in LEDs)
                    {
                        LED.SetActive(false);
                    }
                }
                #endregion  

                return new DoInteractionState();
            }
            else
            {
                heldTime = 0;
                blink1 = false;
                blink2 = false;
                blink3 = false;
                return base.Action(env, ref player);
            }
        }
        else if (readyToTimeTravel)
        {
            //AudioManager.Instance.TimeTravelTheme();
            clockAnimator.SetTrigger("Leggo");
            realClockAnimator.enabled = true;
            realClockAnimator.SetTrigger("TimeTravel");
            //whirring.Play();
            //StartCoroutine(TimeTravelSequence());
            fadeOutPanel.Action(env, ref player);
            return credits.Action(env, ref player);
        }
        else
        {
            StarExitButton.Instance.ActivateStarPuzzle();
            return null;
        }
    }

    private IEnumerator BookTurnOn()
    {
        while (!lidAnimator.GetCurrentAnimatorStateInfo(0).IsName("TimeMachineOpened"))
        {
            yield return null;
        }

        manual.SetActive(true);
        open = true;
        yield break;
    }

    private IEnumerator TimeTravelSequence()
    {
        yield return new WaitForSecondsRealtime(6f);

        galaxy.SetTrigger("Galaxy");
    }

}

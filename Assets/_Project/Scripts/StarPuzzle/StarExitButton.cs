using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarExitButton : Singleton<StarExitButton> 
{
    [SerializeField] private Animator fadeInOutPanelAnimator;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject starPuzzle;
    [SerializeField] private StarPuzzle starPuzzleMan;
    //[SerializeField] private Thing fadeOutPanel;
    //[SerializeField] private Thing credits;

    private bool transitioning = false;

    [ContextMenu("DisableStarPuzzle")]
    public void DisableStarPuzzle()
    {
        AudioManager.Instance.MainThemeNight();
        StartCoroutine(ToggleStarPuzzle(false));
        //if (starPuzzleMan.complete)
        //{
        //    var p = new Player();
        //    fadeOutPanel.Action(new StateManager.Env(), ref p);
        //    credits.Action(new StateManager.Env(), ref p);
        //}
    }

    [ContextMenu("ActivateStarPuzzle")]
    public void ActivateStarPuzzle()
    {
        AudioManager.Instance.StarTheme();
        StartCoroutine(ToggleStarPuzzle(true));
    }

    public IEnumerator ToggleStarPuzzle(bool on)
    {
        if (transitioning) yield break;
        transitioning = true;
        fadeInOutPanelAnimator.SetFloat("speed", 5f);
        fadeInOutPanelAnimator.SetTrigger("FadeToBlack");

        while (!fadeInOutPanelAnimator.GetCurrentAnimatorStateInfo(0).IsName("Black"))
        {
            yield return null;
        }

        mainCamera.SetActive(!on);
        starPuzzle.SetActive(on);
        UnityEngine.Cursor.visible = on;
        fadeInOutPanelAnimator.SetTrigger("FadeFromBlack");
        transitioning = false;

        while (!fadeInOutPanelAnimator.GetCurrentAnimatorStateInfo(0).IsName("Transparent"))
        {
            yield return null;
        }

        fadeInOutPanelAnimator.SetFloat("speed", 1f);
    }
}

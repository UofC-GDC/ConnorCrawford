using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarExitButton : Singleton<StarExitButton> 
{
    [SerializeField] private Animator fadeInOutPanelAnimator;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject starPuzzle;

    private bool transitioning = false;

    [ContextMenu("DisableStarPuzzle")]
    public void DisableStarPuzzle()
    {
        StartCoroutine(ToggleStarPuzzle(false));
    }

    [ContextMenu("ActivateStarPuzzle")]
    public void ActivateStarPuzzle()
    {
        StartCoroutine(ToggleStarPuzzle(true));
    }

    public IEnumerator ToggleStarPuzzle(bool on)
    {
        if (transitioning) yield break;
        transitioning = true;
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
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoIntro : MonoBehaviour
{
    [SerializeField] private AudioSource logoAudio;
    [SerializeField] private Animator panelAnimator;
    [SerializeField] private Animator logoAnimator;
    [Range(0,10)]
    [SerializeField] private float transitionTime = 4f;

    private void Awake()
    {
        UnityEngine.Cursor.visible = false;
    }

    void Start ()
    {
        UnityEngine.Cursor.visible = false;
        AudioManager.Instance.transitionTime = 3 * transitionTime;
        AudioManager.Instance.MainThemeDay();
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        panelAnimator.SetTrigger("FadeFromBlack");
        yield return new WaitForSeconds(transitionTime);
        logoAnimator.SetTrigger("Logo");
        logoAudio.Play();
        yield return new WaitForSeconds(transitionTime);
        panelAnimator.SetTrigger("FadeToBlack");
        yield return new WaitForSeconds(transitionTime*2);
        SceneManager.LoadScene("Morning(Clean)");
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoIntro : MonoBehaviour
{
    [SerializeField] private AudioSource logoAudio;
    [SerializeField] private Animator panelAnimator;
    [SerializeField] private Animator logoAnimator;

    private void Awake()
    {
        UnityEngine.Cursor.visible = false;
    }

    void Start ()
    {
        UnityEngine.Cursor.visible = false;
        AudioManager.Instance.transitionTime = 12;
        AudioManager.Instance.MainThemeDay();
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        panelAnimator.SetTrigger("FadeFromBlack");
        yield return new WaitForSeconds(4);
        logoAnimator.SetTrigger("Logo");
        logoAudio.Play();
        yield return new WaitForSeconds(4);
        panelAnimator.SetTrigger("FadeToBlack");
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Morning(Clean)");
    }
}

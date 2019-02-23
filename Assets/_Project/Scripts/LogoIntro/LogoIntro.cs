using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoIntro : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource logoAudio;
    [SerializeField] private Animator panelAnimator;
    [SerializeField] private Animator logoAnimator;

    void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
        audioSource.Play();
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        yield return new WaitForSeconds(4);
        logoAnimator.SetTrigger("Logo");
        logoAudio.Play();
        yield return new WaitForSeconds(4);
        panelAnimator.SetTrigger("FadeToBlack");
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Main");
    }
}

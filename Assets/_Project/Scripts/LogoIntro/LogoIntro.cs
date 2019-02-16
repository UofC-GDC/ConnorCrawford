using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoIntro : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float introTime = 5;
    [SerializeField] private Animator panelAnimator;

	void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
        audioSource.Play();
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        yield return new WaitForSeconds(introTime/2);
        panelAnimator.SetTrigger("FadeToBlack");
        yield return new WaitForSeconds(introTime / 2);
        SceneManager.LoadScene("Main");
    }
}

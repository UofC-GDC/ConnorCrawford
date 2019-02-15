using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;

    // This GameObject should detect clicks outside the pause menu and close it
    // Only have it here so I can make it appear/disapear when resuming/pausing
    [SerializeField] GameObject pauseClosingField;

    public void Resume()
    {
        pauseMenu.SetActive(false);
        pauseClosingField.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        paused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        pauseClosingField.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        paused = true;
    }

    public void Volume()
    {

    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
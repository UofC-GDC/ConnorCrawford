using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    [Tooltip("The number of frames to pause for after each character.")]
    [Range(0, .25f)]
    [SerializeField] private float waitForSeconds;
    [Range(0, .25f)]
    [SerializeField] private float endPauseTime;
    private AudioSource audioSource;
    private AnimationCurve curve;
    private float startPitch;

    private IEnumerator<string> lineEnumerator;

    public bool doneLines{
        get;
        private set;
    }

    public void SetupLines(List<string> lines, GameObject speechBubble, TextMeshPro style, GameObject nextButton, AudioSource audioSource, AnimationCurve curve)
    {
        speechBubble.SetActive(true);
        StopAllCoroutines();
        lineEnumerator = lines.GetEnumerator();
        lineEnumerator.MoveNext();
        this.speechBubble = speechBubble;
        this.speechBubbleText = style;
        this.nextButton = nextButton;
        startPitch = audioSource.pitch;
        this.audioSource = audioSource;
        this.curve = curve;
        doneLines = false;

        PlayNextLine();
    }

    GameObject speechBubble;
    TextMeshPro speechBubbleText;
    GameObject nextButton;

    private void PlayNextLine()
    {
        //Debug.Log("Playing Next Line");
        if (lineEnumerator == null)
        {
            ResetSpeechBubble(speechBubble, speechBubbleText);
            return;
        }

        if (lineEnumerator.Current == null)
        {
            ResetSpeechBubble(speechBubble, speechBubbleText);
            return;
        }

        else
        {
            var lineToPlay = lineEnumerator.Current;
            lineEnumerator.MoveNext();
            var moreLines = lineEnumerator.Current != null;
            nextButton.SetActive(moreLines);
            PlayLine(lineToPlay, moreLines, speechBubble, speechBubbleText);
            audioSource.pitch = startPitch;
            return;
        }
    }

    private void ResetSpeechBubble(GameObject speechBubble, TextMeshPro speechBubbleText)
    {
        doneLines = true;
        lineEnumerator = null;
        speechBubbleText.text = "";
        audioSource.pitch = startPitch;
        speechBubble.SetActive(false);
    }

    private void PlayLine(string line, bool moreLines, GameObject speechBubble, TextMeshPro speechBubbleText)
    {
        StopAllCoroutines();
        StartCoroutine(_PlayLine(line, moreLines, speechBubble, speechBubbleText));
    }

    private IEnumerator _PlayLine(string line, bool moreLines, GameObject speechBubble, TextMeshPro speechBubbleText)
    {
        var text = "";
        char lastChar = ' ';
        foreach (var character in line)
        {
            #region Update Bubble
            text += character;
            speechBubbleText.text = text;
            #endregion

            #region Audio Playing
            if (character.Equals('?') || character.Equals('!'))
            {
                audioSource.pitch = startPitch + curve.Evaluate(1) + .1f;
                audioSource.Play();
            }
            else if (character.Equals(lastChar))
            {
                audioSource.Play();
            }
            else if (!System.Char.IsWhiteSpace(character))
            {
                audioSource.pitch = startPitch + curve.Evaluate(Random.value);
                audioSource.Play();
            }
            #endregion

            #region Waiting
            yield return new WaitForSecondsRealtime(waitForSeconds);

            if (character.Equals(','))
            {
                yield return new WaitForSecondsRealtime(waitForSeconds * 2);
            }
            if (character.Equals('.'))
            {
                yield return new WaitForSecondsRealtime(waitForSeconds * 4);
            }
            #endregion

            lastChar = character;
        }
        if (!moreLines)
        {
            yield return new WaitForSecondsRealtime(endPauseTime * line.Length);
            ResetSpeechBubble(speechBubble, speechBubbleText);
        }
    }
}

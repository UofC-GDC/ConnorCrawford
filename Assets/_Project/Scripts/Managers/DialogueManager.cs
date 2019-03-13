using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField] private GameObject speechBubble;
    [SerializeField] private TextMeshPro speechBubbleText;
    [SerializeField] private GameObject nextButton;
    [Tooltip("The number of frames to pause for after each character.")]
    [Range(0, 60)]
    [SerializeField] private int waitForFramesNumber;

    private IEnumerator<string> lineEnumerator;

    public bool doneLines{
        get;
        private set;
    }

    public void SetupLines(List<string> lines, TextMeshPro style)
    {
        speechBubble.SetActive(true);
        StopAllCoroutines();
        lineEnumerator = lines.GetEnumerator();
        lineEnumerator.MoveNext();
        PlayNextLine();
        doneLines = false;
    }

    public void PlayNextLine()
    {
        //Debug.Log("Playing Next Line");
        if (lineEnumerator == null)
        {
            ResetSpeechBubble();
            return;
        }

        if (lineEnumerator.Current == null)
        {
            ResetSpeechBubble();
            return;
        }

        else
        {
            var lineToPlay = lineEnumerator.Current;
            lineEnumerator.MoveNext();
            var moreLines = lineEnumerator.Current != null;
            nextButton.SetActive(moreLines);
            PlayLine(lineToPlay, moreLines);
            return;
        }
    }

    private void ResetSpeechBubble()
    {
        doneLines = true;
        lineEnumerator = null;
        speechBubbleText.text = "";
        speechBubble.SetActive(false);
    }

    private void PlayLine(string line, bool moreLines)
    {
        StopAllCoroutines();
        StartCoroutine(_PlayLine(line, moreLines));
    }

    private IEnumerator _PlayLine(string line, bool moreLines)
    {
        var text = "";
        foreach (var character in line)
        {
            text += character;
            speechBubbleText.text = text;
            for (int i = 0; i < waitForFramesNumber; i++)
            {
                yield return null;
            }
        }
        if (!moreLines)
        {
            yield return new WaitForSeconds(1.25f);
            ResetSpeechBubble();
        }
    }
}

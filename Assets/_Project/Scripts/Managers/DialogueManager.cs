using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    [Tooltip("The number of frames to pause for after each character.")]
    [Range(0, 60)]
    [SerializeField] private int waitForFramesNumber;

    private IEnumerator<string> lineEnumerator;

    public bool doneLines{
        get;
        private set;
    }

    public void SetupLines(List<string> lines, GameObject speechBubble, TextMeshPro style, GameObject nextButton)
    {
        speechBubble.SetActive(true);
        StopAllCoroutines();
        lineEnumerator = lines.GetEnumerator();
        lineEnumerator.MoveNext();
        this.speechBubble = speechBubble;
        this.speechBubbleText = style;
        this.nextButton = nextButton;
        PlayNextLine();
        doneLines = false;
    }

    GameObject speechBubble;
    TextMeshPro speechBubbleText;
    GameObject nextButton;

    public void PlayNextLine()
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
            return;
        }
    }

    private void ResetSpeechBubble(GameObject speechBubble, TextMeshPro speechBubbleText)
    {
        doneLines = true;
        lineEnumerator = null;
        speechBubbleText.text = "";
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
            ResetSpeechBubble(speechBubble, speechBubbleText);
        }
    }
}

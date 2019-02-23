using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour 
{
    [SerializeField] private GameObject connerSpeechBubble;
    [SerializeField] private TextMeshPro connerSpeechBubbleText;
    [SerializeField] private GameObject nextButton;
    [Tooltip("The number of frames to pause for after each character.")]
    [Range(0,60)]
    [SerializeField] private int waitForFramesNumber;

    private IEnumerator<string> lineEnumerator;

    public void SetupLines(InsightOption option)
    {
        connerSpeechBubble.SetActive(true);
        StopAllCoroutines();
        lineEnumerator = option.insightOption.GetEnumerator();
        lineEnumerator.MoveNext();
        PlayNextLine();
    }

    public void PlayNextLine()
    {
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
        }
    }

    private void ResetSpeechBubble()
    {
        lineEnumerator = null;
        connerSpeechBubbleText.text = "";
        connerSpeechBubble.SetActive(false);
    }

    private void PlayLine(string line, bool moreLines)
    {
        StartCoroutine(_PlayLine(line, moreLines));
    }

    private IEnumerator _PlayLine(string line, bool moreLines)
    {
        var text = "";
        foreach (var character in line)
        {
            text += character;
            connerSpeechBubbleText.text = text;
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

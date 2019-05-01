using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlideMe : MonoBehaviour 
{
    [SerializeField] private Vector3 start;
    [SerializeField] private Vector3 end;

    [SerializeField] private RadioInteract radioInteract;
    [SerializeField] private BatteryInteract batteries;

    public void SetSlide(float t)
    {
        t = Mathf.Clamp01(t);
        transform.localPosition = Vector3.Lerp(start, end, t);

        var percentToConnerStation = Mathf.Abs(t - (.0468f / .2267f)) / .8f;
        if (percentToConnerStation < .015 && !started && (!batteries.battery1 && !batteries.battery2))
        {
            StartCoroutine(FadeInConnerRadioText());
        }
        else
        {
            StopCoroutine(FadeInConnerRadioText());
            textBubble.color = new Color(textBubble.color.r, textBubble.color.g, textBubble.color.b, 0);
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
            started = false;
        }
        radioInteract.SetConnerSound(percentToConnerStation);
    }

    bool started = false;

    [SerializeField] private SpriteRenderer textBubble;
    [SerializeField] private TextMeshPro text;

    public IEnumerator FadeInConnerRadioText()
    {
        started = true;

        yield return new WaitForSecondsRealtime(4f);

        var timeStart = Time.time;

        while (!Mathf.Approximately(textBubble.color.a, 1))
        {
            var a = (Time.time-timeStart)/2f;
            textBubble.color = new Color(textBubble.color.r, textBubble.color.g, textBubble.color.b, a);
            text.color = new Color(text.color.r, text.color.g, text.color.b, a);
            yield return null;
        }

        started = true;
    }

    //public IEnumerator FadeOutConnerRadioText()
    //{
    //    var timeStart = Time.time;

    //    while (!Mathf.Approximately(textBubble.color.a, 0))
    //    {
    //        var a = (Time.time - timeStart) / 2f;
    //        a = Mathf.Clamp01(1 - a);
    //        textBubble.color = new Color(textBubble.color.r, textBubble.color.g, textBubble.color.b, a);
    //        text.color = new Color(text.color.r, text.color.g, text.color.b, a);
    //        yield return null;
    //    }
    //}
}

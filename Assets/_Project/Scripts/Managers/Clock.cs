using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Singleton<Clock>
{
    #region Setup
    [SerializeField] private int startInState = 2;

    [SerializeField] private int waitForFramesSpin = 5;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioSource audioSource;

    private int currentClockIndex = 0;
    private Sprite[] clockSprites;

    private void Start()
    {
        clockSprites = Resources.LoadAll<Sprite>("clock");
        SetClock(startInState);
        audioSource.loop = true;
    }
    #endregion

    #region Refrence / Lookup / Static
    private static int TimeToClockIndex(int hour, int minute)
    {
        if (minute >= 60 || minute < 0 || minute % 7.5f != 0 || hour > 24 || hour < 0)
            return -1;

        int m = (int) (minute / 7.5);
        int h = (hour % 12) * 8;
        int i = h + m;

        return i;
    }

    public static Dictionary<int, System.Tuple<int, int>> timeLookUp = new Dictionary<int, System.Tuple<int, int>>()
    {
        {1, new System.Tuple<int, int>(8, 30)},
        {2, new System.Tuple<int, int>(12+4, 45)},
        {3, new System.Tuple<int, int>(12+5, 15)},
        {4, new System.Tuple<int, int>(12+5, 45)},
        {5, new System.Tuple<int, int>(12+6, 15)},
        {6, new System.Tuple<int, int>(12+6, 30)},
        {7, new System.Tuple<int, int>(12+7, 15)},
        {8, new System.Tuple<int, int>(12+8, 00)},
        {9, new System.Tuple<int, int>(8, 45)},
        {10, new System.Tuple<int, int>(9, 00)},
        {11, new System.Tuple<int, int>(9, 15)},
        {12, new System.Tuple<int, int>(11, 30)},
        {13, new System.Tuple<int, int>(12+1, 15)},
        {14, new System.Tuple<int, int>(12+3, 45)},
        {15, new System.Tuple<int, int>(12+4, 00)},
        {16, new System.Tuple<int, int>(12+4, 15)},
        {17, new System.Tuple<int, int>(4, 30)},
        {18, new System.Tuple<int, int>(7, 30)},
    };
    #endregion

    #region Methods
    public void SetClock(int i)
    {
        var tup = timeLookUp[i];
        var nextIndex = TimeToClockIndex(tup.Item1, tup.Item2);

        StartCoroutine(SpinToIndex(nextIndex));
    }

    private IEnumerator SpinToIndex(int indexToSpinTo)
    {
        if (!audioSource.isPlaying)
            audioSource.Play();

        if (indexToSpinTo < currentClockIndex)
        {
            yield return StartCoroutine(SpinToIndex(clockSprites.Length -1));
            for (int i = 0; i < waitForFramesSpin; i++)
            {
                yield return null;
            }
            spriteRenderer.sprite = clockSprites[currentClockIndex = 0];
        }
        else if (indexToSpinTo == currentClockIndex) {
            audioSource.Stop();
            yield break;
        }

        while (currentClockIndex < indexToSpinTo)
        {
            spriteRenderer.sprite = clockSprites[++currentClockIndex];

            for (int i = 0; i < waitForFramesSpin; i++)
            {
                yield return null;
            }
        }
        audioSource.Stop();
    }
    #endregion

    //#region Testing
    //[Header("Testing")]

    //[Range(0, 95)]
    //[SerializeField] private int iToSetTo = 0;

    //[ContextMenu("SetClockToProvidedIntI")]
    //private void SetClockToProvidedIntI()
    //{
    //    spriteRenderer.sprite = clockSprites[iToSetTo];
    //    StartCoroutine(SpinToIndex(iToSetTo));
    //}
    //#endregion
}

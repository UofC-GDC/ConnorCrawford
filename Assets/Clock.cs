using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Singleton<Clock>
{
    [SerializeField] private int waitForFramesSpin;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private int currentClockIndex = 0;

    private void Start()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("clock");
    }

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
        {8, new System.Tuple<int, int>(8, 45)},
        {9, new System.Tuple<int, int>(9, 00)},
        {10, new System.Tuple<int, int>(9, 15)},
        {11, new System.Tuple<int, int>(11, 30)},
        {12, new System.Tuple<int, int>(12+1, 15)},
        {13, new System.Tuple<int, int>(12+3, 45)},
        {14, new System.Tuple<int, int>(12+4, 00)},
        {15, new System.Tuple<int, int>(12+4, 15)},
        {16, new System.Tuple<int, int>(4, 30)},
        {17, new System.Tuple<int, int>(7, 30)}
    };
    #endregion

    //public void SetClock(int i)
    //{
    //    var tup = timeLookUp[i];
    //    var nextIndex = TimeToClockIndex(tup.Item1, tup.Item2);

    //    StartCoroutine(SpinToIndex(nextIndex));
    //}

    ////private IEnumerator SpinToIndex(int indexToSpinTo)
    ////{
    ////    if (indexToSpinTo < currentClockIndex)
    ////    {
    ////        StartCoroutine(SpinToIndex(maxxy));
    ////        //fixitBacktO begiining
    ////    }
    ////    else if (indexToSpinTo == currentClockIndex)
    ////        yield break;

    ////    while (currentClockIndex < indexToSpinTo)
    ////    {
    ////        //Set to index++
    ////        spriteRenderer.sprite =
    ////        //WIP
    ////        for (int i = 0; i < waitForFramesSpin; i++)
    ////        {
    ////            yield return null;
    ////        }
    ////    }
    ////}

    private void Update()
    {

    }
}

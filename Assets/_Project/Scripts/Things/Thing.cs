using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Describes all things in the game. At a basic level, will return the inisghts associated
 * with an Object
 * 
 * Implement Action to specify custom actions of the thing
 **/
abstract public class Thing : MonoBehaviour
{

    public Insight insight;

    protected IEnumerator<InsightOption> insightEnumerator;

    private void Awake()
    {
        insightEnumerator = insight.text.GetEnumerator();
    }

    public virtual void OnLeftClick()
    {

    }

    public virtual void OnRightClick()
    {

    }

    public virtual State Action(StateManager.Env env, ref Player player)
    {
        Cursor.Instance.ShakeMouse();
        return null;
    }


    public virtual InsightOption GetInsightOption()
    {
        insightEnumerator.MoveNext();
        if (insightEnumerator.Current == null)
        {
            insightEnumerator.Reset();
            insightEnumerator.MoveNext();
        }

        return insightEnumerator.Current;
    }
}

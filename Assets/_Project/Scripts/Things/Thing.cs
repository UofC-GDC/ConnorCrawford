using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Describes all things in the game. At a basic level, will return the inisghts associated
 * with an Object
 * 
 * Implement Action to specify custom actions of the thing
 **/
abstract public class Thing : MonoBehaviour {

    public List<List<Insight>> insights;

    protected IEnumerator<List<Insight>> insightEnumerator;

    private void Awake()
    {
        insightEnumerator = insights.GetEnumerator();
    }

    public virtual void OnLeftClick()
    {

    }

    public virtual void OnRightClick()
    {
        
    }

    public virtual State Action()
    {
        return null;
    }


    public virtual List<Insight> GetInsight()
    {
        insightEnumerator.MoveNext();
        return insightEnumerator.Current;
    }
}

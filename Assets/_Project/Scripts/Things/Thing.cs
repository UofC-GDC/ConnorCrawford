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

    public Insight insight;

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


    public virtual InsightOption GetInsight()
    {
        return insight.text[Random.Range(0, insight.text.Count)];
    }
}

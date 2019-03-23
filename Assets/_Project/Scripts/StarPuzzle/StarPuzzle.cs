﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WhyIHateThis
{
    public List<Star> solutionOption;
}


public class StarPuzzle : MonoBehaviour 
{
    [SerializeField] private LineRenderer lineRenderer;

    public List<WhyIHateThis> starSolutions = new List<WhyIHateThis>();

    private void Start()
    {
        lineRenderer.positionCount = 0;
    }

    Vector3 mousePos;

    bool allDone = false;
    bool youDidIt = false;

    private void Update()
    {
        if (allDone)
        {
            foreach (var starSolution in starSolutions)
            {
                var putItInHere = new Vector3[lineRenderer.positionCount];
                lineRenderer.GetPositions(putItInHere);
                if (!CheckListEqual(putItInHere, starSolution))
                {
                    youDidIt = false;
                }
                else
                {
                    youDidIt = true;
                    break;
                }
            }
        }

        if (allDone && youDidIt)
        {
            print("You Did It");
        }


        if (Input.GetMouseButtonUp(1))
        {
            lineRenderer.positionCount = 0;
            allDone = false;
        }

        if (allDone)
        {
            return;
        }

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        var endPos = transform.position = mousePos;

        var closestStar = FindClosestStar();
        if (closestStar != null)
        {
            endPos = closestStar.transform.position;
            if (Input.GetMouseButtonUp(0))
            {
                AddStar(endPos);
            }
        }

        if(lineRenderer.positionCount != 0)
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, endPos);
    }

    private bool CheckListEqual(System.Array array, WhyIHateThis why)
    {
        if (array.Length != why.solutionOption.Count) return false;

        for (int i = 0; i < array.Length-1; i++)
        {
            if (!((Vector3)array.GetValue(i)).ApproximatelyEquality(why.solutionOption[i].transform.position))
            {
                return false;
            }
        }

        return true;
    }

    private void AddStar(Vector3 pos)
    {
        for (int i = 0; i < lineRenderer.positionCount-1; i++)
        {
            if (pos == lineRenderer.GetPosition(i))
            {
                allDone = true;
            }
        }
        if(!allDone)
            lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, pos);
        if (lineRenderer.positionCount == 1) lineRenderer.positionCount++;
    }

    /// <summary>
    /// null when no star in range
    /// </summary>
    /// <returns></returns>
    private Star FindClosestStar()
    {
        var winningDistanceSqr = Mathf.Infinity;
        Star winningStar = null;

        foreach (var star in starsInRange)
        {
            var thisDisSqr = (star.transform.position - mousePos).sqrMagnitude;
            if (thisDisSqr < winningDistanceSqr)
            {
                winningDistanceSqr = thisDisSqr;
                winningStar = star;
            }
        }

        return winningStar;
    }

    public List<Star> starsInRange = new List<Star>();

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Star")) return;

        starsInRange.Add(other.GetComponent<Star>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Star")) return;

        starsInRange.Remove(other.GetComponent<Star>());
    }
}

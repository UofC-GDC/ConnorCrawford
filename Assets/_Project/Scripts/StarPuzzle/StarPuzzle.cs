﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class WhyIHateThis
{
    public List<Star> solutionOption;
}


public class StarPuzzle : MonoBehaviour 
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Camera starCamera;
    [SerializeField] private GameObject puzzle1;
    [SerializeField] private GameObject puzzle2;
    [SerializeField] private Animator fadeInOutPanelAnimator;
    [SerializeField] private Animator lineRendererAnimator;

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject starPuzzle;
    [SerializeField] private TimeMachine timeMachine;

    public List<WhyIHateThis> starSolutions = new List<WhyIHateThis>();

    private void Start()
    {
        lineRenderer.positionCount = 0;
    }

    Vector3 mousePos;

    bool youDidIt = false;

    private void Update()
    {
        if (lineRenderer.positionCount > 2)
        { 
            foreach (var starSolution in starSolutions)
            {
                var putItInHere = new Vector3[lineRenderer.positionCount];
                lineRenderer.GetPositions(putItInHere);

                var nowPutItInHere = new Vector3[lineRenderer.positionCount-1];
                nowPutItInHere = putItInHere.Take(putItInHere.Count() - 1).ToArray();

                if (!CheckListEqual(nowPutItInHere, starSolution))
                {
                    youDidIt = false;
                }
                else
                {
                    youDidIt = true;
                    lineRenderer.positionCount = starSolution.solutionOption.Count;
                    break;
                }
            }
        }

        //if (Input.GetKeyDown(KeyCode.S)) youDidIt = true;

        if (youDidIt)
        {
            if (!puzzle2.activeInHierarchy)
            { 
                if(!transitioning)
                    StartCoroutine(ActivateStarPuzzle2(false));
            }
            else
            {
                timeMachine.readyToTimeTravel = true;
                if (!transitioning)
                    StartCoroutine(ActivateStarPuzzle2(true));
            }
        }

        if (youDidIt || transitioning) return;

        if (Input.GetMouseButtonUp(1))
        {
            lineRenderer.positionCount = 0;
            connections.Clear();
            lastStar = null;
            return;
        }

        mousePos = starCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        var endPos = transform.position = mousePos;

        var closestStar = FindClosestStar();
        if (closestStar != null)
        {
            endPos = closestStar.transform.position;
            if(Input.GetMouseButtonUp(0))
                AddStar(closestStar);
        }

        if (lineRenderer.positionCount != 0)
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, endPos);
    }

    private bool transitioning = false;

    public bool complete=false;

    private IEnumerator ActivateStarPuzzle2(bool puzzle2Done)
    {
        transitioning = true;
        lineRendererAnimator.SetTrigger("Win");

        if (puzzle2Done)
        {
            Clock.Instance.SetClock(8);
            StarExitButton.Instance.DisableStarPuzzle();
            complete = true;
        }
        else
        {
            Clock.Instance.SetClock(7);
            fadeInOutPanelAnimator.SetTrigger("FadeToBlack");
        }

        while (!fadeInOutPanelAnimator.GetCurrentAnimatorStateInfo(0).IsName("Black"))
        {
            yield return null;
        }


        lineRenderer.positionCount = 0;
        youDidIt = false;
        connections.Clear();
        lastStar = null;
        if (!puzzle2Done)
        {
            fadeInOutPanelAnimator.SetTrigger("FadeFromBlack");
        }
        transitioning = false;

        if (puzzle2Done)
        {
            puzzle1.SetActive(false);
            puzzle2.SetActive(false);
        }
        else
        {
            puzzle1.SetActive(false);
            puzzle2.SetActive(true);
        }
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

    private Star lastStar = null;
    private List<HashSet<Star>> connections = new List<HashSet<Star>>();

    private void AddStar(Star star)
    {
        if (lastStar != null)
        {
            var newConnection = new HashSet<Star>();
            newConnection.Add(star);
            newConnection.Add(lastStar);

            var goodConnection = true;

            foreach (var connection in connections)
            {
                if (connection.SetEquals(newConnection))
                {
                    goodConnection = false;
                    break;
                }
            }
            if (!goodConnection)
            {
                Cursor.Instance.ShakeMouse();
                return;
            }
        }
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, star.transform.position);

        if (lineRenderer.positionCount == 1)
        {
            lineRenderer.positionCount++;
        }
        else
        {
            var connection = new HashSet<Star>();
            connection.Add(star);
            connection.Add(lastStar);
            connections.Add(connection);
        }

        lastStar = star;
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

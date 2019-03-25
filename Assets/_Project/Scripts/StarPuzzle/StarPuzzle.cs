using System.Collections;
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
    [SerializeField] private Camera starCamera;
    [SerializeField] private GameObject puzzle1;
    [SerializeField] private GameObject puzzle2;
    [SerializeField] private Animator fadeInOutPanelAnimator;
    [SerializeField] private Animator lineRendererAnimator;

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
            if (!puzzle2.activeInHierarchy)
            { 
                if(!transitioning)
                    StartCoroutine(ActivateStarPuzzle2());
            }
            else
            {
                if (!transitioning)
                    StartCoroutine(ActivateStarPuzzle2());
            }
        }


        if (Input.GetMouseButtonUp(1))
        {
            if (!allDone)
            {
                allDone = true;
                lineRenderer.positionCount--;
            }
            else
            {
                lineRenderer.positionCount = 0;
                allDone = false;
                connections.Clear();
                lastStar = null;
            }
        }

        if (allDone)
        {
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

    private IEnumerator ActivateStarPuzzle2()
    {
        transitioning = true;
        lineRendererAnimator.SetTrigger("Win");
        fadeInOutPanelAnimator.SetTrigger("FadeToBlack");

        while (!fadeInOutPanelAnimator.GetCurrentAnimatorStateInfo(0).IsName("Black"))
        {
            yield return null;
        }

        lineRenderer.positionCount = 0;
        allDone = false;
        youDidIt = false;
        connections.Clear();
        lastStar = null;
        puzzle1.SetActive(false);
        puzzle2.SetActive(true);
        fadeInOutPanelAnimator.SetTrigger("FadeFromBlack");
        transitioning = false;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealStarPuzzleAnswer : MonoBehaviour 
{
    [SerializeField] private GameObject puzzle1;
    [SerializeField] private GameObject puzzle2;

    [SerializeField] private GameObject puzzle1Answer;
    [SerializeField] private GameObject puzzle2Answer;

    public void ShowAnswer()
    {
        if (puzzle1.activeInHierarchy)
            puzzle1Answer.SetActive(true);
        if (puzzle2.activeInHierarchy)
            puzzle2Answer.SetActive(true);
    }
}

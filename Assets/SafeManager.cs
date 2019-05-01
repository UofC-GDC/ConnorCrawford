using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeManager : MonoBehaviour 
{
    [SerializeField] private List<SafeInteract> dials = new List<SafeInteract>(4);

    [SerializeField] public GameObject keyVis;
    public Key key;

    private void Start()
    {
        key = GetComponent<Key>();
    }

    bool complete = false;

    private void Update () 
    {
        if (dials.Count >= 4)
        {
            if (dials[0].currentIndex == 5 && dials[1].currentIndex == 3 && dials[2].currentIndex == 3 && dials[3].currentIndex == 5)
            {
                complete = true;
            }
            else
            {
                complete = false;
            }
        }
	}

    public bool CompleteCheck()
    {
        return complete;
    }
}

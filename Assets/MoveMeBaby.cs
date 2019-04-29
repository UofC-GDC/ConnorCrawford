using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMeBaby : MonoBehaviour 
{
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.localPosition;
    }

    public void UpdatePos(float t)
    {
        transform.localPosition = new Vector3(startPos.x + t, transform.localPosition.y, transform.localPosition.z);
    }
}

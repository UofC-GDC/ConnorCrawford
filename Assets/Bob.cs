using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour 
{
    [SerializeField] private Vector3 top;
    [SerializeField] private Vector3 bottom;

    [SerializeField] private float speed;

    private float t = 0;

    private void Update () 
    {
        transform.localPosition = Vector3.Lerp(bottom, top, t);
        t = (1 - Mathf.Sin(Time.time * speed)) / 2f;
	}
}

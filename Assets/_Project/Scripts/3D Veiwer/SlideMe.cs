using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMe : MonoBehaviour 
{
    [SerializeField] private Vector3 start;
    [SerializeField] private Vector3 end;

    public void SetSlide(float t)
    {
        t = Mathf.Clamp01(t);
        transform.localPosition = Vector3.Lerp(start, end, t);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : Singleton<Cursor> 
{
    [SerializeField] private AudioSource mouseShake;
    [SerializeField] private new Camera camera;
    [SerializeField] private float cursorDistance;

    public void ShakeMouse()
    {
        mouseShake.Play();
    }

    private void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        transform.localPosition = ray.origin + ray.direction.normalized * cursorDistance;
    }
}

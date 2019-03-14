using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : Singleton<Cursor> 
{
    [SerializeField] private AudioSource mouseShake;

    public void ShakeMouse()
    {
        mouseShake.Play();
    }
}

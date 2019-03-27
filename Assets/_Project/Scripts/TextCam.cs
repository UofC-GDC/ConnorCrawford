using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCam : MonoBehaviour 
{
    [SerializeField] private Camera cam;

    [SerializeField] private Camera mainCam;
	
    int wait = 0;
	private void Update () 
    {
        if (wait == 0)
        {
            wait++;
        }
        else { 
            cam.gameObject.SetActive(true);
            cam.orthographicSize = mainCam.orthographicSize;
            UnityEngine.Cursor.visible = false;
            enabled = false;
        }
    }
}

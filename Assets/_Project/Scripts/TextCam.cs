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
        if (wait != 5)
        {
            wait++;
        }
        else { 
            cam.gameObject.SetActive(true);
            UnityEngine.Cursor.visible = false;
            enabled = false;
        }

        cam.orthographicSize = mainCam.orthographicSize;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCam : MonoBehaviour 
{
    [SerializeField] private Camera cam;

    [SerializeField] private Camera mainCam;

    private void OnEnable()
    {
        StartCoroutine(TheFunction());
    }

    private IEnumerator TheFunction()
    {
        cam.gameObject.SetActive(true);
        for (int i = 0; i < 5f; i++)
        {
            cam.orthographicSize = mainCam.orthographicSize;
            yield return null;
        }
        cam.gameObject.SetActive(false);
        yield return null;
        cam.gameObject.SetActive(true);
        UnityEngine.Cursor.visible = false;
        cam.orthographicSize = mainCam.orthographicSize;
    }

    private void LateUpdate()
    {
        cam.orthographicSize = mainCam.orthographicSize;
    }
}

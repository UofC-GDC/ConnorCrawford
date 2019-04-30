using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMask : MonoBehaviour 
{

    [SerializeField] private Sprite leftClick;
    [SerializeField] private Sprite rightClick;
    [SerializeField] private Sprite full;

    private SpriteMask spriteMask;

    private void Start () 
    {
        spriteMask = GetComponent<SpriteMask>();
    }
	
	private void Update () 
    {
        Sprite sprite = null;

        if (Input.GetMouseButton(0)) sprite = leftClick;
        if (Input.GetMouseButton(1)) sprite = rightClick;
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1)) sprite = full;

        spriteMask.sprite = sprite;
    }
}

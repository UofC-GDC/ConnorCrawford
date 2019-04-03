using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : Singleton<Cursor> 
{
    [SerializeField] private AudioSource mouseShake;
    [SerializeField] private new Camera camera;
    [SerializeField] private float cursorDistance;
    [SerializeField] private SpriteRenderer image;

    [SerializeField] private Sprite cursorNoInv;
    [SerializeField] private Sprite cursorInv;
    [SerializeField] private Sprite diamondCursorNoInv;
    [SerializeField] private Sprite diamondCursorInv;

    private void Start()
    {
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
    }

    public void ShakeMouse()
    {
        Debug.Log("Mouse says you cannot", this);
        mouseShake.Play();
    }

    private void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        transform.localPosition = ray.origin + ray.direction.normalized * cursorDistance;

        if (StateManager.Instance.env.player.inventory == null)
        {
            if (DarknessManager.Instance.flashlightBlue)
                image.sprite = diamondCursorNoInv;
            else 
                image.sprite = cursorNoInv;
        }
        else
        {
            if (DarknessManager.Instance.flashlightBlue)
                image.sprite = diamondCursorInv;
            else 
                image.sprite = cursorInv;
        }
    }
}

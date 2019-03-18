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

    private void Start()
    {
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
    }

    public void ShakeMouse()
    {
        mouseShake.Play();
    }

    private void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        transform.localPosition = ray.origin + ray.direction.normalized * cursorDistance;

        if (StateManager.Instance.env.player.inventory == null)
        {
            image.sprite = cursorNoInv;
        }
        else
        {
            image.sprite = cursorInv;
        }
    }
}

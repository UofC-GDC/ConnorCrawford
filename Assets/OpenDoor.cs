using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : Interatable3D 
{
    [SerializeField] private GameObject origin;

    private Vector3 mouseStartPos;
    [SerializeField]  private Slider slider;

    protected override void interactStart()
    {
        mouseStartPos = Input.mousePosition;
    }

    public override void interact(StateManager.Env env, ref Player player)
    {
        if (slider.value <= slider.maxValue / 2f)
            return;
        origin.transform.Rotate(origin.transform.forward, (Input.mousePosition - mouseStartPos).x);
    }
}

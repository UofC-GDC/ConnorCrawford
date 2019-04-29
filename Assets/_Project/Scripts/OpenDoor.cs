using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : Interatable3D 
{
    [SerializeField] private GameObject origin;

    //private Vector3 mouseStartPos;
    [SerializeField]  private Slider slider;
    [Range(0,1)]
    [SerializeField] private float sensitivity;

    protected override void interactStart()
    {
        lastPos = Input.mousePosition;
    }

    private Vector3 lastPos;

    public override void interact(StateManager.Env env, ref Player player)
    {
        if (slider.value <= 0.1359014f)
            return;

        var angle = (Input.mousePosition - lastPos).x * sensitivity;
        lastPos = Input.mousePosition;

        origin.transform.Rotate(Vector3.forward, angle, Space.Self);

        if(origin.transform.localRotation.eulerAngles.z <= 100f)
            origin.transform.localRotation = Quaternion.Euler(origin.transform.localRotation.x, origin.transform.localRotation.y, 359.9999f);
        else
        origin.transform.localRotation = Quaternion.Euler(origin.transform.localRotation.x, origin.transform.localRotation.y, Mathf.Clamp(origin.transform.localRotation.eulerAngles.z, 180f, 359.9999f));
    }
}

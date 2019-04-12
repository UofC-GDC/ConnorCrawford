using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : Interatable3D
{
    [SerializeField] private GameObject itsAbird;
    [SerializeField] private Camera cameraToShootLasersFrom;
    [SerializeField] private LayerMask layerMaskToShoot;

    public override void interact(StateManager.Env env, ref Player player)
    {
        RaycastHit hit3D;
        Ray ray = cameraToShootLasersFrom.ScreenPointToRay(Input.mousePosition);

        var dist = 100f;
        if (Physics.Raycast(ray, out hit3D, dist, 1<<13 /*layerMaskToShoot.Layermask_to_layer()*/))
        {
            transform.position = hit3D.point;

            Debug.DrawLine(ray.origin, hit3D.point, Color.green);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.GetPoint(dist), Color.red);
        }
    }
    protected override void interactStart()
    {
        base.interactStart();
        itsAbird.SetActive(true);
    }

    protected override void interactEnd()
    {
        base.interactEnd();
        itsAbird.SetActive(false);
    }
}

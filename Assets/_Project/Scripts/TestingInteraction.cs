using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestingInteraction : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AudioSource noInteractionSound;

    private int mouseClick = -1;
    private bool hasTarget = false;
    private Ray ray;
    private Thing thing = null;

    void Update ()
    {
        if (!hasTarget)
        {
            mouseClick = -1;
            if (Input.GetMouseButtonDown(0)) mouseClick = 0;
            if (Input.GetMouseButtonDown(1)) mouseClick = 1;
            if (mouseClick != -1 && HitDiegeticObject())
            {
                hasTarget = true;
                RaycastHit hit3D;
                if (Physics.Raycast(ray, out hit3D))
                    agent.SetDestination(hit3D.point);
            }
        }
        else
        {
            if (IsSatisfied())
            {
                switch (mouseClick)
                {
                    case 0:
                        var lines = thing.GetInsightOption().insightOption;
                        if (lines != null)
                        {
                            foreach (string line in lines)
                                Debug.Log(line);
                        }
                        break;
                    case 1:
                        thing.Action();
                        break;
                }
                hasTarget = false;
                thing = null;
            }
        }
    }

    public bool HitDiegeticObject()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
        if (hit2D.collider != null)
        {
            thing = hit2D.collider.gameObject.GetComponent<Thing>();
            return thing != null;
        }

        return false;
    }

    public bool IsSatisfied()
    {
        float dist = agent.remainingDistance;
        //float distManual = Vector3.Distance(agent.destination, agent.gameObject.transform.position);
        return (dist < .1f /*&& distManual < .001f*/ && !agent.pathPending && agent.pathStatus != NavMeshPathStatus.PathPartial && agent.pathStatus != NavMeshPathStatus.PathInvalid);
    }
}

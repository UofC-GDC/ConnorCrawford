using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestingInteraction : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(ray.origin, ray.direction * 500f, Color.red, 5f);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
            RaycastHit hit3D;

            if (Physics.Raycast(ray, out hit3D))
            {
                agent.SetDestination(hit3D.point);
            }

            if (hit2D.collider != null)
            {
                Thing thing = hit2D.collider.gameObject.GetComponent<Thing>();
                if (thing != null)
                {
                    thing.Action();
                }
            }
        }
    }
}

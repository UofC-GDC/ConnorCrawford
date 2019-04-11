using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chairTeleport : MonoBehaviour 
{
    [SerializeField] private Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Chair")) return;

        var body = other.GetComponent<Rigidbody>();
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;

        other.transform.SetPositionAndRotation(spawnPoint.position, Quaternion.Euler(0, 0, 0));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight3D : MonoBehaviour {
	public bool translate;
	private Camera cam;
	// Use this for initialization
	void Start () {
		cam = GetComponentInParent<Camera>();
	}

	// Update is called once per frame
	void Update () {
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		transform.position = ray.origin;
		transform.LookAt(ray.origin + ray.direction);
	}
}

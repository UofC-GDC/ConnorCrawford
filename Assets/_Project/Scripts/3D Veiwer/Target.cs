using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	public float rotateScale = 15;
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3(
			rotateScale * (Input.mousePosition.y / Screen.height) - (rotateScale / 2),
			-(rotateScale * (Input.mousePosition.x / Screen.width) - (rotateScale / 2)),
			0);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeInteract : Interatable3D {

	public Vector3 rotateAxis = Vector3.right;
	public float rotateSpeed = 400;
	private float mouseY;

	protected override void interact(StateManager.Env env, ref Player player){
		float delta = mouseY - Input.mousePosition.y;
		float modifier = rotateSpeed / Screen.height; //Not a typo, screen HEIGHT
		transform.RotateAround(transform.position, transform.TransformDirection(rotateAxis), delta * modifier);
		mouseY = Input.mousePosition.y;
	}
	
	protected override void interactStart() {
		mouseY = Input.mousePosition.y;
	}
}

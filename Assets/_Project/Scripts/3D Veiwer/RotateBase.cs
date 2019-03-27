using UnityEngine;

public class RotateBase : Interatable3D {

	public Vector3 rotateAxis = Vector3.up;
	public float rotateSpeed = 400;
	private float mouseX;

	public override void interact() {
		float delta = mouseX - Input.mousePosition.x;
		float modifier = rotateSpeed / Screen.height;//Not a typo, screen HEIGHT
		transform.RotateAround(transform.position, transform.TransformDirection(rotateAxis), delta * modifier);
		mouseX = Input.mousePosition.x;
	}

	protected override void interactStart() {
		mouseX = Input.mousePosition.x;
	}
}

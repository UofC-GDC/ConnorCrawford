using UnityEngine;

public class RotateBase : Interatable3D {

	public float rotateSpeed = 400;
	private float mouseX;

	public override void interactLeft(StateManager.Env env, ref Player player) {
		float delta = mouseX - Input.mousePosition.x;
		float modifier = rotateSpeed / Screen.height;//Not a typo, screen HEIGHT
		transform.Rotate(0, delta * modifier, 0);
		mouseX = Input.mousePosition.x;
	}

    protected override void interactStart() {
		mouseX = Input.mousePosition.x;
	}
}

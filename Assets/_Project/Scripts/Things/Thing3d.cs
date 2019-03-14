using UnityEngine;

public class Thing3d : Thing {
	private bool active;
	public GameObject Model;
	private GameObject viewer;
	private Camera camera3d;
	private Transform target;
	private GameObject instance;

	private float rotateScale = 30;
	protected void Start() {
		active = false;
		viewer = GameObject.Find("/3D Viewer");
		camera3d = GameObject.Find("/3D Viewer/Camera").GetComponent<Camera>();
		target = GameObject.Find("/3D Viewer/Target").transform;
	}
	public override State Action(StateManager.Env env, ref Player player) {

		if(!active){
			camera3d.enabled = true;
			instance = Instantiate(Model,target);
		}

		instance.transform.eulerAngles = calcMouseAngle();

		if(!active){
			active = true;
		}
		return new DoInteractionState();
	}

	private Vector3 calcMouseAngle() {
		return new Vector3(
			rotateScale * (Input.mousePosition.y / Screen.height) - (rotateScale / 2),
			-(rotateScale * (Input.mousePosition.x / Screen.width) - (rotateScale / 2)),
			0);
	}
}

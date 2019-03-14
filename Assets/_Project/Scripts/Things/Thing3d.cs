using UnityEngine;

public class Thing3d : Thing {
	private bool active;
	public GameObject Model;
	private GameObject viewer;
	private Camera camera3d;

	private float rotateScale = 30;
	protected void Start() {
		active = false;
		viewer = GameObject.Find("/3D Viewer");
		camera3d = viewer.GetComponent<Camera>();
	}
	public override State Action(StateManager.Env env, ref Player player) {

		if(!active){
			camera3d.enabled = true;
			//instance = Instantiate(Model,target);
			Model.SetActive(true);
		}
		if(active){
			if(Input.GetMouseButtonDown(0)){
				Model.SetActive(false);
				active = false;
				return null;
			}
		}

		if(!active){
			active = true;
		}
		return new DoInteractionState();
	}
}

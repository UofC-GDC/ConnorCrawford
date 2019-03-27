using UnityEngine;
public class Viewer3D : MonoBehaviour {

	private GameObject active;
	private Interatable3D mouseOver;
	private Camera cam;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>();
	}

	void Activate(GameObject gameObject) {
		active = gameObject;
		active.SetActive(true);
	}
	void Deactivate() {
		if (active != null) {
			active.SetActive(false);
			active = null;
		}
	}
	public State Display(GameObject gameObject, StateManager.Env env, ref Player player) {
		if(gameObject != active) {
			Deactivate();
			Activate(gameObject);
		}
		bool mouseDown = Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1);
		if (mouseDown) {
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			Physics.Raycast(ray, out hit);
			mouseOver = null;
			try {
				mouseOver = hit.collider.gameObject.GetComponent<Interatable3D>();
			} catch (System.NullReferenceException e) {

			}
			if (mouseOver == null) {
				Deactivate();
				return null;
			} else {
				mouseOver.interaction = true;
			}
		}
		if(mouseOver != null){
			if(mouseOver.interaction && mouseDown) {
				mouseOver.interact(env, ref player);
			} else {
				mouseOver.interaction = false;
				mouseOver = null;
			}
		}
		return new DoInteractionState();
	}
}

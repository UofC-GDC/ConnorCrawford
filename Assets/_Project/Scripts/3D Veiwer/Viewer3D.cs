using UnityEngine;
public class Viewer3D : MonoBehaviour {

	private GameObject active;
	private Interatable3D mouseOver;
	private Camera cam;
    [SerializeField] private AudioSource bbSource;

    float bbVol = 0;

    // Use this for initialization
    void Start () {
		cam = GetComponent<Camera>();
	}

	void Activate(GameObject gameObject) {
		active = gameObject;
		active.SetActive(true);
        UnityEngine.Cursor.visible = true;
        bbSource.volume = 0;
    }
	void Deactivate() {
		if (active != null) {
			active.SetActive(false);
			active = null;
		}
        UnityEngine.Cursor.visible = false;
        bbSource.volume = bbVol;
    }
	public State Display(GameObject gameObject, StateManager.Env env, ref Player player) {
		if(gameObject != active) {
            bbVol = bbSource.volume;
            Deactivate();
			Activate(gameObject);
		}
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
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
			if(mouseOver.interaction && Input.GetMouseButton(0) || Input.GetMouseButton(1)) {
				mouseOver.interact(env, ref player);
			} else {
				mouseOver.interaction = false;
				mouseOver = null;
			}
		}
		return new DoInteractionState();
	}
}

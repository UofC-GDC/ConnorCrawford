using UnityEngine;

public class Thing3d : Thing {
	public GameObject Model;
	private Viewer3D viewer;
	protected virtual void Start() {
		viewer = FindObjectOfType<Viewer3D>();
	}
	public override State Action(StateManager.Env env, ref Player player) {
        if (Model == null) return base.Action(env, ref player);
		return viewer.Display(Model, env, ref player);
	}
}

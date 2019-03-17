using UnityEngine;

//Analogous to Thing except in the 3D viewer
public abstract class Interatable3D : MonoBehaviour {

	private bool _i = false;
	public virtual bool interaction {
		get { return _i; }
		set {
			if (_i != value) {
				_i = value;
				if (value) interactStart();
				else interactEnd();
			}
		}
	}

	public virtual void interact() {
		interaction = false;
	}

	protected virtual void interactStart() {}
	protected virtual void interactEnd() { }
}

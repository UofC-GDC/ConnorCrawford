using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewer3D : MonoBehaviour {

	private GameObject active;

	// Use this for initialization
	void Start () {

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
	public State Display(GameObject gameObject) {
		if(gameObject != active) {
			Deactivate();
			Activate(gameObject);
		}
		if (Input.GetMouseButtonDown(0)) {
			Deactivate();
			return null;
		}
		return new DoInteractionState();
	}
}

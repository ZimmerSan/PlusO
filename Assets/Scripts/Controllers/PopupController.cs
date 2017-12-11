using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour {

	public static PopupController current;

	private bool isPopupOpen = false;

	void Awake() {
		current = this;
	}

	public void openPopup(GameObject popup) {
		Debug.Log ("Is? = " + isPopupOpen);
		if (!isPopupOpen) {
			GameObject parent = UICamera.first.transform.parent.gameObject;
			GameObject obj = NGUITools.AddChild(parent, popup);

			isPopupOpen = true;
		}
	}

	public void closePopup(GameObject go) {
		Destroy (go);
		isPopupOpen = false;
	}

}

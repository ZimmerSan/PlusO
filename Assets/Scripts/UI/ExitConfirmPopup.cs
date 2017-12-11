using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitConfirmPopup : MonoBehaviour {

	public void onOkClick() {
		MusicController.current.playClick ();
		SceneManager.LoadScene ("Start");
	}
		
	public void onCloseClick() {
		MusicController.current.playClick ();
		PopupController.current.closePopup (this.gameObject);
	}
}

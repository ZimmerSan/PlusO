using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyBtn : MonoBehaviour {

	public GameObject settingsPrefab;
	public GameObject exitConfirmPrefab;

	public void onExitClick() {
		MusicController.current.playClick ();
		PopupController.current.openPopup (exitConfirmPrefab);
	}

	public void onPlayClick() {
		MusicController.current.playClick ();
		SceneManager.LoadScene("Round");
	}

	public void showSettings() {
		MusicController.current.playClick ();
		PopupController.current.openPopup (settingsPrefab);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyBtn : MonoBehaviour {

	public GameObject settingsPrefab;

	public void onExitClick() {
		MusicController.current.playClick ();
		SceneManager.LoadScene ("Start");
	}

	public void onPlayClick() {
		MusicController.current.playClick ();
		SceneManager.LoadScene("Round");
	}

	public void showSettings() {
		MusicController.current.playClick ();
		GameObject parent = UICamera.first.transform.parent.gameObject;
		GameObject obj = NGUITools.AddChild(parent, settingsPrefab);	
	}
}

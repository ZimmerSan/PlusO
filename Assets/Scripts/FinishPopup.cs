using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPopup : MonoBehaviour {

	public UI2DSprite hero, sign;

	public Sprite oSprite, plusSprite;

	// Use this for initialization
	void Start () {
		Sign.TYPE turn = LevelController.current.getTurn ();
		if (turn == Sign.TYPE.O) {
			hero.sprite2D = LevelController.current.heroO.GetComponentInChildren<UI2DSprite>().sprite2D;
			sign.sprite2D = oSprite;
		} else {
			hero.sprite2D = LevelController.current.heroPlus.GetComponentInChildren<UI2DSprite>().sprite2D;
			sign.sprite2D = plusSprite;
		}
	}

	public void onReplayClick() {
		Destroy(this.gameObject);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void onCloseClick() {

	}
}

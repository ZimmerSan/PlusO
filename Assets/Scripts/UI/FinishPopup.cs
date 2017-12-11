using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPopup : MonoBehaviour {

	public UI2DSprite hero, sign;

	public Sprite oSprite, plusSprite;
	public Sprite oHeroSprite, plusHeroSprite;

	// Use this for initialization
	void Start () {
		Sign.TYPE turn = LevelController.current.finishSign;
		if (turn == Sign.TYPE.O) {
			hero.sprite2D = oHeroSprite;
			sign.sprite2D = oSprite;
		} else {
			hero.sprite2D = plusHeroSprite;
			sign.sprite2D = plusSprite;
		}
	}

	public void onReplayClick() {
		MusicController.current.playClick ();
		PopupController.current.closePopup (this.gameObject);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void onCloseClick() {
		MusicController.current.playClick ();
		PopupController.current.closePopup (this.gameObject);
		SceneManager.LoadScene ("Start");
	}
}

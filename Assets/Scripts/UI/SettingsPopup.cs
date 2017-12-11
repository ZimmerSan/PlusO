using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsPopup : MonoBehaviour {

	public Sprite soundOnSprite, soundOffSprite, musicOnSprite, musicOffSprite;
	public GameObject soundButton, musicButton;

	bool soundEnabled, musicEnabled;

	// Use this for initialization
	void Start () {
		soundEnabled = PlayerPrefs.GetInt("sound", 1) == 1;
		MusicController.current.toggleSound(soundEnabled);
		musicEnabled = PlayerPrefs.GetInt("music", 1) == 1;

		UI2DSprite spriteSound = soundButton.GetComponent<UI2DSprite>();
		spriteSound.sprite2D = soundEnabled ? soundOnSprite : soundOffSprite;
		UI2DSprite spriteMusic = musicButton.GetComponent<UI2DSprite>();
		spriteMusic.sprite2D = musicEnabled ? musicOnSprite : musicOffSprite;
	}

	// Update is called once per frame
	void Update () {
		UI2DSprite spriteSound = soundButton.GetComponent<UI2DSprite>();
		spriteSound.sprite2D = soundEnabled ? soundOnSprite : soundOffSprite;
		UI2DSprite spriteMusic = musicButton.GetComponent<UI2DSprite>();
		spriteMusic.sprite2D = musicEnabled ? musicOnSprite : musicOffSprite;
	}
		
	public void onSoundClick() {
		MusicController.current.playClick ();
		soundEnabled = !soundEnabled;
		MusicController.current.toggleSound(soundEnabled);
		UI2DSprite sprite = soundButton.GetComponent<UI2DSprite>();
		sprite.sprite2D = soundEnabled? soundOnSprite : soundOffSprite;
	}

	public void onMusicClick() {
		MusicController.current.playClick ();
		musicEnabled = !musicEnabled;
		MusicController.current.toggleMusic(musicEnabled);
		UI2DSprite sprite = musicButton.GetComponent<UI2DSprite>();
		sprite.sprite2D = musicEnabled ? musicOnSprite : musicOffSprite;
	}

	public void onCloseClick() {
		MusicController.current.playClick ();
		PopupController.current.closePopup (this.gameObject);
	}
}

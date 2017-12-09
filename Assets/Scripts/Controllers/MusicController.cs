using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

	public static MusicController current;

	public AudioClip music = null;
	AudioSource musicSource = null;

	public AudioClip soundO = null;
	AudioSource soundOSource = null;

	public AudioClip soundPlus = null;
	AudioSource soundPlusSource = null;

	public AudioClip soundVictory = null;
	AudioSource soundVictorySource = null;

	public AudioClip soundClick = null;
	AudioSource soundClickSource = null;

	bool isSoundOn = true;

	void Awake() {
		current = this;
	}

	void Start() {
		musicSource = gameObject.AddComponent<AudioSource> ();
		musicSource.clip = music;
		musicSource.loop = true;

		soundOSource = gameObject.AddComponent<AudioSource> ();
		soundOSource.clip = soundO;

		soundPlusSource = gameObject.AddComponent<AudioSource> ();
		soundPlusSource.clip = soundPlus;

		soundVictorySource = gameObject.AddComponent<AudioSource> ();
		soundVictorySource.clip = soundVictory;

		soundClickSource = gameObject.AddComponent<AudioSource> ();
		soundClickSource.clip = soundClick;

		if (PlayerPrefs.GetInt ("music", 1) == 1) {
			musicSource.Play ();
		}

		isSoundOn = (PlayerPrefs.GetInt ("sound", 1) == 1);
	}

	public void toggleMusic(bool enable) {
		PlayerPrefs.SetInt("music", enable ? 1 : 0);
		PlayerPrefs.Save();

		if (enable) musicSource.Play();
		else 		musicSource.Stop();
	}

	public void toggleSound(bool enable) {
		PlayerPrefs.SetInt("sound", enable ? 1 : 0);
		isSoundOn = enable;
		PlayerPrefs.Save();
	}

	public void playSignSound (Sign.TYPE sign) {
		if (isSoundOn) {
			if (sign == Sign.TYPE.O)
				soundOSource.Play ();
			else if (sign == Sign.TYPE.PLUS)
				soundPlusSource.Play ();
		} 
	}

	public void playVictorySound() {
		if (isSoundOn) {
			soundVictorySource.Play ();
		}
	}

	public void playClick() {
		if (isSoundOn) {
			soundClickSource.Play ();
		}	
	}
}

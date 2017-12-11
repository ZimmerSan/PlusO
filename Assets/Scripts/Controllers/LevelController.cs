using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public static LevelController current;
	public Sign.TYPE turn, finishSign;
	public GameObject heroPlus, heroO;
	public FieldBig fieldBig;

	public GameObject finishPrefab;

	private bool finished = false;

	void Awake() {
		current = this;
	}

	// Use this for initialization
	void Start () {
		Debug.Log("Started");
		this.turn = Sign.TYPE.PLUS;
		disable (heroO);
	}

	void disable (GameObject go) {
		setOpacity (go, 0.5f);
	}

	void enable (GameObject go) {
		setOpacity (go, 1f);
	}

	public void setOpacity(GameObject go, float opacity) {
		SpriteRenderer[] renderers = go.GetComponentsInChildren<SpriteRenderer> ();
		foreach (SpriteRenderer r in renderers) {
			r.color = new Vector4 (r.color.r, r.color.g, r.color.b, opacity);
		}	
	}

	public Sign.TYPE getTurn() {
		return this.turn;
	}

	public void move() {
		if (this.turn == Sign.TYPE.O) {
			this.turn = Sign.TYPE.PLUS;
			disable (heroO);
			enable (heroPlus);
		} else if (this.turn == Sign.TYPE.PLUS) {
			this.turn = Sign.TYPE.O;
			disable (heroPlus);
			enable (heroO);
		}	
	}

	public void finish(Sign.TYPE sign) {
		Debug.Log ("Finish sign = " + sign);
		finished = true;
		finishSign = sign;

		MusicController.current.playVictorySound ();
		PopupController.current.openPopup (finishPrefab);
	}

	public bool isFinished() {
		return finished;
	}

}

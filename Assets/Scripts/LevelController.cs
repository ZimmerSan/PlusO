using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public static LevelController current;
	private Sign.TYPE turn;
	public UIWidget heroPlus, heroO;
	public FieldBig fieldBig;

	public GameObject finishPrefab;

	private bool finished = false;

	Dictionary<Sign.TYPE, int> score;

	void Awake() {
		current = this;
	}

	// Use this for initialization
	void Start () {
		Debug.Log("Started");
		this.turn = Sign.TYPE.PLUS;
		disable (heroO);
		score = new Dictionary<Sign.TYPE, int> ();
		score.Add (Sign.TYPE.O, 0);
		score.Add (Sign.TYPE.PLUS, 0);
	}

	void disable (UIWidget widget) {
		widget.alpha = 0.5f;
	}

	void enable (UIWidget widget) {
		widget.alpha = 1f;
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

	public void finish() {
		finished = true;
		GameObject parent = UICamera.first.transform.parent.gameObject;
		GameObject obj = NGUITools.AddChild(parent, finishPrefab);
	}

	public bool isFinished() {
		return finished;
	}

}

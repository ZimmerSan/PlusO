using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

	public int index;
	public FieldSmall parent;
	private Sign.TYPE mySign;

	public Sprite oSprite, plusSprite;

	public void fill(Sign.TYPE signType) {
		GameObject sign = null;
		if (signType == Sign.TYPE.O) sign = GameObject.Instantiate(ObjectFactory.getInstance ().signOPrefab);
		else if (signType == Sign.TYPE.PLUS) sign = GameObject.Instantiate(ObjectFactory.getInstance ().signPlusPrefab);

		Vector3 pos = this.transform.position;
		pos.z -= 1;

		sign.transform.GetComponent<Sign> ().Initialize (signType);
		sign.transform.localPosition = pos;
	
		MusicController.current.playSignSound (signType);
		this.mySign = signType;
	}

	public Sign.TYPE getSign() {
		return this.mySign;
	}

	public bool isFilled() {
		return this.mySign != Sign.TYPE.NONE;
	}

	void Start() {
		this.mySign = Sign.TYPE.NONE;
	}

	public void _onClick() {
		if (!LevelController.current.isFinished () && !this.isFilled () && parent.isActive ()) {
			fill (LevelController.current.getTurn ());

			Sign.TYPE res = parent.isFinished ();
			if (res != Sign.TYPE.NONE) {
				LevelController.current.finish (res);
				return;
			}
			
			LevelController.current.move ();
			LevelController.current.fieldBig.activateField (this.index);
		}
	}

	public void Initialize(int index, FieldSmall parent) {
		this.index = index;
		this.parent = parent;
	}

	public int getIndex() {
		return index;
	}
		
}

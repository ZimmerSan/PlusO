using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour {

	public Sprite oSprite, plusSprite;
	private TYPE type;

	public enum TYPE {O, PLUS, NONE}

	public void Initialize(TYPE type) {
		this.type = type;

		UI2DSprite mySprite = this.transform.GetComponent<UI2DSprite> ();
		switch (type) {
		case TYPE.O:
			mySprite.sprite2D = oSprite;
			break;
		case TYPE.PLUS:
			mySprite.sprite2D = plusSprite;
			break;
		}
	}

	public TYPE getType() {
		return this.type;
	}
		
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSmall : MonoBehaviour {

	public const int BORDER_SIZE = 6;
	public const float DISABLED_OPACITY = 0.4f; 

	Dictionary<int, Cell> cells;

	private int index;
	private bool active;

	// Use this for initialization
	void Start () {
		cells = new Dictionary<int, Cell> ();
		for (int i = 1; i <= 9; i++) {
			cells.Add (i, createCell (i)); 
		}
	}

	private Cell createCell(int index) {
		int[] props = Helper.getProps (index);
		int multX = props[0], multY = props[1];

		var cell = this.gameObject.AddChild (ObjectFactory.getInstance ().cellPrefab);
		UI2DSprite sprite = cell.transform.GetComponent<UI2DSprite> ();
		Vector3 pos = this.transform.position;
		pos.x += (sprite.width + BORDER_SIZE)*multX;
		pos.y += (sprite.height + BORDER_SIZE)*multY;
		cell.transform.localPosition = pos;

		Cell c = cell.transform.GetComponent<Cell> ();
		c.Initialize (index, this);
		return c;
	}
	
	public void Initialize(int index) {
		this.index = index;
		Debug.Log ("index = " + index);
		if (index == 5)
			setActive (true);
		else
			setActive (false);
	}

	public void setActive(bool flag) {
		if (flag) {
			this.active = true;
			this.GetComponent<UIWidget> ().alpha = 1f;
		} else {
			this.active = false;
			this.GetComponent<UIWidget> ().alpha = DISABLED_OPACITY;
		}
	}

	public bool isActive() {
		return active;
	}

	public int getIndex() {
		return index;
	}

	public Sign.TYPE isFinished() {
		Debug.Log ("1 - " + cells [1].getSign ());
		Debug.Log ("2 - " + cells [2].getSign ());
		Debug.Log ("3 - " + cells [3].getSign ());
		Debug.Log ("4 - " + cells [4].getSign ());
		Debug.Log ("5 - " + cells [5].getSign ());
		Debug.Log ("6 - " + cells [6].getSign ());
		Debug.Log ("7 - " + cells [7].getSign ());
		Debug.Log ("8 - " + cells [8].getSign ());
		Debug.Log ("9 - " + cells [9].getSign ());

		if (cells [1].getSign () == cells [2].getSign () && cells [1].getSign () == cells [3].getSign ())
			return cells [1].getSign ();
		if (cells [4].getSign () == cells [5].getSign () && cells [4].getSign () == cells [6].getSign ())
			return cells [4].getSign ();
		if (cells [7].getSign () == cells [8].getSign () && cells [7].getSign () == cells [9].getSign ())
			return cells [7].getSign ();

		if (cells [1].getSign () == cells [4].getSign () && cells [1].getSign () == cells [7].getSign ())
			return cells [1].getSign ();
		if (cells [2].getSign () == cells [5].getSign () && cells [2].getSign () == cells [8].getSign ())
			return cells [2].getSign ();
		if (cells [3].getSign () == cells [6].getSign () && cells [3].getSign () == cells [9].getSign ())
			return cells [3].getSign ();

		if (cells [1].getSign () == cells [5].getSign () && cells [1].getSign () == cells [9].getSign ())
			return cells [1].getSign ();
		if (cells [3].getSign () == cells [5].getSign () && cells [3].getSign () == cells [7].getSign ())
			return cells [3].getSign ();

		return Sign.TYPE.NONE;
	}
}

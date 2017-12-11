using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSmall : MonoBehaviour {

	public const float DISABLED_OPACITY = 0.4f; 

	Dictionary<int, Cell> cells;

	public int index;
	public bool active;

	// Use this for initialization
	void Start () {
		cells = new Dictionary<int, Cell> ();

		Cell[] childrenCells = this.GetComponentsInChildren<Cell> ();
		foreach (Cell c in childrenCells) {
			cells.Add (c.getIndex (), c);
		}

		setActive (active);
	}

	public void setActive(bool flag) {
		if (flag) {
			this.active = true;
			LevelController.current.setOpacity (this.gameObject, 1f);
		} else {
			this.active = false;
			LevelController.current.setOpacity (this.gameObject, DISABLED_OPACITY);
		}
	}

	public Sign.TYPE isFinished() {
		if (cells [1].getSign () != Sign.TYPE.NONE && cells [1].getSign () == cells [2].getSign () && cells [1].getSign () == cells [3].getSign ())
			return cells [1].getSign ();
		if (cells [4].getSign () != Sign.TYPE.NONE && cells [4].getSign () == cells [5].getSign () && cells [4].getSign () == cells [6].getSign ())
			return cells [4].getSign ();
		if (cells [7].getSign () != Sign.TYPE.NONE && cells [7].getSign () == cells [8].getSign () && cells [7].getSign () == cells [9].getSign ())
			return cells [7].getSign ();

		if (cells [1].getSign () != Sign.TYPE.NONE && cells [1].getSign () == cells [4].getSign () && cells [1].getSign () == cells [7].getSign ())
			return cells [1].getSign ();
		if (cells [2].getSign () != Sign.TYPE.NONE && cells [2].getSign () == cells [5].getSign () && cells [2].getSign () == cells [8].getSign ())
			return cells [2].getSign ();
		if (cells [3].getSign () != Sign.TYPE.NONE && cells [3].getSign () == cells [6].getSign () && cells [3].getSign () == cells [9].getSign ())
			return cells [3].getSign ();

		if (cells [1].getSign () != Sign.TYPE.NONE && cells [1].getSign () == cells [5].getSign () && cells [1].getSign () == cells [9].getSign ())
			return cells [1].getSign ();
		if (cells [3].getSign () != Sign.TYPE.NONE && cells [3].getSign () == cells [5].getSign () && cells [3].getSign () == cells [7].getSign ())
			return cells [3].getSign ();

		return Sign.TYPE.NONE;
	}

	public bool isActive() { return active; }

	public int getIndex() { return index; }
}

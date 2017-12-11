using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBig : MonoBehaviour {

	Dictionary<int, FieldSmall> fields;

	// Use this for initialization
	void Start () {
		fields = new Dictionary<int, FieldSmall> ();

		FieldSmall[] childrenFields = this.GetComponentsInChildren<FieldSmall> ();
		foreach (FieldSmall f in childrenFields) {
			fields.Add (f.getIndex (), f);
		}
	}
	
	public void activateField(int index) {
		FieldSmall field = null;

		for (int i = 1; i <= 9; i++) {
			if (fields.TryGetValue(i, out field)) { field.setActive (false); } 
		}

		if (fields.TryGetValue(index, out field)) { field.setActive (true); } 
	}
}

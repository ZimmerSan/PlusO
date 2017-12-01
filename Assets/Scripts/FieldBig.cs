using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBig : MonoBehaviour {

	public const int BORDER_SIZE = 25;

	Dictionary<int, FieldSmall> fields;

	// Use this for initialization
	void Start () {
		fields = new Dictionary<int, FieldSmall> ();
		for (int i = 1; i <= 9; i++) {
			fields.Add (i, createField (i)); 
		}	
	}

	private FieldSmall createField(int index) {
		int[] props = Helper.getProps (index);
		int multX = props[0], multY = props[1];

		var field = this.gameObject.AddChild (ObjectFactory.getInstance ().fieldPrefab);
		UI2DSprite sprite = field.transform.GetComponent<UI2DSprite> ();

		Vector3 pos = this.transform.position;
		pos.x += (sprite.width + BORDER_SIZE)*multX;
		pos.y += (sprite.height + BORDER_SIZE)*multY - 35;
		field.transform.localPosition = pos;

		FieldSmall fs = field.transform.GetComponent<FieldSmall> ();
		fs.Initialize (index);
		return fs;
	}
	
	public void activateField(int index) {
		FieldSmall field = null;

		for (int i = 1; i <= 9; i++) {
			if (fields.TryGetValue(i, out field)) { field.setActive (false); } 
		}

		if (fields.TryGetValue(index, out field)) { field.setActive (true); } 
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour {

	public TYPE type;

	public enum TYPE {O, PLUS, NONE}

	public void Initialize(TYPE type) {
		this.type = type;
	}

	public TYPE getType() {
		return this.type;
	}
		
}

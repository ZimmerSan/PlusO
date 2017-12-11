using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFactory : MonoBehaviour {
	private static ObjectFactory instance; // Needed

	public GameObject signPlusPrefab, signOPrefab;
	public GameObject cellPrefab;
	public GameObject fieldPrefab;

	void Awake() {
		instance = this;
	}

	public static ObjectFactory getInstance() {
		return instance;
	}

}

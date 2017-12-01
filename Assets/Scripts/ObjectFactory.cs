using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFactory : MonoBehaviour {
	private static ObjectFactory instance; // Needed

	public GameObject signPrefab;
	public GameObject cellPrefab;
	public GameObject fieldPrefab;

	void Awake() {
		instance = this;
	}

	public static ObjectFactory getInstance() {
		return instance;
	}

}

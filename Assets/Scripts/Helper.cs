using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour {

	public static int[] getProps(int index) {
		switch (index) {
		case 1:
			return new int[2]{-1, 1};
		case 2:
			return new int[2]{0, 1};
		case 3:
			return new int[2]{1, 1};
		case 4:
			return new int[2]{-1, 0};
		case 5:
			return new int[2]{0, 0};
		case 6:
			return new int[2]{1, 0};
		case 7:
			return new int[2]{-1, -1};
		case 8:
			return new int[2]{0, -1};
		case 9:
			return new int[2]{1, -1};
		default:
			return new int[2]{ 0, 0 };	
		}
	}
}

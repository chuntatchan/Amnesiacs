using UnityEngine;
using System.Collections;

public class SetPlayerTurn : MonoBehaviour {

	public int newPlayerNum;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("currentTurn", newPlayerNum);
	}

}

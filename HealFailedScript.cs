using UnityEngine;
using System.Collections;

public class HealFailedScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("HealFailed", 1);
	}

}

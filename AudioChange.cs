using UnityEngine;
using System.Collections;

public class AudioChange : MonoBehaviour {

	public int newSound;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("ChangeBGM", 1);
		PlayerPrefs.SetInt ("newBGM", newSound);
	}

}

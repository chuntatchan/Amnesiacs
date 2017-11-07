using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("nextScene", 1.5f);
	}

	void nextScene () {
		SceneManager.LoadScene ("CreditsP.2");
	}

	void Update() {
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				SceneManager.LoadScene ("DebuggerSelection");
			}
		}
	}
}

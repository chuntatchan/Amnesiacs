using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ToBeContinuedBlurbScript : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				SceneManager.LoadScene ("DebuggerSelection");
			}
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.LoadScene ("Credits");
		}
	}
}

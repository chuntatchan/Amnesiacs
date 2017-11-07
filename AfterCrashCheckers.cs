using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AfterCrashCheckers : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				SceneManager.LoadScene ("DebuggerSelection");
			}
		}
		if (Project82Main.arrStoryInt == 1) {
			if (PlayerPrefs.GetInt ("Debugging") == 1) {
				SceneManager.LoadScene ("DebuggerSelection");
			} else {
				SceneManager.LoadScene ("ToBeContinuedBlurb");
			}
		}
	}
}

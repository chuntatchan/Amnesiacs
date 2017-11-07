using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LibraryRound1MinigameChecker : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				SceneManager.LoadScene ("DebuggerSelection");
			}
		}
		if (PlayerPrefs.GetInt ("PasswordAttempt") == 1) { 
			if (Project82Main.arrStoryInt == 12 && Project82Main.currentStoryIndex == 1) {
				SceneManager.LoadScene ("PasswordPuzzle");
			}

		} else if (Project82Main.arrStoryInt == 12 && Project82Main.currentStoryIndex == 1) {
			SceneManager.LoadScene ("PasswordPuzzle");
			PlayerPrefs.SetInt ("PasswordAttempt", 1);
		} else if (Project82Main.arrStoryInt == 1 || Project82Main.arrStoryInt == 19) {
			PlayerPrefs.SetInt ("book", 1);
		}
	}
}

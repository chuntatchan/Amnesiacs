using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour {

	void Start() {
		PlayerPrefs.DeleteAll ();
	}

	void Update() {
		if (Project82Main.arrStoryInt == 1) {
			SceneManager.LoadScene ("WarningBlurb");
		} else if (Project82Main.arrStoryInt == 2) {
			Application.Quit ();
		} else if (Project82Main.arrStoryInt == 3) {
			SceneManager.LoadScene ("DebuggerLogin");
		} else if (Project82Main.arrStoryInt == 4) {
			SceneManager.LoadScene ("Act2TitleScreen");
		}
	}
}

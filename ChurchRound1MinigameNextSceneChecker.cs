using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChurchRound1MinigameNextSceneChecker : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			if (Input.GetKeyDown(KeyCode.Escape)) {
				SceneManager.LoadScene ("DebuggerSelection");
			}
		}
		if (Project82Main.arrStoryInt == 19  && Project82Main.currentStoryIndex == 4) {
			SceneManager.LoadScene ("ChurchDoor");
		}

	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PharmacyRound1NextSceneChecker : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				SceneManager.LoadScene ("DebuggerSelection");
			}
		}
		if (Project82Main.arrStoryInt == 10) {
			if (PlayerPrefs.GetInt ("Debugging") == 1) {
				SceneManager.LoadScene ("DebuggerSelection");
			} else {
				PlayerPrefs.SetInt ("currentTurn", PlayerPrefs.GetInt ("currentTurn") + 1);
				SceneManager.LoadScene ("NextPlayerScreen");
			}
		} else if (Project82Main.arrStoryInt == 7) {
			if (PlayerPrefs.GetInt ("brokenCabinet") == 1) {
				print ("cabinet is already broken");
			} else {
				SceneManager.LoadScene ("Cabinet");
			}
		} else if (Project82Main.arrStoryInt == 9 && Project82Main.currentStoryIndex == 2) {
			PlayerPrefs.SetInt ("pills", 1);
		}
	}
}

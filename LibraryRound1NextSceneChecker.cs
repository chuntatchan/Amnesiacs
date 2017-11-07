using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LibraryRound1NextSceneChecker : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				SceneManager.LoadScene ("DebuggerSelection");
			}
		} 
		if (Project82Main.arrStoryInt == 14) {
			if (PlayerPrefs.GetInt ("Debugging") == 1) {
				SceneManager.LoadScene ("DebuggerSelection");
			} else {
				PlayerPrefs.SetInt ("currentTurn", PlayerPrefs.GetInt ("currentTurn") + 1);
				SceneManager.LoadScene ("NextPlayerScreen");
			}
		}
	}
}

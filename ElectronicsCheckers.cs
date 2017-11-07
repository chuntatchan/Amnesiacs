using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ElectronicsCheckers : MonoBehaviour {

	public static bool timeDelay = false;

	void Start () {
		if (PlayerPrefs.GetInt("E") == 1) {
			Project82Main.currentStoryIndex = 3;
			Project82Main.promptTimer = 3;
		}
		PlayerPrefs.SetInt ("E", 1);
		timeDelay = true;
	}

	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				SceneManager.LoadScene ("DebuggerSelection");
			}
		} 
		if (Project82Main.arrStoryInt == 18) {
			if (PlayerPrefs.GetInt ("Debugging") == 1) {
				SceneManager.LoadScene ("DebuggerSelection");
			} else {
				PlayerPrefs.SetInt ("currentTurn", PlayerPrefs.GetInt ("currentTurn") + 1);
				SceneManager.LoadScene ("Act1Part3Loading");
			}
		} else if (Project82Main.arrStoryInt == 19) {
			if (PlayerPrefs.GetInt ("Debugging") == 1) {
				SceneManager.LoadScene ("DebuggerSelection");
			} else {
				Debug.Log ("NewMap" + PlayerPrefs.GetString ("ElectronicsTeam").ToString ());
				SceneManager.LoadScene ("NewMap" + PlayerPrefs.GetString ("ElectronicsTeam").ToString ());
			}
		} else if (Project82Main.arrStoryInt == 15) {
			SceneManager.LoadScene ("PassCodeMinigame");
		} else if (Project82Main.arrStoryInt == 12) {
			PlayerPrefs.SetInt ("secondKey", 1);
		} else if (Project82Main.arrStoryInt == 17) {
			PlayerPrefs.SetInt ("ElectronicsDone", 1);
		} else if (Project82Main.arrStoryInt == 7) {
			PlayerPrefs.SetInt ("bottomDrawerChecked", 1);
		} else if (Project82Main.arrStoryInt == 3) {
			PlayerPrefs.SetInt ("redScreen", 1);
		}
	
	}
}

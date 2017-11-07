using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DinerRound1NextPlayerCheck : MonoBehaviour {

	public static bool timeDelay = false;

	void Start () {
		if (PlayerPrefs.GetInt("D") == 1) {
			Project82Main.currentStoryIndex = 5;
			Project82Main.promptTimer = 5;
		}
		PlayerPrefs.SetInt ("D", 1);
		timeDelay = true;

	}

	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			if (Input.GetKeyDown (KeyCode.Escape)) { 
				SceneManager.LoadScene ("DebuggerSelection");
			}
		}
		if (Project82Main.arrStoryInt == 21) {
			if (PlayerPrefs.GetInt ("Debugging") == 1) {
				SceneManager.LoadScene ("DebuggerSelection");
			} else {
				PlayerPrefs.SetInt ("currentTurn", PlayerPrefs.GetInt ("currentTurn") + 1);
				SceneManager.LoadScene ("Act1Part3Loading");
			}
		} else if (Project82Main.arrStoryInt == 24) {
			if (PlayerPrefs.GetInt ("Debugging") == 1) {
				SceneManager.LoadScene ("DebuggerSelection");
			} else {
				Debug.Log ("NewMap" + PlayerPrefs.GetString ("DinerTeam").ToString ());
				SceneManager.LoadScene ("NewMap" + PlayerPrefs.GetString ("DinerTeam").ToString ());
			}
		} else if (Project82Main.arrStoryInt == 9) {
			PlayerPrefs.SetInt ("DinerDone", 1);
		} else if (Project82Main.arrStoryInt == 20) {
			PlayerPrefs.SetInt ("hasBag", 1);
		} else if (Project82Main.arrStoryInt == 7 || Project82Main.arrStoryInt == 8 || Project82Main.arrStoryInt == 4) {
			PlayerPrefs.SetInt ("ateFood", 1);
		} else if (Project82Main.arrStoryInt == 22) {
			PlayerPrefs.SetInt ("accessCard", 1);
			PlayerPrefs.SetInt ("glint", 1);
		} else if (Project82Main.arrStoryInt == 16 || Project82Main.arrStoryInt == 18) {
			PlayerPrefs.SetInt ("fries", 1);
		}
	}
}

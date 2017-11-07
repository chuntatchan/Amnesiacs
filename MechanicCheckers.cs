using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MechanicCheckers : MonoBehaviour {

	public static bool timeDelay = false;

	void Start () {
		if (PlayerPrefs.GetInt("M") == 1) {
			Project82Main.currentStoryIndex = 2;
			Project82Main.promptTimer = 2;
		}
		PlayerPrefs.SetInt ("M", 1);
		timeDelay = true;
	}

	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				SceneManager.LoadScene ("DebuggerSelection");
			}
		}
		if (Project82Main.arrStoryInt == 7) {
			PlayerPrefs.SetInt ("fuel", 1);
		} else if (Project82Main.arrStoryInt == 16) {
			PlayerPrefs.SetInt ("tools", 1);
		} else if (Project82Main.arrStoryInt == 12) {
			PlayerPrefs.SetInt ("tires", 1);
		} else if (Project82Main.arrStoryInt == 17) {
			if (PlayerPrefs.GetInt ("Debugging") == 1) {
				SceneManager.LoadScene ("DebuggerSelection");
			} else {
				PlayerPrefs.SetInt ("currentTurn", PlayerPrefs.GetInt ("currentTurn") + 1);
				SceneManager.LoadScene ("Act1Part3Loading");
			}
		} else if (Project82Main.arrStoryInt == 18) {
			if (PlayerPrefs.GetInt ("Debugging") == 1) {
				SceneManager.LoadScene ("DebuggerSelection");
			} else {
				Debug.Log ("NewMap" + PlayerPrefs.GetString ("MechanicsTeam").ToString ());
				SceneManager.LoadScene ("NewMap" + PlayerPrefs.GetString ("MechanicsTeam").ToString ());
			}
		} else if (Project82Main.arrStoryInt == 10) {
			PlayerPrefs.SetInt ("radio", 1);
		} else if (Project82Main.arrStoryInt == 22) {
			PlayerPrefs.SetInt ("shelves", 1);
		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GiftShopCheckers : MonoBehaviour {

	public static bool timeDelay = false;

	void Start () {
		if (PlayerPrefs.GetInt("G") == 1) {
			Project82Main.currentStoryIndex = 2; 
			Project82Main.promptTimer = 2;
		}
		PlayerPrefs.SetInt ("G", 1);
		timeDelay = true;
	}

	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				SceneManager.LoadScene ("DebuggerSelection");
			}
		}
		if (Project82Main.arrStoryInt == 26) {
			if (PlayerPrefs.GetInt ("Debugging") == 1) {
				SceneManager.LoadScene ("DebuggerSelection");
			} else {
				Debug.Log ("NewMap" + PlayerPrefs.GetString ("GiftShopTeam").ToString ());
				SceneManager.LoadScene ("NewMap" + PlayerPrefs.GetString ("GiftShopTeam").ToString ());
			}
		} else if (Project82Main.arrStoryInt == 25) {
			if (PlayerPrefs.GetInt ("Debugging") == 1) {
				SceneManager.LoadScene ("DebuggerSelection");
			} else {
				PlayerPrefs.SetInt ("currentTurn", PlayerPrefs.GetInt ("currentTurn") + 1);
				SceneManager.LoadScene ("Act1Part3Loading");
			}
		} else if (Project82Main.arrStoryInt == 13) {
			PlayerPrefs.SetInt ("LittlePocketKey", 1);
		} else if (Project82Main.arrStoryInt == 16) {
			PlayerPrefs.SetInt ("Map", 1);
		} else if (Project82Main.arrStoryInt == 15) {
			PlayerPrefs.SetInt ("water", 1);
		} else if (Project82Main.arrStoryInt == 12) {
			PlayerPrefs.SetInt ("ateBar", 1);
		} else if (Project82Main.arrStoryInt == 23) {
			PlayerPrefs.SetInt ("register", 1);
		} else if (Project82Main.arrStoryInt == 11) {
			PlayerPrefs.SetInt ("foundBackpack", 1);
		}
	}
}

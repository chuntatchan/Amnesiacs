using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CarSceneNextChara : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				SceneManager.LoadScene ("DebuggerSelection");
			}
		}
		if (Project82Main.arrStoryInt == 13) {
			if (PlayerPrefs.GetInt ("Debugging") == 1) {
				SceneManager.LoadScene ("DebuggerSelection");
			} else {
				PlayerPrefs.SetInt ("currentTurn", PlayerPrefs.GetInt ("currentTurn") + 1);
				SceneManager.LoadScene ("CarNextPlayerScreen");
			}
		} else if (Project82Main.arrStoryInt == 1) {
			PlayerPrefs.SetInt ("tiresChecked", 1);
			Debug.Log ("tires");
		} else if (Project82Main.arrStoryInt == 9) {
			PlayerPrefs.SetInt ("cellChecked", 1);
			Debug.Log ("cell");
		} else if (Project82Main.arrStoryInt == 11) {
			PlayerPrefs.SetInt ("foodChecked", 1);
			Debug.Log ("food");
		}
	}
}


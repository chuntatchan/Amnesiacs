using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HelpDeerPassChecker : MonoBehaviour {

	public string nextScene;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("DeerPressure") == 1 && PlayerPrefs.GetInt ("DeerSplint") == 1 && PlayerPrefs.GetInt ("DeerWounds") == 1 && PlayerPrefs.GetInt ("DeerComfort") == 1) {
			SceneManager.LoadScene (nextScene);
		}
	}

}

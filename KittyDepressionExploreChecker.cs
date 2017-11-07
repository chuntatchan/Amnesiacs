using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KittyDepressionExploreChecker : MonoBehaviour {

	public GameObject blackscreen;
	private float alpha;
	public string nextSceneString;
	public string nextSceneStringNoCat;

	void Start() {
		alpha = 0;
	}

	void Update () {
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				SceneManager.LoadScene ("DebuggerSelection");
			}
		}
		if (Project82Main.arrStoryInt == 16) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene", 1.5f);
		}
	}

	void nextScene() {
		if (PlayerPrefs.GetInt ("AllWindowsClosed") == 1) {
			SceneManager.LoadScene (nextSceneStringNoCat);
		} else {
			SceneManager.LoadScene (nextSceneString);
		}
	}

	void fadeInBlackScreen() {
		PlayerPrefs.SetInt ("PreventReturn", 1);
		alpha += 0.02f;
		blackscreen.GetComponent<Image> ().color = new Color (0, 0, 0, alpha);
	}

}

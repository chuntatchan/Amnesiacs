using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarCrashChecker : MonoBehaviour {

	public GameObject blackscreen;
	private float alpha;

	void Start() {
		alpha = 0;
	}

	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				SceneManager.LoadScene ("DebuggerSelection");
			}
		}
		if (Project82Main.arrStoryInt == 1 && Project82Main.currentStoryIndex == 5) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene", 1.5f);
		}
	}

	void nextScene() {
		SceneManager.LoadScene ("AfterCrashBlurb");
	}

	void fadeInBlackScreen() {
		PlayerPrefs.SetInt ("PreventReturn", 1);
		alpha += 0.02f;
		blackscreen.GetComponent<Image> ().color = new Color (0, 0, 0, alpha);
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChurchBreakScript : MonoBehaviour {

	public GameObject blackscreen;
	private float alpha;
	public string nextSceneString;

	void Start() {
		alpha = 0;
	}

	void Update () {
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			if (Input.GetKeyDown(KeyCode.Escape)) {
				SceneManager.LoadScene ("DebuggerSelection");
			}
		}
		if (Project82Main.arrStoryInt == 23 && Project82Main.currentStoryIndex == 1) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene", 1.5f);
		}

	}

	void nextScene() {
		PlayerPrefs.SetInt ("currentTurn", PlayerPrefs.GetInt ("currentTurn") + 1);
		SceneManager.LoadScene (nextSceneString);
	}

	void fadeInBlackScreen() {
		PlayerPrefs.SetInt ("PreventReturn", 1);
		alpha += 0.02f;
		blackscreen.GetComponent<Image> ().color = new Color (0, 0, 0, alpha);
	}

}

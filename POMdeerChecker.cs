using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class POMdeerChecker : MonoBehaviour {

	public string nextSceneString;
	public GameObject blackscreen;
	private float alpha;

	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				SceneManager.LoadScene ("DebuggerSelection");
			}
		}
		if (Project82Main.arrStoryInt == 2 && Project82Main.currentStoryIndex == 4) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene", 1.5f);
		} else if (Project82Main.arrStoryInt == 3 && Project82Main.currentStoryIndex == 6) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene", 1.5f);
		} else if (Project82Main.arrStoryInt == 7 && Project82Main.currentStoryIndex == 4) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene", 1.5f);
		}
	}

		
	void nextScene() {
		SceneManager.LoadScene (nextSceneString);
	}

	void fadeInBlackScreen() {
		PlayerPrefs.SetInt ("PreventReturn", 1);
		alpha += 0.02f;
		blackscreen.GetComponent<Image> ().color = new Color (0, 0, 0, alpha);
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ForestSceneChecker2 : MonoBehaviour {

	public GameObject blackscreen;
	private float alpha;
	public string nextSceneString;

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
		if (Project82Main.arrStoryInt == 6 && Project82Main.currentStoryIndex == 6) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene", 1.5f);
		} else if (Project82Main.arrStoryInt == 11 && Project82Main.currentStoryIndex == 6) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene", 1.5f);
		} else if (Project82Main.arrStoryInt == 13 && Project82Main.currentStoryIndex == 6) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene", 1.5f);
		} else if (Project82Main.arrStoryInt == 14 && Project82Main.currentStoryIndex == 4) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene", 1.5f);
		} else if (Project82Main.arrStoryInt == 4 && Project82Main.currentStoryIndex == 3) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene", 1.5f);
		} else if (Project82Main.arrStoryInt == 12 && Project82Main.currentStoryIndex == 6) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene", 1.5f);
		} else if (Project82Main.arrStoryInt == 15 && Project82Main.currentStoryIndex == 8) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene", 1.5f);
		} else if (Project82Main.arrStoryInt == 24 && Project82Main.currentStoryIndex == 2) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene", 1.5f);
		} else if (Project82Main.arrStoryInt == 25 && Project82Main.currentStoryIndex == 4) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene", 1.5f);
		} else if (Project82Main.arrStoryInt == 30 && Project82Main.currentStoryIndex == 2) {
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

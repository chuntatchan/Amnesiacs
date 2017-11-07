using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KittyTroubleChecker : MonoBehaviour {


	public GameObject blackscreen;
	private float alpha;
	public string nextSceneString1;
	public string nextSceneString2;
	public string nextSceneString3;

	void Start() {
		alpha = 0;
	}

	void Update () {
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			if (Input.GetKeyDown(KeyCode.Escape)) {
				SceneManager.LoadScene ("DebuggerSelection");
			}
		}
		if (Project82Main.arrStoryInt == 1 && Project82Main.currentStoryIndex == 4) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene1", 1.5f);
		} else if (Project82Main.arrStoryInt == 3 && Project82Main.currentStoryIndex == 2) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			PlayerPrefs.SetInt ("currentTurn", 0);
			Invoke ("nextScene2", 1.5f);
		} else if (Project82Main.arrStoryInt == 5 && Project82Main.currentStoryIndex == 3) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene2", 1.5f);
		} else if (Project82Main.arrStoryInt == 6 && Project82Main.currentStoryIndex == 4) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene3", 1.5f);
		} else if (Project82Main.arrStoryInt == 7 && Project82Main.currentStoryIndex == 3) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene2", 1.5f);
		}
	}

	void nextScene1() {
		SceneManager.LoadScene (nextSceneString1);
	}

	void nextScene2() {
		SceneManager.LoadScene (nextSceneString2);
	}

	void nextScene3() {
		SceneManager.LoadScene (nextSceneString3);
	}

	void fadeInBlackScreen() {
		PlayerPrefs.SetInt ("PreventReturn", 1);
		alpha += 0.02f;
		blackscreen.GetComponent<Image> ().color = new Color (0, 0, 0, alpha);
	}

}

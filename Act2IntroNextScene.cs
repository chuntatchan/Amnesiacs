using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Act2IntroNextScene : MonoBehaviour {

	public int nextSceneGroupText;
	public int nextSceneTextNumber;
	public string nextSceneString;
	public GameObject blackScreen;
	private float alpha;

	void Start() {
		alpha = 0;
	}

	// Update is called once per frame
	void Update () {
		if (Project82Main.arrStoryInt == nextSceneGroupText && Project82Main.currentStoryIndex == nextSceneTextNumber) {
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
		blackScreen.GetComponent<Image> ().color = new Color (0, 0, 0, alpha);
	}

}

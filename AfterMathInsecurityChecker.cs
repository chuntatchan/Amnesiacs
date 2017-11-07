using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AfterMathInsecurityChecker : MonoBehaviour {

	public GameObject blackscreen;
	public Project82Main mainScript;
	private float alpha;
	public string nextSceneString;

	private bool colorChange = true;

	void Start() {
		alpha = 0;
	}

	void Update () {
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				SceneManager.LoadScene ("DebuggerSelection");
			}
		}
		if (Project82Main.arrStoryInt == 3 && Project82Main.currentStoryIndex == 4) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene", 1.5f);
		} else if (Project82Main.arrStoryInt == 4 && Project82Main.currentStoryIndex == 4) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene", 1.5f);
		} else if (Project82Main.arrStoryInt == 5 && Project82Main.currentStoryIndex == 4) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene", 1.5f);
		} else if (Project82Main.arrStoryInt == 4 && colorChange) {
			mainScript.playernum = 1;
			mainScript.textbox.GetComponent<Image> ().color = new Color (0f, 0.09411764705f, 0.21960784313f, 1f);
			mainScript.pointer.GetComponent<SpriteRenderer> ().color = new Color (0.43921568627f, 0.60392156862f, 0.83921568627f, 1f);
			colorChange = false;
		} else if (Project82Main.arrStoryInt == 5 && colorChange) {
			mainScript.playernum = 4;
			mainScript.textbox.GetComponent<Image> ().color = new Color (0.7294117647f, 0.61176470588f, 0.16078431372f, 1f);
			mainScript.pointer.GetComponent<SpriteRenderer> ().color = new Color (1f, 0.91372549019f, 0.5725490196f, 1f);
			colorChange = false;
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

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InjurySceneChecker : MonoBehaviour {
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
		if (Project82Main.arrStoryInt == 3 && Project82Main.currentStoryIndex == 3) {
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

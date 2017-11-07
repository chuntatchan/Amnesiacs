using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeerHelpCheckers : MonoBehaviour {

	public string nextSceneString;
	public GameObject blackscreen;
	private float alpha;
	private bool incrementCurrentTurnOnce;

	// Use this for initialization
	void Start () {
		incrementCurrentTurnOnce = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				SceneManager.LoadScene ("DebuggerSelection");
			}
		}
		if (Project82Main.arrStoryInt == 1 && Project82Main.currentStoryIndex == 2) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			PlayerPrefs.SetInt ("DeerPressure", 1);
			if (incrementCurrentTurnOnce) {
				PlayerPrefs.SetInt ("newPlayerNum", PlayerPrefs.GetInt("newPlayerNum") + 1);
				incrementCurrentTurnOnce = false;
			}
			Invoke ("nextScene", 1.5f);
		} else if (Project82Main.arrStoryInt == 2 && Project82Main.currentStoryIndex == 2) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			PlayerPrefs.SetInt ("DeerSplint", 1);
			if (incrementCurrentTurnOnce) {
				PlayerPrefs.SetInt ("newPlayerNum", PlayerPrefs.GetInt("newPlayerNum") + 1);
				incrementCurrentTurnOnce = false;
			}
			Invoke ("nextScene", 1.5f);
		} else if (Project82Main.arrStoryInt == 3 && Project82Main.currentStoryIndex == 2) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			PlayerPrefs.SetInt ("DeerWounds", 1);
			if (incrementCurrentTurnOnce) {
				PlayerPrefs.SetInt ("newPlayerNum", PlayerPrefs.GetInt("newPlayerNum") + 1);
				incrementCurrentTurnOnce = false;
			}
			Invoke ("nextScene", 1.5f);
		} else if (Project82Main.arrStoryInt == 4 && Project82Main.currentStoryIndex == 2) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			PlayerPrefs.SetInt ("DeerComfort", 1);
			if (incrementCurrentTurnOnce) {
				PlayerPrefs.SetInt ("newPlayerNum", PlayerPrefs.GetInt("newPlayerNum") + 1);
				incrementCurrentTurnOnce = false;
			}
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

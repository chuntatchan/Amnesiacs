using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BlurbScript : MonoBehaviour {

	public float spawnTime;
	public GameObject prompt;
	public string nextSceneString;
	public int newCurrentTurn = -1;

	// Use this for initialization
	void Start () {
		prompt.SetActive (false);
		Invoke ("spawnPrompt", spawnTime);
	}

	void Update() {
		if (prompt.activeInHierarchy) {
			if (Input.GetKeyDown (KeyCode.Return)) {
				if (PlayerPrefs.GetInt ("Debugging") == 1 && PlayerPrefs.GetInt ("SkipToCarCrash") != 1) {
					SceneManager.LoadScene ("DebuggerSelection");
				} else if (nextSceneString == null) {
					Debug.Log ("Please assign a Scene.");
				} else {
					if (newCurrentTurn != -1) {
						PlayerPrefs.SetInt ("currentTurn", newCurrentTurn);
					}
					SceneManager.LoadScene (nextSceneString);
				}
			} else if (Input.GetKeyDown (KeyCode.Escape)) {
				if (PlayerPrefs.GetInt ("Debugging") == 1) {
					SceneManager.LoadScene ("DebuggerSelection");
				}
			}
		}
	}

	void spawnPrompt() {
		prompt.SetActive (true);

	}
}

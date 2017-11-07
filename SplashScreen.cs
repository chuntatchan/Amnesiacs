using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

	public float timeToChange;
	public string nextScene;

	// Use this for initialization
	void Start () {
		Invoke ("changeScene", timeToChange);
	}

	void changeScene() {
		SceneManager.LoadScene (nextScene);
	}

}

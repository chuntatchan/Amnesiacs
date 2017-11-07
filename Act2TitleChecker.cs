using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Act2TitleChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.DeleteAll ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Project82Main.arrStoryInt == 1) {
			SceneManager.LoadScene ("Act2CharacterSelect");
		} else if (Project82Main.arrStoryInt == 3) {
			Application.Quit ();
		} else if (Project82Main.arrStoryInt == 4) {
			SceneManager.LoadScene ("DebuggerLogin");
		} else if (Project82Main.arrStoryInt == 5) {
			SceneManager.LoadScene ("MainMenu");
		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DebuggerLogin : MonoBehaviour {

	[SerializeField]
	private InputField nameInputField = null; // Assign in editor

	// Use this for initialization
	void Start () {
		// Add listener to catch the submit
		InputField.SubmitEvent submitEvent = new InputField.SubmitEvent();
		submitEvent.AddListener(SubmitName);
		nameInputField.onEndEdit = submitEvent;

		// Add validation
		nameInputField.characterValidation = InputField.CharacterValidation.Alphanumeric;
	}

	private void SubmitName(string name) {
		if (nameInputField.text == "") {
			nameInputField.text = "";
		} else if (nameInputField.text == "bleachcheaq") {
			PlayerPrefs.DeleteAll ();
			PlayerPrefs.SetInt ("Debugging", 1);
			SceneManager.LoadScene ("DebuggerSelection");
		} else {
			SceneManager.LoadScene ("MainMenu");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("MainMenu");
		}
	}
}

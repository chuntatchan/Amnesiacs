using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Naming : MonoBehaviour {
	public string[] playerName;
	public static bool playerNameChecker = false;


	[SerializeField]
	private InputField nameInputField = null; // Assign in editor

	private void Start() {
		// Add listener to catch the submit
		InputField.SubmitEvent submitEvent = new InputField.SubmitEvent();
		submitEvent.AddListener(SubmitName);
		nameInputField.onEndEdit = submitEvent;

		// Add validation
		nameInputField.characterValidation = InputField.CharacterValidation.Alphanumeric;

	}

	private void SubmitName(string name) {
		if (nameInputField.text == "") {
			nameInputField.text = "PleaseEnterAName";
		} else {
			//What to do with the value from input field
			playerName [CharacterSelection.currentplayer] = name;
			Debug.Log ("Player" + CharacterSelection.currentplayer + " = " + name);
			CharacterSelection.nameChosen = true;
			nameInputField.text = "";
			}
	}
		
	
	// Update is called once per frame
	void Update () {
		if (CharacterSelection.currentplayer == 4) {
			PlayerPrefs.SetString ("Player 1", playerName [0]);
			PlayerPrefs.SetString ("Player 2", playerName [1]);
			PlayerPrefs.SetString ("Player 3", playerName [2]);
			PlayerPrefs.SetString ("Player 4", playerName [3]);
			playerNameChecker = true;
		}
	
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Main : MonoBehaviour {
	//in-scene references to UI elements
		public Text scenePromptText;
		public LayoutGroup scenePromptOptions;

	//prefab references
		public Prompt firstPrompt; //a reference to the first Prompt object you wish to display.
		public Text uiPromptOptionPrefab; //the prefab for each option shown for a given prompt. these are instantiated via script each time a prompt is shown.

	//internal variables
		private Prompt currentPrompt;
		private int currentOptionIndex; //keeps track of which option is currently selected

	void Start() {
		SetCurrentPrompt( firstPrompt );
	}

	void Update() {
		//handle option selection input

		if ( Input.GetKeyDown( KeyCode.UpArrow ) ) {
			//select previous option (if possible)

			currentOptionIndex = Mathf.Max( currentOptionIndex - 1, 0 );
		} else if ( Input.GetKeyDown( KeyCode.DownArrow ) ) {
			//select next option (if possible)

			currentOptionIndex = Mathf.Min( currentOptionIndex + 1, currentPrompt.promptOptions.Length - 1 );
		} else if ( Input.GetKeyDown( KeyCode.Return ) ) {
			//change the strings to the one referred to by this option

			PromptOption option = currentPrompt.promptOptions[ currentOptionIndex ];
			SetCurrentPrompt( option.optionPrompt );
		}

		//modify appearance of option text if selected (or not)

		for ( int i = 0; i < scenePromptOptions.transform.childCount; i++ ) {
			Transform child = scenePromptOptions.transform.GetChild( i );
			Text childText = child.GetComponent<Text>();

			if ( i == currentOptionIndex ) {
				childText.color = Color.green;
			} else {
				childText.color = Color.white;
			}
		}
	}

	void SetCurrentPrompt( Prompt prompt ) {
		if ( prompt != null ) {
			//destroy old options (if applicable)

			foreach ( Transform option in scenePromptOptions.transform ) {
				Destroy( option.gameObject );
			}

			//assign new prompt

			currentPrompt = prompt;

			//set the main text for this prompt

			scenePromptText.text = currentPrompt.promptString;

			//create new options for this prompt

			foreach ( PromptOption option in currentPrompt.promptOptions ) {
				Text promptOption = Instantiate( uiPromptOptionPrefab ) as Text;
				promptOption.transform.SetParent( scenePromptOptions.transform, false );
				promptOption.text = option.optionString;
			}

			//reset selection to first option

			currentOptionIndex = 0;
		}
	}
}
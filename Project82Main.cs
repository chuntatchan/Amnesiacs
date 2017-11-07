using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Project82Main : MonoBehaviour
{
	private float time;
	private float timeLeft;
	public Text timetbox;
	public int playernum;
	public int xaxis;
	public GameObject background;
	public GameObject pointer;
	public GameObject textbox;
	public Text scenePromptText;
	public LayoutGroup scenePromptOptions;
	public Story StoryStrings;
	//a reference to the first Prompt object you wish to display.
	public Prompt initialPrompt;
	public Sprite initialPicture;
	public UiOption uiPromptOptionPrefab;
	public static int arrStoryInt = 0;
	public static int promptTimer = 0;
	private Story currentStrings;
	public static int currentStoryIndex;
	public static UiOption currentUiOption;
	public static Prompt currentPrompt;
	private int currentOptionIndex;
	private List<string> ownedKeys = new List<string> ();
	private bool optionsActive = false;
	private bool activateTimer;
	private bool isTimerActive = false;
	private bool isInsecurity;
	public static bool insecurityActivatedOnce = false;

	private bool isPaused;
	public GameObject pausedPrefab;
	private GameObject pausedScreen;
		
	private Color newRed = new Color (0.38039215686f, 0.06274509803f, 0.06274509803f, 1f);
	private Color newRedPointer = new Color (0.94117647058f, 0.30588235294f, 0.30588235294f, 1f);
	private Color newYellow = new Color (0.7294117647f, 0.61176470588f, 0.16078431372f, 1f);
	private Color newYellowPointer = new Color (1f, 0.91372549019f, 0.5725490196f, 1f);
	private Color newGreen = new Color (0.07058823529f, 0.16078431372f, 0.0862745098f, 1f);
	private Color newGreenPointer = new Color (0.49019607843f, 0.63921568627f, 0.45490196078f, 1f);
	private Color newBlue = new Color (0f, 0.09411764705f, 0.21960784313f, 1f);
	private Color newBluePointer = new Color (0.43921568627f, 0.60392156862f, 0.83921568627f, 1f);



	// Use this for initialization
	void Start ()
	{
		isPaused = false;
		if (PlayerPrefs.GetInt ("currentTurn") == 1 || PlayerPrefs.GetInt ("currentTurn") == 5) {
			playernum = PlayerPrefs.GetInt ("Player" + PlayerPrefs.GetInt ("OrderFirst").ToString () + "Color");
			Debug.Log (PlayerPrefs.GetInt ("Player" + PlayerPrefs.GetInt ("OrderFirst").ToString () + "Color"));
		} else if (PlayerPrefs.GetInt ("currentTurn") == 2 || PlayerPrefs.GetInt ("currentTurn") == 6) {
			playernum = PlayerPrefs.GetInt ("Player" + PlayerPrefs.GetInt ("OrderSecond").ToString () + "Color");
			Debug.Log (PlayerPrefs.GetInt ("Player" + PlayerPrefs.GetInt ("OrderSecond").ToString () + "Color"));
		} else if (PlayerPrefs.GetInt ("currentTurn") == 3 || PlayerPrefs.GetInt ("currentTurn") == 7) {
			playernum = PlayerPrefs.GetInt ("Player" + PlayerPrefs.GetInt ("OrderThird").ToString () + "Color");
			Debug.Log (PlayerPrefs.GetInt ("Player" + PlayerPrefs.GetInt ("OrderThird").ToString () + "Color"));
		} else if (PlayerPrefs.GetInt ("currentTurn") == 4 || PlayerPrefs.GetInt ("currentTurn") == 8) {
			playernum = PlayerPrefs.GetInt ("Player" + PlayerPrefs.GetInt ("OrderFourth").ToString () + "Color");
			Debug.Log (PlayerPrefs.GetInt ("Player" + PlayerPrefs.GetInt ("OrderFourth").ToString () + "Color"));
		}
		ownedKeys = new List<string> ();
		arrStoryInt = 0;
		promptTimer = 0;
		currentStoryIndex = 0;

		pointer.SetActive (false);
		nextStoryLine (currentStoryIndex);
		currentPrompt = initialPrompt;
		background.GetComponent<Image> ().sprite = initialPicture;
		if (playernum == 1) {
			textbox.GetComponent<Image> ().color = newBlue;
			pointer.GetComponent<SpriteRenderer> ().color = newBluePointer;
		} else if (playernum == 2) {
			textbox.GetComponent<Image> ().color = newGreen;
			pointer.GetComponent<SpriteRenderer> ().color = newGreenPointer;
		} else if (playernum == 3) {
			textbox.GetComponent<Image> ().color = newRed;
			pointer.GetComponent<SpriteRenderer> ().color = newRedPointer;
		} else if (playernum == 4) {
			textbox.GetComponent<Image> ().color = newYellow;
			pointer.GetComponent<SpriteRenderer> ().color = newYellowPointer;
		}
		if (timetbox != null) {
			timetbox.text = "";
		}
		PlayerPrefs.SetInt ("PreventReturn", 0);
		print ("Start Done");
	}
		
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (pausedPrefab != null) {
				if (!isPaused) {
					isPaused = true;
					pausedScreen = Instantiate (pausedPrefab, new Vector3 (0, 0, 100f), gameObject.transform.rotation);
					Time.timeScale = 0;
					Time.fixedDeltaTime = 0;
				} else {
					unpauseGame ();
				}
			}
		} else if (Input.GetKeyDown (KeyCode.R) && isPaused) {
			SceneManager.LoadScene ("MainMenu");
		}

		if (!isPaused) {

			if (activateTimer && scenePromptOptions.transform.childCount != 1) {
				timeLeft -= Time.deltaTime;
				timetbox.text = Mathf.Round (timeLeft).ToString ();
				if (timeLeft < 0) {
					if (currentPrompt.TimerForceChoice) {
						currentOptionIndex = currentPrompt.TimerForceOptionInt;
						for (int i = 0; i < 10; i++) {
							ownedKeys.Remove ("disappearChoice" + i.ToString ());
						}
						activateTimer = false;
						if (timetbox != null) {
							timetbox.text = "";
						}
						deactivateDecisions (currentPrompt);
						insecurityActivatedOnce = false;
						isTimerActive = false;
						PromptOption option = currentUiOption.option;
						arrStoryInt = option.nextLinesInt;
						currentStoryIndex = option.startingInt;
						promptTimer = option.startingInt;
						currentPrompt = option.optionPrompt;
						if (option.picture != null) {
							background.GetComponent<Image> ().sprite = option.picture;
						}
						if (option.sound != null) {
							AudioSource.PlayClipAtPoint (option.sound, new Vector3 (0, 0, 0));
						}
						foreach (string grantedKey in option.grantedKeys) {
							ownedKeys.Add (grantedKey);
						}
						nextStoryLine (currentStoryIndex);
					} else {
						timetbox.text = "";
						deleteChoice ();
					}
				}
			}

			if (DinerRound1NextPlayerCheck.timeDelay == true || ElectronicsCheckers.timeDelay == true || GiftShopCheckers.timeDelay == true || MechanicCheckers.timeDelay == true) {
				nextStoryLine (currentStoryIndex);
				DinerRound1NextPlayerCheck.timeDelay = false;
				ElectronicsCheckers.timeDelay = false;
				GiftShopCheckers.timeDelay = false;
				MechanicCheckers.timeDelay = false;
			}


			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				//select previous option (if possible)
				if (optionsActive) {
					insecurityActivatedOnce = false;
					deactivateDecisions (currentPrompt);
					if (currentOptionIndex == 0) {
						currentOptionIndex = scenePromptOptions.transform.childCount - 1;
					} else {
						currentOptionIndex = Mathf.Max (currentOptionIndex - 1, 0);
					}
					activateDecisions (currentPrompt, currentOptionIndex);
				}

			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				//select next option (if possible)
				if (optionsActive) {
					insecurityActivatedOnce = false;
					deactivateDecisions (currentPrompt);
					if (currentOptionIndex == scenePromptOptions.transform.childCount - 1) {
						currentOptionIndex = 0;
					} else {
						currentOptionIndex = Mathf.Min (currentOptionIndex + 1, scenePromptOptions.transform.childCount - 1);
					}
					activateDecisions (currentPrompt, currentOptionIndex);
				}
			} else if (Input.GetKeyDown (KeyCode.Return) && PlayerPrefs.GetInt ("PreventReturn") != 1) {
				if (promptTimer == StoryStrings.StoryLines [arrStoryInt].StoryText.Length + 1) {
					for (int i = 0; i < 10; i++) {
						ownedKeys.Remove ("disappearChoice" + i.ToString ());
					}
					activateTimer = false;
					if (timetbox != null) {
						timetbox.text = "";
					}
					deactivateDecisions (currentPrompt);
					insecurityActivatedOnce = false;
					isTimerActive = false;
					PromptOption option = currentUiOption.option;
					arrStoryInt = option.nextLinesInt;
					currentStoryIndex = option.startingInt;
					promptTimer = option.startingInt;
					currentPrompt = option.optionPrompt;
					if (option.picture != null) {
						background.GetComponent<Image> ().sprite = option.picture;
					}
					if (option.sound != null) {
						AudioSource.PlayClipAtPoint (option.sound, new Vector3 (0, 0, -10));
					}
					foreach (string grantedKey in option.grantedKeys) {
						ownedKeys.Add (grantedKey);
					}					
				}
				nextStoryLine (currentStoryIndex);
			} else if (Input.GetKeyDown (KeyCode.Backspace)) {
				if (optionsActive == false && PlayerPrefs.GetInt ("Debugging") == 1) {
					if (currentStoryIndex != 1) {
						previousStoryLine (currentStoryIndex);
					}
				}
			} else if (Input.GetKeyDown (KeyCode.Escape)) {
				if (PlayerPrefs.GetInt ("Debugging") == 1) {
					SceneManager.LoadScene ("DebuggerSelection");
				}
			}
			if (promptTimer == StoryStrings.StoryLines [arrStoryInt].StoryText.Length + 1) {
				movePointer ();
				Transform t = scenePromptOptions.transform.GetChild (currentOptionIndex); //get the child of the the "UiOptions" object corresponding to the current option index
				currentUiOption = t.GetComponent<UiOption> (); //store a reference to the UiOption component of this child
			}
			if (Input.GetKeyDown (KeyCode.C)) {
				print ("currentStoryIndex: " + currentStoryIndex);
				print ("arrStoryInt: " + arrStoryInt);
				print ("currentTurn " + PlayerPrefs.GetInt ("currentTurn").ToString ());
			}
			if (promptTimer == StoryStrings.StoryLines [arrStoryInt].StoryText.Length) {
				activateDecisions (currentPrompt, 0);
				currentStoryIndex = 0;
				promptTimer += 1;
			}
			for (int i = 0; i < scenePromptOptions.transform.childCount; i++) {
				Transform child = scenePromptOptions.transform.GetChild (i);
				Text childText = child.GetComponent<Text> ();
				childText.fontSize = 15;

				if (i == currentOptionIndex) {
					if (playernum == 1) {
						childText.color = newBluePointer;
					} else if (playernum == 2) {
						childText.color = newGreenPointer;
					} else if (playernum == 3) {
						childText.color = newRedPointer;
					} else if (playernum == 4) {
						childText.color = newYellowPointer;
					}
				} else {
					childText.color = Color.white;
				}
			}
		}
	}



	public void unpauseGame() {
		isPaused = false;
		Destroy (pausedScreen);
		Time.timeScale = 1;
		Time.fixedDeltaTime = 1;
	}

	void nextStoryLine (int currentindex)
	{
		promptTimer += 1;
		scenePromptText.text = StoryStrings.StoryLines [arrStoryInt].StoryText [currentindex];
		currentStoryIndex += 1;
	}

	void previousStoryLine (int currentindex)
	{
		currentindex -= 1;
		promptTimer -= 1;
		currentStoryIndex -= 1;
		scenePromptText.text = StoryStrings.StoryLines [arrStoryInt].StoryText [currentindex - 1];
	}

	void activateDecisions (Prompt prompt, int currentOptionInt)
	{
		optionsActive = true;
		if (currentPrompt.noPointer == false) {
			pointer.SetActive (true);
		}
		currentOptionIndex = currentOptionInt;
		//assign new prompt
		if (prompt == null) {
			Debug.Log ("NoPrompt");
		} else {
			currentPrompt = prompt;
			scenePromptText.text = currentPrompt.promptString;
			
			foreach (PromptOption option in prompt.promptOptions) {
				bool valid = true;

				foreach (string requiredKey in option.requiredKeys) {
					if (!ownedKeys.Contains (requiredKey)) {
						valid = false;
						break;
					} else if (PlayerPrefs.HasKey (requiredKey)) {
						if (PlayerPrefs.GetInt (requiredKey) != 1) {
							valid = false;
							break;
						}
					}

				}

				foreach (string forbiddenKey in option.forbiddenKeys) {
					if (ownedKeys.Contains (forbiddenKey)) {
						valid = false;
						break;
					} else if (PlayerPrefs.HasKey (forbiddenKey)) {
						if (PlayerPrefs.GetInt (forbiddenKey) == 1) {
							valid = false;
							break;
						}
					}
				}

				//at this point, we now know whether the option is valid to display. so we create the option in the UI accordingly.

				if (valid == true) {
					UiOption uiOption = Instantiate (uiPromptOptionPrefab) as UiOption;
					uiOption.transform.SetParent (scenePromptOptions.transform, false);
					uiOption.text.text = option.optionString;
					if (option.fontFace != null) {
						uiOption.text.font = option.fontFace;
					}
					uiOption.text.alignment = option.alignment;
					//the UI option needs a reference to the actual option in order for Update (above) to know which option that the current UI option refers to

					uiOption.option = option;
				}
			}
		}
		if (timetbox != null) {
			if (currentPrompt.useTimer && PlayerPrefs.GetInt ("Debugging") != 1) {
				if (scenePromptOptions.transform.childCount == 1) {
					activateTimer = false;
					Debug.Log ("activateTimerFalse");
				} else {
					time = currentPrompt.time;
					activateTimer = true;
					if (isTimerActive == false) {
						timeLeft = time;
						isTimerActive = true;
					}
					Debug.Log ("activateTimerTrue");
				}
			}
			if (currentPrompt.hideTimer) {
				timetbox.color = new Color (0,0,0,0);
			}
		}
	}

	void deactivateDecisions (Prompt prompt)
	{
		optionsActive = false;
		pointer.SetActive (false);
		if (prompt != null) {
			//destroy old options (if applicable)
			foreach (Transform uiOption in scenePromptOptions.transform) {
				Destroy (uiOption.gameObject);
			}
		}
	}

	void deleteChoice ()
	{
		timeLeft = time;
		int counter = 1;
		int num = scenePromptOptions.transform.childCount - counter;
		if (scenePromptOptions.transform.childCount != 1) {
			ownedKeys.Add ("disappearChoice" + num.ToString ());
			counter += 1;
			Debug.Log ("ChoiceDeleteNum: " + num.ToString ());
			deactivateDecisions (currentPrompt);
			activateDecisions (currentPrompt, 0);
		}

	}

	void ifAddKey (string name)
	{
		if (PlayerPrefs.GetInt (name) == 1) {
			ownedKeys.Add (name);
		}
	}

	public void movePointer ()
	{
		if (scenePromptOptions.transform.GetChild (currentOptionIndex) != null) {
			Vector3 temp = new Vector3 (xaxis, scenePromptOptions.transform.GetChild (currentOptionIndex).transform.position.y * 60f, 0);
			pointer.transform.localPosition = temp;
		}
	}

}
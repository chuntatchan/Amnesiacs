using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {

	public GameObject[] choices;
	public GameObject[] player;
	public GameObject[] playerlocs;
	public GameObject[] playerpointer;
	public GameObject[] pointerlocs;
	public int[] playerchoice;
	public static int player1choice;
	public static int player2choice;
	public static int player3choice;
	public static int player4choice;
	public double yaxis;
	private bool choice0active;
	private bool choice1active;
	private bool choice2active;
	private bool choice3active;
	private int currentoption;
	public static int currentplayer;
	public static bool nameChosen = false;
	public static bool playerChoicechecker = false;
	public Color playerRed;
	public Color playerGreen;
	public Color playerBlue;
	public Color playerYellow;

	public string nextScene;

	// Use this for initialization
	void Start () {
		for (int i = 1; i < 4; i++) {
			player [i].SetActive (false);
			playerpointer [i].SetActive (false);
		}
		movePointer ();
		currentplayer = 0;
		currentoption = 0;
	}

	// Update is called once per frame
	void Update () {
		if (nameChosen == true) {
			if (currentoption == 0) {
				if (choice0active == false) {
					playerchoice [currentplayer] = 0;
					choice0active = true;
					currentplayer += 1;
				}	
			} else if (currentoption == 1) {
				if (choice1active == false) {
					playerchoice [currentplayer] = 1;
					choice1active = true;
					currentplayer += 1;
				}
			} else if (currentoption == 2) {
				if (choice2active == false) {
					playerchoice [currentplayer] = 2;
					choice2active = true;
					currentplayer += 1;
				}
			} else if (currentoption == 3) {
				if (choice3active == false) {
					playerchoice [currentplayer] = 3;
					choice3active = true;
					currentplayer += 1;
				}
			}
			player [currentplayer].SetActive (true);
			playerpointer [currentplayer].SetActive (true);
			if (choice0active == false) {
				currentoption = 0;
			} else if (choice1active == false) {
				currentoption = 1;
			} else if (choice2active == false) {
				currentoption = 2;
			} else if (choice3active == false) {
				currentoption = 3;
			}
			movePointer ();
			Debug.Log (currentplayer);
			nameChosen = false;
		} /* else if (Input.GetKeyDown (KeyCode.LeftArrow)) { //Move Left and Right on CharacterSelection
			
			if (currentplayer != 3 && currentoption > 0) {
				currentoption -= 1;
				if (currentoption == 2 && choice2active == true) {
					currentoption -= 1;
				}
				if (currentoption == 1 && choice1active == true) {
					currentoption -= 1;
				}
				if (currentoption == 0 && choice0active == true) {
					currentoption += 1;
					if (currentoption == 1 && choice1active == true) {
						currentoption += 1;
					}
					if (currentoption == 2 && choice2active == true) {
						currentoption += 1;
					}

				}
				movePointer ();
			}
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if (currentplayer != 3 && currentoption < choices.Length - 1) {
				currentoption += 1;
				if (currentoption == 1 && choice1active == true) {
					currentoption += 1;
				}
				if (currentoption == 2 && choice2active == true) {
					currentoption += 1;
				}
				if (currentoption == 3 && choice3active == true) {
					currentoption -= 1;
					if (currentoption == 2 && choice2active == true) {
						currentoption -= 1;
					}
					if (currentoption == 1 && choice1active == true) {
						currentoption -= 1;
					}
				}
				movePointer ();
			}
		}
		*/
		if (currentplayer == 4) {
			player1choice = playerchoice [0] + 1;
			player2choice = playerchoice [1] + 1;
			player3choice = playerchoice [2] + 1;
			player4choice = playerchoice [3] + 1;
			playerChoicechecker = true;
		}
		if (playerChoicechecker == true && Naming.playerNameChecker == true) {
			//Load Next Scene
			SceneManager.LoadScene(nextScene);
		}
	}

	public void movePointer() {
		player [currentplayer].transform.position = playerlocs[currentoption].transform.position;
		playerpointer [currentplayer].transform.position = pointerlocs [currentoption].transform.position;
		if (currentoption == 0) {
			playerpointer [currentplayer].GetComponent<SpriteRenderer> ().color = playerBlue;
			player [currentplayer].GetComponent<Text> ().color = playerBlue;
		} else if (currentoption == 1) {
			playerpointer [currentplayer].GetComponent<SpriteRenderer> ().color = playerGreen;
			player [currentplayer].GetComponent<Text>().color = playerGreen;
		} else if (currentoption == 2) {
			playerpointer [currentplayer].GetComponent<SpriteRenderer> ().color = playerRed;
			player [currentplayer].GetComponent<Text>().color = playerRed;
		} else if (currentoption == 3) {
			playerpointer [currentplayer].GetComponent<SpriteRenderer> ().color = playerYellow;
			player [currentplayer].GetComponent<Text>().color = playerYellow;
		}

	}
}

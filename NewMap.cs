using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewMap : MonoBehaviour {

	public string Team;
	private int mapSelection = 0;
	private int previousMapSelection;
	private int playernum = 0;
	public GameObject[] Images;
	public GameObject[] GreyOutImages;
	public GameObject SelectionBox;
	public GameObject SelectionColorBox;

	public GameObject[] charaBox;
	public Text[] charaBoxText;

	public Color newBlue;
	public Color newGreen;
	public Color newRed;
	public Color newYellow;



	// Use this for initialization
	void Start () {
		
		determinePlayer ();

		if (playernum == 1) {
			SelectionColorBox.GetComponent<Image> ().color = newBlue;
		} else if (playernum == 2) {
			SelectionColorBox.GetComponent<Image> ().color = newGreen;
		} else if (playernum == 3) {
			SelectionColorBox.GetComponent<Image> ().color = newRed;
		} else if (playernum == 4) {
			SelectionColorBox.GetComponent<Image> ().color = newYellow;
		}

		if (Team == "A") {
			if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderFirst").ToString () + "Team") == "A") {
				charaBox [0].GetComponent<Image> ().color = newBlue;
				charaBoxText [0].text = PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFirst").ToString ()).ToString ();
			} else if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderSecond").ToString () + "Team") == "A") {
				charaBox [0].GetComponent<Image> ().color = newGreen;
				charaBoxText [0].text = PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderSecond").ToString ()).ToString ();
			} else if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderThird").ToString () + "Team") == "A") {
				charaBox [0].GetComponent<Image> ().color = newRed;
				charaBoxText [0].text = PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderThird").ToString ()).ToString ();
			}
			if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderFourth").ToString () + "Team") == "A") {
				charaBox [1].GetComponent<Image> ().color = newYellow;
				charaBoxText [1].text = PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFourth").ToString ()).ToString ();
			} else if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderThird").ToString () + "Team") == "A") {
				charaBox [1].GetComponent<Image> ().color = newRed;
				charaBoxText [1].text = PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderThird").ToString ()).ToString ();
			} else if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderSecond").ToString () + "Team") == "A") {
				charaBox [1].GetComponent<Image> ().color = newGreen;
				charaBoxText [1].text = PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderSecond").ToString ()).ToString ();
			}
		} else if (Team == "B") {
			if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderFirst").ToString () + "Team") == "B") {
				charaBox [0].GetComponent<Image> ().color = newBlue;
				charaBoxText [0].text = PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFirst").ToString ()).ToString ();
			} else if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderSecond").ToString () + "Team") == "B") {
				charaBox [0].GetComponent<Image> ().color = newGreen;
				charaBoxText [0].text = PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderSecond").ToString ()).ToString ();
			} else if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderThird").ToString () + "Team") == "B") {
				charaBox [0].GetComponent<Image> ().color = newRed;
				charaBoxText [0].text = PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderThird").ToString ()).ToString ();
			}
			if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderFourth").ToString () + "Team") == "B") {
				charaBox [1].GetComponent<Image> ().color = newYellow;
				charaBoxText [1].text = PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFourth").ToString ()).ToString ();
			} else if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderThird").ToString () + "Team") == "B") {
				charaBox [1].GetComponent<Image> ().color = newRed;
				charaBoxText [1].text = PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderThird").ToString ()).ToString ();
			} else if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderSecond").ToString () + "Team") == "B") {
				charaBox [1].GetComponent<Image> ().color = newGreen;
				charaBoxText [1].text = PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderSecond").ToString ()).ToString ();
			}
		}

		if (PlayerPrefs.GetInt ("DinerAttempted") == 1) {
			GreyOutImages [0].GetComponent<Image> ().color = new Color (0f, 0f, 0f, 0.88f);
		}
		if (PlayerPrefs.GetInt ("ElectronicsAttempted") == 1) {
			GreyOutImages [1].GetComponent<Image> ().color = new Color (0f, 0f, 0f, 0.88f);
		}
		if (PlayerPrefs.GetInt ("GiftShopAttempted") == 1) {
			GreyOutImages [2].GetComponent<Image> ().color = new Color (0f, 0f, 0f, 0.88f);
		}
		if (PlayerPrefs.GetInt ("MechanicsAttempted") == 1) {
			GreyOutImages [3].GetComponent<Image> ().color = new Color (0f, 0f, 0f, 0.88f);
		}

		for (int i = 0; i < 4; i++) {
			GreyOutImages [i].SetActive (true);
		}

		if (PlayerPrefs.GetInt ("DinerAttempted") == 1) {
			mapSelection++;
			if (PlayerPrefs.GetInt ("ElectronicsAttempted") == 1) {
				mapSelection++;
				if (PlayerPrefs.GetInt ("GiftShopAttempted") == 1) {
					mapSelection++;
					if (PlayerPrefs.GetInt ("MechanicsAttempted") == 1) {

						// Implement feature:
						// if there's no more locations to go to, the other team is able to go to
						// the last location; hence two teams in one location.
						// Notes: PlayerPrefs.GetString("Team"+oppTeam+"Location");
						if (Team == "A") {
							if (PlayerPrefs.GetString ("TeamBLocation") == "Diner") {
								mapSelection = 0;
							} else if (PlayerPrefs.GetString ("TeamBLocation") == "Electronics") {
								mapSelection = 1;
							} else if (PlayerPrefs.GetString ("TeamBLocation") == "Gift Shop") {
								mapSelection = 2;
							} else if (PlayerPrefs.GetString ("TeamBLocation") == "Mechanic") {
								mapSelection = 3;
							}
						} else if (Team == "B") {
							if (PlayerPrefs.GetString ("TeamALocation") == "Diner") {
								mapSelection = 0;
							} else if (PlayerPrefs.GetString ("TeamALocation") == "Electronics") {
								mapSelection = 1;
							} else if (PlayerPrefs.GetString ("TeamALocation") == "Gift Shop") {
								mapSelection = 2;
							} else if (PlayerPrefs.GetString ("TeamALocation") == "Mechanic") {
								mapSelection = 3;
							}
						}
						GreyOutImages [mapSelection].SetActive (false);

					}
				}
			}
		}

		GreyOutImages [mapSelection].SetActive (false);
		SelectionBox.transform.position = Images [mapSelection].transform.position;

		if (Team == "B") {
			PlayerPrefs.SetInt ("MapNotRoundOne", 1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			if (Input.GetKeyDown (KeyCode.C)) {
				print ("mapSelection: " + mapSelection);
				print ("Current Turn: " + PlayerPrefs.GetInt("currentTurn"));
			}
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				if (mapSelection == 2 || mapSelection == 3) {
					if (mapSelection - 2 == 0 && PlayerPrefs.GetInt ("DinerAttempted") == 1) {
						//Don't do anything
					} else if (mapSelection - 2 == 1 && PlayerPrefs.GetInt ("ElectronicsAttempted") == 1) {
						//Don't do anything
					} else {
						GreyOutImages [mapSelection].SetActive (true);
						mapSelection -= 2;
						GreyOutImages [mapSelection].SetActive (false);
					}
				}
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) { 
				if (mapSelection == 0 || mapSelection == 1) {
					if (mapSelection + 2 == 2 && PlayerPrefs.GetInt ("GiftShopAttempted") == 1) {
						//Don't do anything
					} else if (mapSelection + 2 == 3 && PlayerPrefs.GetInt ("MechanicsAttempted") == 1) {
						//Don't do anything
					} else {
						GreyOutImages [mapSelection].SetActive (true);
						mapSelection += 2;
						GreyOutImages [mapSelection].SetActive (false);
					}
				}
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				if (mapSelection == 1 || mapSelection == 3) {
					if (mapSelection - 1 == 0 && PlayerPrefs.GetInt ("DinerAttempted") == 1) {
						//Don't do anything
					} else if (mapSelection - 1 == 2 && PlayerPrefs.GetInt ("GiftShopAttempted") == 1) {
						//Don't do anything
					} else {
						GreyOutImages [mapSelection].SetActive (true);
						mapSelection--;
						GreyOutImages [mapSelection].SetActive (false);
					}
				}
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				if (mapSelection == 0 || mapSelection == 2) {
					if (mapSelection + 1 == 1 && PlayerPrefs.GetInt ("ElectronicsAttempted") == 1) {
						//Don't do anything
					} else if (mapSelection + 1 == 3 && PlayerPrefs.GetInt ("MechanicsAttempted") == 1) {
						//Don't do anything
					} else {
						GreyOutImages [mapSelection].SetActive (true);
						mapSelection++;
						GreyOutImages [mapSelection].SetActive (false);
					}
				}
			} else if (Input.GetKeyDown (KeyCode.Return)) {
				if (mapSelection == 0) {
					PlayerPrefs.SetString ("Team"+Team+"Location", "Diner");
					Debug.Log ("Team"+Team+"Loc = " + PlayerPrefs.GetString("Team"+Team+"Location"));
					PlayerPrefs.SetInt ("DinerAttempted", 1);
				} else if (mapSelection == 1) {
					PlayerPrefs.SetString ("Team"+Team+"Location", "Electronics");
					Debug.Log ("Team"+Team+"Loc = " + PlayerPrefs.GetString("Team"+Team+"Location"));
					PlayerPrefs.SetInt ("ElectronicsAttempted", 1);
				} else if (mapSelection == 2) {
					PlayerPrefs.SetString ("Team"+Team+"Location", "Gift Shop");
					Debug.Log ("Team"+Team+"Loc = " + PlayerPrefs.GetString("Team"+Team+"Location"));
					PlayerPrefs.SetInt ("GiftShopAttempted", 1);
				} else if (mapSelection == 3) {
					PlayerPrefs.SetString ("Team"+Team+"Location", "Mechanic");
					Debug.Log ("Team"+Team+"Loc = " + PlayerPrefs.GetString("Team"+Team+"Location"));
					PlayerPrefs.SetInt ("MechanicsAttempted", 1);
				}
				if (PlayerPrefs.GetInt ("MapNotRoundOne") == 1) {
					SceneManager.LoadScene ("Act1Part3Loading");
				} else {
					if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderFirst").ToString () + "Team") == "B") {
						PlayerPrefs.SetInt ("currentTurn", 1);
					} else if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderSecond").ToString () + "Team") == "B") {
						PlayerPrefs.SetInt ("currentTurn", 2);
					} else if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderThird").ToString () + "Team") == "B") {
						PlayerPrefs.SetInt ("currentTurn", 3);
					} else if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderFourth").ToString () + "Team") == "B") {
						PlayerPrefs.SetInt ("currentTurn", 4);
					}
					SceneManager.LoadScene ("NewMapB");
				}
			}

			SelectionBox.transform.position = Images [mapSelection].transform.position;

		}
	}

	void determinePlayer() {
		if (PlayerPrefs.GetInt("currentTurn") == 1 || PlayerPrefs.GetInt("currentTurn") == 5) {
			playernum = PlayerPrefs.GetInt ("Player" + PlayerPrefs.GetInt("OrderFirst").ToString() + "Color");
			Debug.Log (PlayerPrefs.GetInt ("Player" + PlayerPrefs.GetInt("OrderFirst").ToString() + "Color"));
		} else if (PlayerPrefs.GetInt("currentTurn") == 2  || PlayerPrefs.GetInt("currentTurn") == 6) {
			playernum = PlayerPrefs.GetInt ("Player" + PlayerPrefs.GetInt("OrderSecond").ToString() + "Color");
			Debug.Log (PlayerPrefs.GetInt ("Player" + PlayerPrefs.GetInt("OrderSecond").ToString() + "Color"));
		} else if (PlayerPrefs.GetInt("currentTurn") == 3  || PlayerPrefs.GetInt("currentTurn") == 7) {
			playernum = PlayerPrefs.GetInt ("Player" + PlayerPrefs.GetInt("OrderThird").ToString() + "Color");
			Debug.Log (PlayerPrefs.GetInt ("Player" + PlayerPrefs.GetInt("OrderThird").ToString() + "Color"));
		} else if (PlayerPrefs.GetInt("currentTurn") == 4  || PlayerPrefs.GetInt("currentTurn") == 8) {
			playernum = PlayerPrefs.GetInt ("Player" + PlayerPrefs.GetInt("OrderFourth").ToString() + "Color");
			Debug.Log (PlayerPrefs.GetInt ("Player" + PlayerPrefs.GetInt("OrderFourth").ToString() + "Color"));
		}
	}
}

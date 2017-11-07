using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Act1Part3NextPlayerScript : MonoBehaviour {

	public Text tbox;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt("Map") == 1 && PlayerPrefs.GetInt("fuel") == 1 && PlayerPrefs.GetInt("tires") == 1 && PlayerPrefs.GetInt("DinerDone") == 1 && PlayerPrefs.GetInt("ElectronicsDone") == 1 ) {
			SceneManager.LoadScene ("EndAct1");
		}
		if (PlayerPrefs.GetInt ("currentTurn") == 1) {
			tbox.text = "Pass the keyboard to " + "<color=#001773FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFirst").ToString ()).ToString () + "</color>";
		} else if (PlayerPrefs.GetInt ("currentTurn") == 2) {
			tbox.text = "Pass the keyboard to " + "<color=#026D06FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderSecond").ToString ()).ToString () + "</color>";
		} else if (PlayerPrefs.GetInt ("currentTurn") == 3) {
			tbox.text = "Pass the keyboard to " + "<color=#831010FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderThird").ToString ()).ToString () + "</color>";
		} else if (PlayerPrefs.GetInt ("currentTurn") == 4) {
			tbox.text = "Pass the keyboard to " + "<color=#927A1EFF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFourth").ToString ()).ToString () + "</color>";
		} else if (PlayerPrefs.GetInt ("currentTurn") == 5) {
			tbox.text = "Pass the keyboard to " + "<color=#001773FF>" +PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFirst").ToString ()).ToString () + "</color>";
			PlayerPrefs.SetInt("currentTurn", 1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) {
			Debug.Log ("PressedEnter");
			if (PlayerPrefs.GetInt ("currentTurn") == 1) {
				if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderFirst").ToString () + "Team") == "A") {
					if (PlayerPrefs.GetString("TeamALocation") == "Electronics") {
						PlayerPrefs.SetInt ("ElectronicsAttempted", 1);
						PlayerPrefs.SetString ("ElectronicsTeam", "A");
						Debug.Log ("ElectronicsTeam"+PlayerPrefs.GetString("ElectronicsTeam").ToString());
						SceneManager.LoadScene ("Electronics");
					} else if (PlayerPrefs.GetString("TeamALocation") == "Mechanic") {
						PlayerPrefs.SetString ("MechanicsTeam", "A");
						PlayerPrefs.SetInt ("MechanicsAttempted", 1);
						SceneManager.LoadScene ("MechanicRound1");
					} else if (PlayerPrefs.GetString("TeamALocation") == "Gift Shop") {
						PlayerPrefs.SetInt ("GiftShopAttempted", 1);
						PlayerPrefs.SetString ("GiftShopTeam", "A");
						SceneManager.LoadScene ("Gift Shop");
					} else if (PlayerPrefs.GetString("TeamALocation") == "Diner") {
						PlayerPrefs.SetString ("DinerTeam", "A");
						Debug.Log ("DinerTeam"+PlayerPrefs.GetString("DinerTeam").ToString());
						PlayerPrefs.SetInt ("DinerAttempted", 1);
						SceneManager.LoadScene ("DinerRound1");
					}
				} else if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderFirst").ToString () + "Team") == "B") {
					if (PlayerPrefs.GetString("TeamBLocation") == "Electronics") {
						PlayerPrefs.SetString ("ElectronicsTeam", "B");
						Debug.Log ("ElectronicsTeam"+PlayerPrefs.GetString("ElectronicsTeam").ToString());
						PlayerPrefs.SetInt ("ElectronicsAttempted", 1);
						SceneManager.LoadScene ("Electronics");
					} else if (PlayerPrefs.GetString("TeamBLocation") == "Mechanic") {
						PlayerPrefs.SetString ("MechanicsTeam", "B");
						PlayerPrefs.SetInt ("MechanicsAttempted", 1);
						SceneManager.LoadScene ("MechanicRound1");
					} else if (PlayerPrefs.GetString("TeamBLocation") == "Gift Shop") {
						PlayerPrefs.SetInt ("GiftShopAttempted", 1);
						PlayerPrefs.SetString ("GiftShopTeam", "B");
						SceneManager.LoadScene ("Gift Shop");
					} else if (PlayerPrefs.GetString("TeamBLocation") == "Diner") {
						PlayerPrefs.SetString ("DinerTeam", "B");
						Debug.Log ("DinerTeam"+PlayerPrefs.GetString("DinerTeam").ToString());
						PlayerPrefs.SetInt ("DinerAttempted", 1);
						SceneManager.LoadScene ("DinerRound1");
					}
				}
			} else if (PlayerPrefs.GetInt ("currentTurn") == 2) {
				if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderSecond").ToString () + "Team") == "A") {
					if (PlayerPrefs.GetString("TeamALocation") == "Electronics") {
						PlayerPrefs.SetString ("ElectronicsTeam", "A");
						Debug.Log ("ElectronicsTeam"+PlayerPrefs.GetString("ElectronicsTeam").ToString());
						PlayerPrefs.SetInt ("ElectronicsAttempted", 1);
						SceneManager.LoadScene ("Electronics");
					} else if (PlayerPrefs.GetString("TeamALocation") == "Mechanic") {
						PlayerPrefs.SetString ("MechanicsTeam", "A");
						PlayerPrefs.SetInt ("MechanicsAttempted", 1);
						SceneManager.LoadScene ("MechanicRound1");
					} else if (PlayerPrefs.GetString("TeamALocation") == "Gift Shop") {
						PlayerPrefs.SetInt ("GiftShopAttempted", 1);
						PlayerPrefs.SetString ("GiftShopTeam", "A");
						SceneManager.LoadScene ("Gift Shop");
					} else if (PlayerPrefs.GetString("TeamALocation") == "Diner") {
						PlayerPrefs.SetInt ("DinerAttempted", 1);
						PlayerPrefs.SetString ("DinerTeam", "A");
						Debug.Log ("DinerTeam"+PlayerPrefs.GetString("DinerTeam").ToString());
						SceneManager.LoadScene ("DinerRound1");
					}
				} else if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderSecond").ToString () + "Team") == "B") {
					if (PlayerPrefs.GetString("TeamBLocation") == "Electronics") {
						PlayerPrefs.SetString ("ElectronicsTeam", "B");
						Debug.Log ("ElectronicsTeam"+PlayerPrefs.GetString("ElectronicsTeam").ToString());
						PlayerPrefs.SetInt ("ElectronicsAttempted", 1);
						SceneManager.LoadScene ("Electronics");
					} else if (PlayerPrefs.GetString("TeamBLocation") == "Mechanic") {
						PlayerPrefs.SetString ("MechanicsTeam", "B");
						PlayerPrefs.SetInt ("MechanicsAttempted", 1);
						SceneManager.LoadScene ("MechanicRound1");
					} else if (PlayerPrefs.GetString("TeamBLocation") == "Gift Shop") {
						PlayerPrefs.SetInt ("GiftShopAttempted", 1);
						PlayerPrefs.SetString ("GiftShopTeam", "B");
						SceneManager.LoadScene ("Gift Shop");
					} else if (PlayerPrefs.GetString("TeamBLocation") == "Diner") {
						PlayerPrefs.SetString ("DinerTeam", "B");
						Debug.Log ("DinerTeam"+PlayerPrefs.GetString("DinerTeam").ToString());
						PlayerPrefs.SetInt ("DinerAttempted", 1);
						SceneManager.LoadScene ("DinerRound1");
					}
				}
			} else if (PlayerPrefs.GetInt ("currentTurn") == 3) {
				if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderThird").ToString () + "Team") == "A") {
					if (PlayerPrefs.GetString("TeamALocation") == "Electronics") {
						PlayerPrefs.SetString ("ElectronicsTeam", "A");
						Debug.Log ("ElectronicsTeam"+PlayerPrefs.GetString("ElectronicsTeam").ToString());
						PlayerPrefs.SetInt ("ElectronicsAttempted", 1);
						SceneManager.LoadScene ("Electronics");
					} else if (PlayerPrefs.GetString("TeamALocation") == "Mechanic") {
						PlayerPrefs.SetString ("MechanicsTeam", "A");
						PlayerPrefs.SetInt ("MechanicsAttempted", 1);
						SceneManager.LoadScene ("MechanicRound1");
					} else if (PlayerPrefs.GetString("TeamALocation") == "Gift Shop") {
						PlayerPrefs.SetInt ("GiftShopAttempted", 1);
						PlayerPrefs.SetString ("GiftShopTeam", "A");
						SceneManager.LoadScene ("Gift Shop");
					} else if (PlayerPrefs.GetString("TeamALocation") == "Diner") {
						PlayerPrefs.SetString ("DinerTeam", "A");
						Debug.Log ("DinerTeam"+PlayerPrefs.GetString("DinerTeam").ToString());
						PlayerPrefs.SetInt ("DinerAttempted", 1);
						SceneManager.LoadScene ("DinerRound1");
					}
				} else if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderThird").ToString () + "Team") == "B") {
					if (PlayerPrefs.GetString("TeamBLocation") == "Electronics") {
						PlayerPrefs.SetString ("ElectronicsTeam", "B");
						Debug.Log ("ElectronicsTeam"+PlayerPrefs.GetString("ElectronicsTeam").ToString());
						PlayerPrefs.SetInt ("ElectronicsAttempted", 1);
						SceneManager.LoadScene ("Electronics");
					} else if (PlayerPrefs.GetString("TeamBLocation") == "Mechanic") {
						PlayerPrefs.SetString ("MechanicsTeam", "B");
						PlayerPrefs.SetInt ("MechanicsAttempted", 1);
						SceneManager.LoadScene ("MechanicRound1");
					} else if (PlayerPrefs.GetString("TeamBLocation") == "Gift Shop") {
						PlayerPrefs.SetInt ("GiftShopAttempted", 1);
						PlayerPrefs.SetString ("GiftShopTeam", "B");
						SceneManager.LoadScene ("Gift Shop");
					} else if (PlayerPrefs.GetString("TeamBLocation") == "Diner") {
						PlayerPrefs.SetString ("DinerTeam", "B");
						Debug.Log ("DinerTeam"+PlayerPrefs.GetString("DinerTeam").ToString());
						PlayerPrefs.SetInt ("DinerAttempted", 1);
						SceneManager.LoadScene ("DinerRound1");
					}
				}
			} else if (PlayerPrefs.GetInt ("currentTurn") == 4) {
				if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderFourth").ToString () + "Team") == "A") {
					if (PlayerPrefs.GetString("TeamALocation") == "Electronics") {
						PlayerPrefs.SetString ("ElectronicsTeam", "A");
						Debug.Log ("ElectronicsTeam"+PlayerPrefs.GetString("ElectronicsTeam").ToString());
						PlayerPrefs.SetInt ("ElectronicsAttempted", 1);
						SceneManager.LoadScene ("Electronics");
					} else if (PlayerPrefs.GetString("TeamALocation") == "Mechanic") {
						PlayerPrefs.SetString ("MechanicsTeam", "A");
						PlayerPrefs.SetInt ("MechanicsAttempted", 1);
						SceneManager.LoadScene ("MechanicRound1");
					} else if (PlayerPrefs.GetString("TeamALocation") == "Gift Shop") {
						PlayerPrefs.SetInt ("GiftShopAttempted", 1);
						PlayerPrefs.SetString ("GiftShopTeam", "A");
						SceneManager.LoadScene ("Gift Shop");
					} else if (PlayerPrefs.GetString("TeamALocation") == "Diner") {
						PlayerPrefs.SetString ("DinerTeam", "A");
						Debug.Log ("DinerTeam"+PlayerPrefs.GetString("DinerTeam").ToString());
						PlayerPrefs.SetInt ("DinerAttempted", 1);
						SceneManager.LoadScene ("DinerRound1");
					}
				} else if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderFourth").ToString () + "Team") == "B") {
					if (PlayerPrefs.GetString("TeamBLocation") == "Electronics") {
						PlayerPrefs.SetString ("ElectronicsTeam", "B");
						Debug.Log ("ElectronicsTeam"+PlayerPrefs.GetString("ElectronicsTeam").ToString());
						PlayerPrefs.SetInt ("ElectronicsAttempted", 1);
						SceneManager.LoadScene ("Electronics");
					} else if (PlayerPrefs.GetString("TeamBLocation") == "Mechanic") {
						PlayerPrefs.SetString ("MechanicsTeam", "B");
						PlayerPrefs.SetInt ("MechanicsAttempted", 1);
						SceneManager.LoadScene ("MechanicRound1");
					} else if (PlayerPrefs.GetString("TeamBLocation") == "Gift Shop") {
						PlayerPrefs.SetInt ("GiftShopAttempted", 1);
						PlayerPrefs.SetString ("GiftShopTeam", "B");
						SceneManager.LoadScene ("Gift Shop");
					} else if (PlayerPrefs.GetString("TeamBLocation") == "Diner") {
						PlayerPrefs.SetString ("DinerTeam", "B");
						Debug.Log ("DinerTeam"+PlayerPrefs.GetString("DinerTeam").ToString());
						PlayerPrefs.SetInt ("DinerAttempted", 1);
						SceneManager.LoadScene ("DinerRound1");
					}
				}
			}
		}
	
	}
}

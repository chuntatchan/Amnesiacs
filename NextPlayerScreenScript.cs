using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Scene(3)


public class NextPlayerScreenScript : MonoBehaviour {

	public Text tbox;

	public Color playerRed;
	public Color playerGreen;
	public Color playerBlue;
	public Color playerYellow;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			SceneManager.LoadScene ("DebuggerSelection");
		} else if (PlayerPrefs.GetInt ("currentTurn") == 1) {
			tbox.text = "Pass the keyboard to " + "<color=#001773FF>" +PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFirst").ToString ()).ToString () + "</color>";

		} else if (PlayerPrefs.GetInt ("currentTurn") == 2) {
			tbox.text = "Pass the keyboard to " + "<color=#026D06FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderSecond").ToString ()).ToString () + "</color>";

		} else if (PlayerPrefs.GetInt ("currentTurn") == 3) {
			tbox.text = "Pass the keyboard to " + "<color=#831010FF>" +PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderThird").ToString ()).ToString () + "</color>";

		} else if (PlayerPrefs.GetInt ("currentTurn") == 4) {
			tbox.text = "Pass the keyboard to " + "<color=#927A1EFF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFourth").ToString ()).ToString () + "</color>";

		} else if (PlayerPrefs.GetInt ("currentTurn") == 5) {
			tbox.text = "Pass the keyboard to " + "<color=#001773FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFirst").ToString ()).ToString () + "</color>";

		} else if (PlayerPrefs.GetInt ("currentTurn") == 6) {
			tbox.text = "Pass the keyboard to " + "<color=#026D06FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderSecond").ToString ()).ToString () + "</color>";
		} else if (PlayerPrefs.GetInt ("currentTurn") == 7) {
			tbox.text = "Pass the keyboard to " + "<color=#831010FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderThird").ToString ()).ToString () + "</color>";
		} else if (PlayerPrefs.GetInt ("currentTurn") == 8) {
			tbox.text = "Pass the keyboard to " + "<color=#927A1EFF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFourth").ToString ()).ToString () + "</color>";
		} else if (PlayerPrefs.GetInt ("currentTurn") == 9) {
			tbox.text = "";
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (PlayerPrefs.GetInt ("currentTurn") == 1) {
				SceneManager.LoadScene ("PoliceStationRound1");
			} else if (PlayerPrefs.GetInt ("currentTurn") == 2) {
				SceneManager.LoadScene ("LibraryRound1");
			} else if (PlayerPrefs.GetInt ("currentTurn") == 3) {
				SceneManager.LoadScene ("PharmacyRound1");
			} else if (PlayerPrefs.GetInt ("currentTurn") == 4) {
				SceneManager.LoadScene ("ChurchRound1");
			} else if (PlayerPrefs.GetInt ("currentTurn") == 5) {
				SceneManager.LoadScene ("PoliceStationRound1P.2");
			} else if (PlayerPrefs.GetInt ("currentTurn") == 6) {
				SceneManager.LoadScene ("LibraryRound1P.2");
			} else if (PlayerPrefs.GetInt ("currentTurn") == 7) {
				if (PlayerPrefs.GetInt ("pills") == 1) {
					SceneManager.LoadScene ("PharmacyRound1P.2NoCab");
				} else {
					SceneManager.LoadScene ("PharmacyRound1P.2YesCab");
				}
			} else if (PlayerPrefs.GetInt ("currentTurn") == 8) {
				SceneManager.LoadScene ("ChurchRound1P.2");
			} else if (PlayerPrefs.GetInt ("currentTurn") == 9) {
				PlayerPrefs.SetInt ("currentTurn", 1);
				SceneManager.LoadScene ("CarBlurb");
			}
		} else if (Input.GetKeyDown (KeyCode.C)) {
			print ("currentTurn: " + PlayerPrefs.GetInt("currentTurn"));
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PassToMedicScript : MonoBehaviour {

	public string[] nextScene;
	public Text tbox;
	private int playerNum;

	// Use this for initialization
	void Start () {
		
		if (PlayerPrefs.GetInt("bathroomWindow") == 1 && PlayerPrefs.GetInt("kitchenWindow") == 1 && PlayerPrefs.GetInt("LivingRoomWindow") == 1 && PlayerPrefs.GetInt("MasterCurtain") == 1) {
			PlayerPrefs.SetInt ("AllWindowsClosed", 1);
		}
		playerNum = PlayerPrefs.GetInt ("medicNum");
		PlayerPrefs.SetInt ("currentTurn", playerNum);
		if (PlayerPrefs.GetInt ("currentTurn") == 1) {
			tbox.text = "Pass the keyboard to " + "<color=#709AD6FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFirst").ToString ()).ToString () + "</color>";
			PlayerPrefs.SetInt ("Loneliness", 1);
			PlayerPrefs.SetInt ("Insecurity", 0);
			PlayerPrefs.SetInt ("Depression", 0);
			PlayerPrefs.SetInt ("Anxiety", 0);
		} else if (PlayerPrefs.GetInt ("currentTurn") == 2) {
			tbox.text = "Pass the keyboard to " + "<color=#7DA374FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderSecond").ToString ()).ToString () + "</color>";
			PlayerPrefs.SetInt ("Loneliness", 0);
			PlayerPrefs.SetInt ("Insecurity", 1);
			PlayerPrefs.SetInt ("Depression", 0);
			PlayerPrefs.SetInt ("Anxiety", 0);
		} else if (PlayerPrefs.GetInt ("currentTurn") == 3) {
			tbox.text = "Pass the keyboard to " + "<color=#F04E4EFF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderThird").ToString ()).ToString () + "</color>";
			PlayerPrefs.SetInt ("Loneliness", 0);
			PlayerPrefs.SetInt ("Insecurity", 0);
			PlayerPrefs.SetInt ("Depression", 1);
			PlayerPrefs.SetInt ("Anxiety", 0);
		} else if (PlayerPrefs.GetInt ("currentTurn") == 4) {
			tbox.text = "Pass the keyboard to " + "<color=#FFE992FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFourth").ToString ()).ToString () + "</color>";
			PlayerPrefs.SetInt ("Loneliness", 0);
			PlayerPrefs.SetInt ("Insecurity", 0);
			PlayerPrefs.SetInt ("Depression", 0);
			PlayerPrefs.SetInt ("Anxiety", 1);
		} else if (PlayerPrefs.GetInt ("currentTurn") == 5) {
			PlayerPrefs.SetInt ("currentTurn", 1);
			tbox.text = "Pass the keyboard to " + "<color=#709AD6FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFirst").ToString ()).ToString () + "</color>";
			PlayerPrefs.SetInt ("Loneliness", 1);
			PlayerPrefs.SetInt ("Insecurity", 0);
			PlayerPrefs.SetInt ("Depression", 0);
			PlayerPrefs.SetInt ("Anxiety", 0);
		}

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.LoadScene (nextScene[PlayerPrefs.GetInt("currentTurn") - 1]);
		}
	}

}

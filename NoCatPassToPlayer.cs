using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NoCatPassToPlayer : MonoBehaviour {

	public string[] nextScene;
	public Text tbox;

	void Start () {
		PlayerPrefs.SetInt ("currentTurn", PlayerPrefs.GetInt ("currentTurn") + 1);
		if (PlayerPrefs.GetInt ("currentTurn") == 1) {
			tbox.text = "Pass the keyboard to " + "<color=#709AD6FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFirst").ToString ()).ToString () + "</color>";
		} else if (PlayerPrefs.GetInt ("currentTurn") == 2) {
			tbox.text = "Pass the keyboard to " + "<color=#7DA374FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderSecond").ToString ()).ToString () + "</color>";
		} else if (PlayerPrefs.GetInt ("currentTurn") == 3) {
			tbox.text = "Pass the keyboard to " + "<color=#F04E4EFF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderThird").ToString ()).ToString () + "</color>";
		} else if (PlayerPrefs.GetInt ("currentTurn") == 4) {
			tbox.text = "Pass the keyboard to " + "<color=#FFE992FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFourth").ToString ()).ToString () + "</color>";
		} else if (PlayerPrefs.GetInt ("currentTurn") == 5) {
			PlayerPrefs.SetInt ("currentTurn", 1);
			tbox.text = "Pass the keyboard to " + "<color=#709AD6FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFirst").ToString ()).ToString () + "</color>";
		}

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.LoadScene (nextScene[PlayerPrefs.GetInt("currentTurn") - 1]);
		}
	}

}

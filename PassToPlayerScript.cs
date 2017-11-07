using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PassToPlayerScript: MonoBehaviour {

	public Text tbox;
	public string nextScene;
	private int playerNum;

	// Use this for initialization
	void Start () {
		playerNum = PlayerPrefs.GetInt ("newPlayerNum");
		PlayerPrefs.SetInt ("currentTurn", playerNum);
		if (playerNum == 1) {
			tbox.text = "Pass the keyboard to " + "<color=#709AD6FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFirst").ToString ()).ToString () + "</color>";
		} else if (playerNum == 2) {
			tbox.text = "Pass the keyboard to " + "<color=#7DA374FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderSecond").ToString ()).ToString () + "</color>";
		} else if (playerNum == 3) {
			tbox.text = "Pass the keyboard to " + "<color=#F04E4EFF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderThird").ToString ()).ToString () + "</color>";
		} else if (playerNum == 4) {
			tbox.text = "Pass the keyboard to " + "<color=#FFE992FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFourth").ToString ()).ToString () + "</color>";
		} else if (playerNum == 5) {
			tbox.text = "";
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.LoadScene (nextScene);
		}
	}
}

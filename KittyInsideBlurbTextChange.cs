using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KittyInsideBlurbTextChange : MonoBehaviour {

	public int currentPlayer;
	public Text tbox;

	// Use this for initialization
	void Start () {
		if (currentPlayer == 1) {
			tbox.text = "<color=#709AD6FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFirst").ToString ()).ToString () + "'s " + "</color>" + "Thoughts";
		} else if (currentPlayer == 2) {
			tbox.text = "<color=#7DA974FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderSecond").ToString ()).ToString () + "'s " + "</color>" + "Thoughts";
		} else if (currentPlayer == 3) {
			tbox.text = "<color=#F04E4EFF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderThird").ToString ()).ToString () + "'s " + "</color>" + "Thoughts";
		} else if (currentPlayer == 4) {
			tbox.text = "<color=#FFE992FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFourth").ToString ()).ToString () + "'s " + "</color>" + "Thoughts";
		}
	}

}

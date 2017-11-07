using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterMathBlurb2ChangeText : MonoBehaviour {

	public Text tbox;

	// Use this for initialization
	void Start () {
		tbox.text = "Suddenly, " + "<color=#F04E4EFF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderThird").ToString ()).ToString () + "</color>" + " collapses on the floor. They shout in agony. You all notice how there is more blood seeping through the bandages. You all rush to help.";
	}

}

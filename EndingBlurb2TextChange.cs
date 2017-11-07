using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingBlurb2TextChange : MonoBehaviour {

	public Text tbox;

	// Use this for initialization
	void Start () {
		
		tbox.text = "You all decide to head towards the hospital. However, not everyone was sure if " + "<color=#F04E4EFF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderThird").ToString ()).ToString () + "</color>" + " could make the trip. You look for something that will solve the problem. Eventually, someone finds a wheelbarrow in a nearby shed. With everything settled, you all start the trek towards St. Arthur’s Hospital.";

	}

}

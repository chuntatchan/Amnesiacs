using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Act2TextChangeDepression : MonoBehaviour {

	public Story StoryStrings;
	public int elementChange;

	// Use this for initialization
	void Start () {
		StoryStrings.StoryLines [0].StoryText [elementChange] = "You set " + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderThird").ToString ()).ToString () + " down on the couch of the living room.";
	}

}

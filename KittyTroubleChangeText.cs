using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyTroubleChangeText : MonoBehaviour {

	public Story _story;

	// Use this for initialization
	void Start () {
		_story.StoryLines [1].StoryText [2] = "You unwrap the old cloth from " + "<color=#F04E4EFF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderThird").ToString ()).ToString () + "</color>" + "'s leg and rebandage it with the material from the first aid kit.";
		Destroy (this.gameObject.GetComponent<KittyTroubleChangeText>());
	}

}

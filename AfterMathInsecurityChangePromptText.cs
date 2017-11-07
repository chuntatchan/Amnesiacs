using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterMathInsecurityChangePromptText : MonoBehaviour {

	public Prompt[] _prompt;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < _prompt.Length; i++) {
			_prompt[i].promptOptions [0].optionString = PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFirst").ToString ()).ToString ();
			_prompt[i].promptOptions [1].optionString = PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFourth").ToString ()).ToString ();
		}
	}

}

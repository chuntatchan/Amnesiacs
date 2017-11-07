using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AfterMathPassToInsecurity : MonoBehaviour {

	public string nextScene;
	public Text tbox;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("currentTurn", 2);
		tbox.text = "Pass the keyboard to " + "<color=#7DA374FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderSecond").ToString ()).ToString () + "</color>";

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.LoadScene (nextScene);
		}
	}
}

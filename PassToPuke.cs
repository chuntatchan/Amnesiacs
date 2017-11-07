using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PassToPuke : MonoBehaviour {

	public string nextScene;
	public Text tbox;

	// Use this for initialization
	void Start () {
		tbox.text = "Pass the keyboard to " + "<color=#FFE992FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFourth").ToString ()).ToString () + "</color>";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.LoadScene (nextScene);
		}
	}
}

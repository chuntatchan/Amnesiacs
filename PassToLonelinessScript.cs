using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PassToLonelinessScript : MonoBehaviour {
	
	public Text tbox;
	public string nextScene;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("currentTurn", 1);
		tbox.text = "Pass the keyboard to " + "<color=#709AD6FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFirst").ToString ()).ToString () + "</color>";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.LoadScene (nextScene);
		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AbandonBlurbsScript : MonoBehaviour {

	public Text PlayerText;
	public int PlayerNum;


	// Use this for initialization
	void Start () {
		if (PlayerNum == 1) {
			PlayerText.text = "<color=#001773FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFirst").ToString ()).ToString () + "'s " +  "</color>" +  "Thoughts";
		} else if (PlayerNum == 2) {
			PlayerText.text = "<color=#026D06FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderSecond").ToString ()).ToString () + "'s " +  "</color>" +  "Thoughts";
		} else if (PlayerNum == 3) {
			PlayerText.text = "<color=#831010FF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderThird").ToString ()).ToString () + "'s " +  "</color>" +  "Thoughts";
		} else if (PlayerNum == 4) {
			PlayerText.text = "<color=#927A1EFF>" + PlayerPrefs.GetString ("Player " + PlayerPrefs.GetInt ("OrderFourth").ToString ()).ToString () + "'s " +  "</color>" +  "Thoughts";
		}
	}

}

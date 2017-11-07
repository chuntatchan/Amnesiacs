using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextPlayerScreenCarScript : MonoBehaviour {

	public Text tbox;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt("gasChecked") == 1 && PlayerPrefs.GetInt("tiresChecked") == 1 && PlayerPrefs.GetInt("cellChecked") == 1 && PlayerPrefs.GetInt("foodChecked") == 1 && PlayerPrefs.GetInt("Trunk") == 1) {
			PlayerPrefs.SetInt("currentTurn", 1);
			SceneManager.LoadScene ("AfterCarBlurb");
		} else if (PlayerPrefs.GetInt("currentTurn") == 1) {
			tbox.text = "Pass the keyboard to " + "<color=#001773FF>" + PlayerPrefs.GetString("Player " + PlayerPrefs.GetInt("OrderFirst").ToString()).ToString() + "</color>";
		} else if (PlayerPrefs.GetInt("currentTurn") == 2) {
			tbox.text = "Pass the keyboard to " + "<color=#026D06FF>" + PlayerPrefs.GetString("Player " + PlayerPrefs.GetInt("OrderSecond").ToString()).ToString() + "</color>";
		} else if (PlayerPrefs.GetInt("currentTurn") == 3) {
			tbox.text = "Pass the keyboard to " + "<color=#831010FF>" + PlayerPrefs.GetString("Player " + PlayerPrefs.GetInt("OrderThird").ToString()).ToString() + "</color>";
		} else if (PlayerPrefs.GetInt("currentTurn") == 4) {
			tbox.text = "Pass the keyboard to " + "<color=#927A1EFF>" + PlayerPrefs.GetString("Player " + PlayerPrefs.GetInt("OrderFourth").ToString()).ToString() + "</color>";
		} else if (PlayerPrefs.GetInt("currentTurn") == 5) {
			tbox.text = "Pass the keyboard to " + "<color=#001773FF>" + PlayerPrefs.GetString("Player " + PlayerPrefs.GetInt("OrderFirst").ToString()).ToString() + "</color>";
			PlayerPrefs.SetInt("currentTurn", 1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			print ("ReturnKeyHit");
			if (PlayerPrefs.GetInt ("gasChecked") == 1 && PlayerPrefs.GetInt ("tiresChecked") == 1 && PlayerPrefs.GetInt ("cellChecked") == 1 && PlayerPrefs.GetInt ("foodChecked") == 1 && PlayerPrefs.GetInt("Trunk") == 1) {
				
			} else if (PlayerPrefs.GetInt ("currentTurn") == 1) {
					SceneManager.LoadScene ("CarScenePD");
			} else if (PlayerPrefs.GetInt ("currentTurn") == 2) {
					SceneManager.LoadScene ("CarScene");
			} else if (PlayerPrefs.GetInt ("currentTurn") == 3) {
					SceneManager.LoadScene ("CarScene");
			} else if (PlayerPrefs.GetInt ("currentTurn") == 4) {
					SceneManager.LoadScene ("CarScene");
			} else if (PlayerPrefs.GetInt ("currentTurn") == 5) {
				PlayerPrefs.SetInt ("currentTurn", 1);
				SceneManager.LoadScene ("CarScenePD");
			}
		} else if (Input.GetKeyDown (KeyCode.C)) {
			if (PlayerPrefs.GetInt ("gasChecked") == 1) {
				print ("gasChecked");
			}
			if (PlayerPrefs.GetInt ("tiresChecked") == 1) {
				print ("tiresChecked");
			}
			if (PlayerPrefs.GetInt("cellChecked") == 1) {
				print ("cellChecked");
			}
			if (PlayerPrefs.GetInt("foodChecked") == 1) {
				print ("foodChecked");
			}
			if (PlayerPrefs.GetInt ("Trunk") == 1) {
				print ("Truck");
			}
			print (PlayerPrefs.GetInt("currentTurn"));
		}
	
	}
}

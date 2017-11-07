using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MapSimpleScript : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Project82Main.arrStoryInt == 1) {
			PlayerPrefs.SetString ("TeamALocation", "Electronics");
			Debug.Log ("TeamALoc = " + PlayerPrefs.GetString("TeamALocation"));
		} else if (Project82Main.arrStoryInt == 2) {
			PlayerPrefs.SetString ("TeamALocation", "Mechanic");
			Debug.Log ("TeamALoc = " + PlayerPrefs.GetString("TeamALocation"));
		} else if (Project82Main.arrStoryInt == 3) {
			PlayerPrefs.SetString ("TeamALocation", "Gift Shop");
			Debug.Log ("TeamALoc = " + PlayerPrefs.GetString("TeamALocation"));
		} else if (Project82Main.arrStoryInt == 4) {
			PlayerPrefs.SetString ("TeamALocation", "Diner");
			Debug.Log ("TeamALoc = " + PlayerPrefs.GetString("TeamALocation"));
		} else if (Project82Main.arrStoryInt == 5) {
			PlayerPrefs.SetString ("TeamBLocation", "Electronics");
			Debug.Log ("TeamBLoc = " + PlayerPrefs.GetString("TeamBLocation"));
		} else if (Project82Main.arrStoryInt == 6) {
			PlayerPrefs.SetString ("TeamBLocation", "Mechanic");
			Debug.Log ("TeamBLoc = " + PlayerPrefs.GetString("TeamBLocation"));
		} else if (Project82Main.arrStoryInt == 7) {
			PlayerPrefs.SetString ("TeamBLocation", "Gift Shop");
			Debug.Log ("TeamBLoc = " + PlayerPrefs.GetString("TeamBLocation"));
		} else if (Project82Main.arrStoryInt == 8) {
			PlayerPrefs.SetString ("TeamBLocation", "Diner");
			Debug.Log ("TeamBLoc = " + PlayerPrefs.GetString("TeamBLocation"));
		} else if (Project82Main.arrStoryInt == 9) {
			PlayerPrefs.SetInt("currentTurn", PlayerPrefs.GetInt("currentTurn") + 1 );
			SceneManager.LoadScene ("Act1Part3Loading");
		} 
	}
}

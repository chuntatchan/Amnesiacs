using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DebuggerLocationSelectScript : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Project82Main.arrStoryInt == 1) {
			SceneManager.LoadScene ("ChurchRound1");
		} else if (Project82Main.arrStoryInt == 2) {
			SceneManager.LoadScene ("PharmacyRound1");
		} else if (Project82Main.arrStoryInt == 3) {
			SceneManager.LoadScene ("PoliceStationRound1");
		} else if (Project82Main.arrStoryInt == 4) {
			SceneManager.LoadScene ("LibraryRound1");
		} else if (Project82Main.arrStoryInt == 5) {
			SceneManager.LoadScene ("CarScene");
		} else if (Project82Main.arrStoryInt == 6) {
			SceneManager.LoadScene ("CarScenePD");
		} else if (Project82Main.arrStoryInt == 7) {
			SceneManager.LoadScene ("DinerRound1");
		} else if (Project82Main.arrStoryInt == 8) {
			SceneManager.LoadScene ("MechanicRound1");
		} else if (Project82Main.arrStoryInt == 9) {
			SceneManager.LoadScene ("Electronics");
		} else if (Project82Main.arrStoryInt == 10) {
			SceneManager.LoadScene ("Gift Shop");
		} else if (Project82Main.arrStoryInt == 11) {
			PlayerPrefs.SetInt ("Debugging", 0);
			SceneManager.LoadScene ("MainMenu");
		} else if (Project82Main.arrStoryInt == 12) {
			PlayerPrefs.DeleteAll ();
			PlayerPrefs.SetInt ("Debugging", 1);
		} else if (Project82Main.arrStoryInt == 13) {
			SceneManager.LoadScene ("WarningBlurb");
		} else if (Project82Main.arrStoryInt == 14) {
			SceneManager.LoadScene ("FirstBlurb");
		} else if (Project82Main.arrStoryInt == 15) {
			SceneManager.LoadScene ("CarBlurb");
		} else if (Project82Main.arrStoryInt == 16) {
			SceneManager.LoadScene ("AfterCarBlurb");
		} else if (Project82Main.arrStoryInt == 17) {
			SceneManager.LoadScene ("ChurchRound1P.2");
		} else if (Project82Main.arrStoryInt == 18) {
			SceneManager.LoadScene ("LibraryRound1P.2");
		} else if (Project82Main.arrStoryInt == 19) {
			SceneManager.LoadScene ("PharmacyRound1P.2NoCab");
		} else if (Project82Main.arrStoryInt == 20) {
			SceneManager.LoadScene ("PharmacyRound1P.2YesCab");
		} else if (Project82Main.arrStoryInt == 21) {
			SceneManager.LoadScene ("PoliceStationRound1P.2");
		} else if (Project82Main.arrStoryInt == 22) {
			SceneManager.LoadScene ("EndAct1");
		} else if (Project82Main.arrStoryInt == 23) {
			SceneManager.LoadScene ("CarCrash");
		} else if (Project82Main.arrStoryInt == 24) {
			SceneManager.LoadScene ("ToBeContinuedBlurb");
		} else if (Project82Main.arrStoryInt == 25) {
			PlayerPrefs.SetInt ("currentTurn", 1);
			PlayerPrefs.SetInt ("SkipToCarCrash", 1);
			PlayerPrefs.SetString ("Player 1", "Lonely");
			PlayerPrefs.SetString ("Player 2", "Insecure");
			PlayerPrefs.SetString ("Player 3", "Depressed");
			PlayerPrefs.SetString ("Player 4", "Anxiety");
			PlayerPrefs.SetInt ("Player1Color", 1);
			PlayerPrefs.SetInt ("Player2Color", 2);
			PlayerPrefs.SetInt ("Player3Color", 3);
			PlayerPrefs.SetInt ("Player4Color", 4);
			PlayerPrefs.SetInt ("OrderFirst", 1);
			PlayerPrefs.SetInt ("OrderSecond", 2);
			PlayerPrefs.SetInt ("OrderThird", 3);
			PlayerPrefs.SetInt ("OrderFourth", 4);
			SceneManager.LoadScene ("PassToLoneliness (CarCrash)");

		} else if (Project82Main.arrStoryInt == 26) {
			PlayerPrefs.SetInt ("currentTurn", 1);
			PlayerPrefs.SetString ("Player 1", "Lonely");
			PlayerPrefs.SetString ("Player 2", "Insecure");
			PlayerPrefs.SetString ("Player 3", "Depressed");
			PlayerPrefs.SetString ("Player 4", "Anxiety");
			PlayerPrefs.SetInt ("Player1Color", 1);
			PlayerPrefs.SetInt ("Player2Color", 2);
			PlayerPrefs.SetInt ("Player3Color", 3);
			PlayerPrefs.SetInt ("Player4Color", 4);
			PlayerPrefs.SetInt ("OrderFirst", 1);
			PlayerPrefs.SetInt ("OrderSecond", 2);
			PlayerPrefs.SetInt ("OrderThird", 3);
			PlayerPrefs.SetInt ("OrderFourth", 4);
			SceneManager.LoadScene ("CabinRound1");
		}
			
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Randomizer : MonoBehaviour {

	public int[] players;
	// Location 4 = Library; Location 6 = Pharmacy; Location 7 = Police Station; Location 9 = Church;
	public string[] locations;

	public string nextScene;

	// Use this for initialization
	void Start () {

		PlayerPrefs.SetString ("Player1Loc", locations[0]);
		PlayerPrefs.SetString ("Player2Loc", locations[1]);
		PlayerPrefs.SetString ("Player3Loc", locations[2]);
		PlayerPrefs.SetString ("Player4Loc", locations[3]);

		PlayerPrefs.SetInt ("Player1Color", CharacterSelection.player1choice);
		PlayerPrefs.SetInt ("Player2Color", CharacterSelection.player2choice);
		PlayerPrefs.SetInt ("Player3Color", CharacterSelection.player3choice);
		PlayerPrefs.SetInt ("Player4Color", CharacterSelection.player4choice);

		for (int i = 1; i <= 4; i++) {
			if (PlayerPrefs.GetInt ("Player" + i + "Color") == 1) {
				PlayerPrefs.SetInt ("OrderFirst", players [i-1]);
			} else if (PlayerPrefs.GetInt ("Player" + i + "Color") == 2) {
				PlayerPrefs.SetInt ("OrderSecond", players [i-1]);
			} else if (PlayerPrefs.GetInt ("Player" + i + "Color") == 3) {
				PlayerPrefs.SetInt ("OrderThird", players [i-1]);
			} else if (PlayerPrefs.GetInt ("Player" + i + "Color") == 4) {
				PlayerPrefs.SetInt ("OrderFourth", players [i-1]);
			}
		}

		PlayerPrefs.SetInt ("currentTurn", 0);

		SceneManager.LoadScene (nextScene);
	}




	/*
	void reshuffle(int[] num) {
		// Knuth shuffle algorithm :: courtesy of Wikipedia :)
		for (int t = 0; t < num.Length; t++ ) {
			int tmp = num[t];
			int r = Random.Range(t, num.Length);
			num[t] = num[r];
			num[r] = tmp;
		}
	}
	*/
}

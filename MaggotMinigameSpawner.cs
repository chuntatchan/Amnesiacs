using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaggotMinigameSpawner : MonoBehaviour {

	public static List<string> letters = new List<string>();

	private GameObject nextOpening;
	public GameObject canvasParent;

	public GameObject openingPrefab;

	public Text scoreTbox;
	public static int score;

	void Start() {
		score = 0;

		#region Alphabetize List
		letters.Add ("A");
		letters.Add ("B");
		letters.Add ("C");
		letters.Add ("D");
		letters.Add ("E");
		letters.Add ("F");
		letters.Add ("G");
		letters.Add ("H");
		letters.Add ("I");
		letters.Add ("J");
		letters.Add ("K");
		letters.Add ("L");
		letters.Add ("M");
		letters.Add ("N");
		letters.Add ("O");
		letters.Add ("P");
		letters.Add ("Q");
		letters.Add ("R");
		letters.Add ("S");
		letters.Add ("T");
		letters.Add ("U");
		letters.Add ("V");
		letters.Add ("W");
		letters.Add ("X");
		letters.Add ("Y");
		letters.Add ("Z");
		#endregion

		Invoke ("spawnOpening", 0f);

	}

	void spawnOpening() {
		if (letters.Count != 0) {
			int newKey = Random.Range (0, letters.Count);
			//for (int i = 0; i < Random.Range (1, 3); i++) {
			nextOpening = Instantiate (openingPrefab, new Vector3 (Random.Range (-6.6f, 6.6f), Random.Range (-3.9f, 2.5f), 90), canvasParent.transform.rotation, canvasParent.transform);
			nextOpening.GetComponent<MaggotOpening> ().MaggotKey = letters [newKey];
			//}
			letters.RemoveAt (newKey);
		}
		Invoke ("spawnOpening", Random.Range(0.1f, 0.9f));
	}

	void Update() {
		scoreTbox.text = "Score: " + score;
	}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaggotOpening : MonoBehaviour {

	public string MaggotKey;
	public GameObject maggotObject;
	public Text maggotTbox;
	public Image openingImage;

	public bool canMove = false;

	public float maggotSpeed;
	public float startingHeight;

	public MaggotOpening(string key) {
		this.MaggotKey = key.ToLower();
	}

	void Start() {
		this.maggotObject.transform.localPosition = new Vector3 (0, 0, 0);
		spawnMaggot ();
	}

	void Update() {
		if (Input.GetKeyDown(MaggotKey.ToLower()) && canMove) {
			despawnMaggot ();
		}
	}

	void spawnMaggot() {
		StartCoroutine (moveToPos(new Vector3(0, startingHeight, 0), maggotSpeed, false));
	}

	void despawnMaggot() {
		openingImage.enabled = false;
		MaggotMinigameSpawner.score = MaggotMinigameSpawner.score + 1;
		StartCoroutine (moveToPos(new Vector3(0, 1500f, 0), Random.Range(0.2f, 1f), true));
	}



	private IEnumerator moveToPos (Vector3 newPos, float time, bool isDespawn) {

		this.canMove = false;

		if (isDespawn) {
			this.maggotTbox.text = "";
		}
		
		float elapsedTime = 0;
		Vector3 startingPos = maggotObject.transform.position;

		while (elapsedTime < time) {
			this.maggotObject.transform.localPosition = Vector3.Lerp(startingPos, newPos, (elapsedTime / time));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}

		if (isDespawn) {
			MaggotMinigameSpawner.letters.Add (this.MaggotKey);
			Destroy (gameObject);
		} else {
			this.canMove = true;
			this.maggotTbox.text = MaggotKey;
		}
			
	}

}

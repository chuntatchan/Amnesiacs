using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LostInForestScript : MonoBehaviour {

	public GameObject player;
	public Animator playerAnim;
	public GameObject[] directionsUI;
	public Image background;
	public ImgSegment[] maps;

	public float playerSpeed;
	private int currentSeg;
	private int currentMap;
	private bool canMove;

	public AnswerKeys[] answers;

	public GameObject alienPrefab;
	public GameObject[] alienSpawnPoints;
	private int alienNum = 0;

	public GameObject blackscreen;
	public Text blackscreenTbox;
	private float blackscreenAlpha;

	private string lastKey;
	private bool wrongAnswer;

	private bool spawnDirections;
	private bool spawnedAliens;

	public string nextScene;
	public string nextSceneNoCat;


	// Use this for initialization
	void Start () {
		
		wrongAnswer = false;
		canMove = false;
		for (int i = 0; i < directionsUI.Length; i++) {
			directionsUI [i].SetActive (false);
		}
		player.transform.localPosition = new Vector3 (0, -360f, 0);
		StartCoroutine(moveToPos(new Vector3(0,0,0) , playerSpeed));
		currentMap = 0;	
		currentSeg = 0;
		lastKey = "";
		spawnDirections = true;
		nextMapImage ();
	}

	void despawnDirectionsUI () {
		for (int i = 0; i < directionsUI.Length; i++) {
			directionsUI [i].SetActive (false);
		}
	}

	private IEnumerator moveToPos (Vector3 newPos, float time) {
		despawnDirectionsUI ();
		canMove = false;
		float elapsedTime = 0;
		Vector3 startingPos = player.transform.position;

		while (elapsedTime < time) {
			playerAnim.SetBool ("isWalking", true);
			player.transform.position = Vector3.Lerp(startingPos, newPos, (elapsedTime / time));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}

		if (wrongAnswer) {
			if (lastKey == "Up") {
				player.transform.localPosition = new Vector3 (0, -360f, 0);
			} else if (lastKey == "Down") {
				player.transform.localPosition = new Vector3 (0, 360f, 0);
			} else if (lastKey == "Left") {
				player.transform.localPosition = new Vector3 (525f, 0, 0);
			} else if (lastKey == "Right") {
				player.transform.localPosition = new Vector3 (-525, 0, 0);
			}
			nextMapImage ();
			spawnDirections = true;
			StartCoroutine(moveToPos(new Vector3(0,0,0) , playerSpeed));
		} else {
			if (spawnDirections) {
				spawnDirections = false;
				canMove = true;
				spawnDirectionsUI ();
				playerAnim.SetBool ("isWalking", false);
			} else {
				if (lastKey == "Up") {
					player.transform.localPosition = new Vector3 (0, -360f, 0);
				} else if (lastKey == "Down") {
					player.transform.localPosition = new Vector3 (0, 360f, 0);
				} else if (lastKey == "Left") {
					player.transform.localPosition = new Vector3 (525f, 0, 0);
				} else if (lastKey == "Right") {
					player.transform.localPosition = new Vector3 (-525, 0, 0);
				}
				nextMapImage ();
				spawnDirections = true;
				StartCoroutine (moveToPos (new Vector3 (0, 0, 0), playerSpeed));
			}
		}
		if (currentSeg == 3) {
			startNextScene ();
		}
	}

	void Update() {
		if (currentMap == answers [currentSeg].correctAnswer.Length) {
			print ("nextSegment");
			currentMap = 0;
			currentSeg++;
		}
		if (canMove) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				player.transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
				if (answers [currentSeg].correctAnswer [currentMap] == "Up" || answers [currentSeg].correctAnswer [currentMap] == "All") {
					currentMap = (currentMap + 1);
				} else {
					currentMap = 0;
					wrongAnswer = true;
				}
				lastKey = "Up";
				StartCoroutine (moveToPos (new Vector3 (0, 7f, 0), playerSpeed));
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				player.transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
				if (answers [currentSeg].correctAnswer [currentMap] == "Down" || answers [currentSeg].correctAnswer [currentMap] == "All") {
					currentMap = (currentMap + 1);
				} else {
					currentMap = 0;
					wrongAnswer = true;
				}
				lastKey = "Down";
				StartCoroutine (moveToPos (new Vector3 (0, -7f, 0), playerSpeed));
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				player.transform.rotation = new Quaternion (0f, 0f, 90f, 90f);
				if (answers [currentSeg].correctAnswer [currentMap] == "Right" || answers [currentSeg].correctAnswer [currentMap] == "All") {
					currentMap = (currentMap + 1);
				} else {
					currentMap = 0;
					wrongAnswer = true;
				}
				lastKey = "Right";
				StartCoroutine (moveToPos (new Vector3 (9.5f, 0, 0), playerSpeed));
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				player.transform.rotation = new Quaternion (0f, 0f, -90f, -90f);
				if (answers [currentSeg].correctAnswer [currentMap] == "Left" || answers [currentSeg].correctAnswer [currentMap] == "All") {
					currentMap = (currentMap + 1);
				} else {
					currentMap = 0;
					wrongAnswer = true;
				}
				lastKey = "Left";
				StartCoroutine (moveToPos (new Vector3 (-9.5f, 0, 0), playerSpeed));
			}
		}
	}

	void nextMapImage() {
		background.sprite = maps[currentSeg].img[currentMap];
		if (currentSeg == 1 && !wrongAnswer) {
			Instantiate (alienPrefab, alienSpawnPoints [alienNum].transform.position, alienSpawnPoints [alienNum].transform.rotation);
			alienNum++;
		} else if (currentSeg == 1 && wrongAnswer) {
			alienNum = 1;
		}
		if (wrongAnswer) {
			wrongAnswer = false;
		}
	}

	void spawnDirectionsUI () {
		for (int i = 0; i < directionsUI.Length; i++) {
			directionsUI [i].SetActive (true);
		}
		canMove = true;
	}

	void startNextScene() {
		StartCoroutine (fadeInBlackScreen());
	}

	IEnumerator fadeInBlackScreen() {
		PlayerPrefs.SetInt ("PreventReturn", 1);
		while (blackscreenAlpha < 1f) {
			blackscreenAlpha += 0.007f;
			blackscreen.GetComponent<Image> ().color = new Color (0, 0, 0, blackscreenAlpha);
			blackscreenTbox.color = new Color (1f,1f,1f,blackscreenAlpha);
			yield return new WaitForEndOfFrame ();
		}
		yield return new WaitForSeconds (2f);
		if (PlayerPrefs.GetInt ("AllWindowsClosed") == 1) {
			SceneManager.LoadScene (nextSceneNoCat);
		} else {
			SceneManager.LoadScene (nextScene);
		}
	}

}

[System.Serializable]
public class AnswerKeys {
	public string[] correctAnswer;
}

[System.Serializable]
public class ImgSegment {
	public Sprite[] img;
}

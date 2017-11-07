using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PairingUpScript : MonoBehaviour {

	public GameObject[] Player;
	public GameObject Player1BaseLeft;
	public GameObject Player1BaseRight;
	public GameObject Player2BaseLeft;
	public GameObject Player2BaseRight;
	public GameObject Player3BaseLeft;
	public GameObject Player3BaseRight;
	public GameObject Player4BaseLeft;
	public GameObject Player4BaseRight;
	public GameObject[] Player1Locs;
	public GameObject[] Player2Locs;
	public GameObject[] Player3Locs;
	public GameObject[] Player4Locs;
	private int TeamA = 0;
	private int TeamB = 0;
	private int currentoption = 3;
	private int currentplayer = 1;
	private bool activatePointers = false;


	// Use this for initialization
	void Start () {
		Player1BaseLeft.SetActive (false);
		Player1BaseRight.SetActive (false);
		Player2BaseLeft.SetActive (false);
		Player2BaseRight.SetActive (false);
		Player3BaseLeft.SetActive (false);
		Player3BaseRight.SetActive (false);
		Player4BaseLeft.SetActive (false);
		Player4BaseRight.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (currentplayer == 1) {
			if (activatePointers == false) {
				Player1BaseLeft.SetActive (true);
				Player1BaseRight.SetActive (true);
				activatePointers = true;
			}
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				Player [currentplayer - 1].transform.position = Player1Locs [0].transform.position;
				currentoption = 0;
				Player1BaseLeft.SetActive (false);
				Player1BaseRight.SetActive (true);
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				Player [currentplayer - 1].transform.position = Player1Locs [1].transform.position;
				currentoption = 1;
				Player1BaseLeft.SetActive (true);
				Player1BaseRight.SetActive (false);
			}
		} else if (currentplayer == 2) {
			if (activatePointers == false) {
				Player2BaseLeft.SetActive (true);
				Player2BaseRight.SetActive (true);
				activatePointers = true;
			}
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				Player [currentplayer - 1].transform.position = Player2Locs [0].transform.position;
				currentoption = 0;
				Player2BaseLeft.SetActive (false);
				Player2BaseRight.SetActive (true);
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				Player [currentplayer - 1].transform.position = Player2Locs [1].transform.position;
				currentoption = 1;
				Player2BaseLeft.SetActive (true);
				Player2BaseRight.SetActive (false);
			}
		} else if (currentplayer == 3) {
			if (activatePointers == false) {
				Player3BaseLeft.SetActive (true);
				Player3BaseRight.SetActive (true);
				activatePointers = true;
			}
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				if (TeamA == 2) {
					Debug.Log ("Can't go there~");
				} else {
					Player [currentplayer - 1].transform.position = Player3Locs [0].transform.position;
					currentoption = 0;
					Player3BaseLeft.SetActive (false);
					Player3BaseRight.SetActive (false);
				}
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				if (TeamB == 2) {
					Debug.Log ("Can't go there~");
				} else {
					Player [currentplayer - 1].transform.position = Player3Locs [1].transform.position;
					currentoption = 1;
					Player3BaseLeft.SetActive (false);
					Player3BaseRight.SetActive (false);
				}
			}
		} else if (currentplayer == 4) {
			if (activatePointers == false) {
				Player4BaseLeft.SetActive (true);
				Player4BaseRight.SetActive (true);
				activatePointers = true;
			}
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				if (TeamA != 2) {
					Player [currentplayer - 1].transform.position = Player4Locs [0].transform.position;	
					currentoption = 0;
					Player4BaseLeft.SetActive (false);
					Player4BaseRight.SetActive (false);
				}
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				if (TeamB != 2) {
					Player [currentplayer - 1].transform.position = Player4Locs [1].transform.position;
					currentoption = 1;
					Player4BaseLeft.SetActive (false);
					Player4BaseRight.SetActive (false);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			activatePointers = false;
			Player1BaseLeft.SetActive (false);
			Player1BaseRight.SetActive (false);
			Player2BaseLeft.SetActive (false);
			Player2BaseRight.SetActive (false);
			Player3BaseLeft.SetActive (false);
			Player3BaseRight.SetActive (false);
			Player4BaseLeft.SetActive (false);
			Player4BaseRight.SetActive (false);
			if (currentoption == 0) {
				PlayerPrefs.SetString ("Player" + currentplayer.ToString () + "Team", "A");
				currentplayer += 1;
				TeamA += 1;
			} else if (currentoption == 1) {
				PlayerPrefs.SetString ("Player" + currentplayer.ToString () + "Team", "B");
				currentplayer += 1;
				TeamB += 1;
			}
			currentoption = 3;
		}
		if (currentplayer == 5) {
			if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderFirst").ToString () + "Team") == "A") {
				PlayerPrefs.SetInt ("currentTurn", 1);
			} else if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderSecond").ToString () + "Team") == "A") {
				PlayerPrefs.SetInt ("currentTurn", 2);
			} else if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderThird").ToString () + "Team") == "A") {
				PlayerPrefs.SetInt ("currentTurn", 3);
			} else if (PlayerPrefs.GetString ("Player" + PlayerPrefs.GetInt ("OrderFourth").ToString () + "Team") == "A") {
				PlayerPrefs.SetInt ("currentTurn", 4);
			}
			SceneManager.LoadScene ("NewMapA");
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			Debug.Log (currentplayer);

		}
	}
}

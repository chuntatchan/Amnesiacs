using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PutOutOfMiseryScript : MonoBehaviour {

	public GameObject[] decisions;
	public string[] decisionNextScene;
	public GameObject blackUnderlay;
	public GameObject whiteUnderlay;
	private int decisionCount;
	private int row;

	void Start () {
		decisionCount = 0;
		blackUnderlay.transform.position = decisions [decisionCount].transform.position;
		whiteUnderlay.transform.position = decisions [decisionCount].transform.position;
		row = 1;
		decisions[0].gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("Player " + PlayerPrefs.GetInt("OrderFirst").ToString()).ToString();
		decisions[1].gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("Player " + PlayerPrefs.GetInt("OrderSecond").ToString()).ToString();
		decisions[2].gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("Player " + PlayerPrefs.GetInt("OrderThird").ToString()).ToString();
		decisions[3].gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("Player " + PlayerPrefs.GetInt("OrderFourth").ToString()).ToString();

	}

	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				decisionCount++;
				if (row == 1) {
					decisionCount = Mathf.Min (decisionCount, 1);
				} else {
					decisionCount = Mathf.Min (decisionCount, 3);
				}
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				decisionCount--;
				if (row == 1) {
					decisionCount = Mathf.Max (decisionCount, 0);
				} else {
					decisionCount = Mathf.Max (decisionCount, 2);
				}
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				if (row == 1) {
					row++;
					decisionCount += 2;
				}
			} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
				if (row == 2) {
					row--;
					decisionCount -= 2;
				}
			} else if (Input.GetKeyDown (KeyCode.Return)) {
				PlayerPrefs.SetInt ("newPlayerNum", decisionCount + 1);
				if (PlayerPrefs.GetInt ("HealFailed") == 1) {
					SceneManager.LoadScene ("DeerPanicKill");
				} else {
					SceneManager.LoadScene (decisionNextScene [decisionCount]);
				}
			} else if (Input.GetKeyDown (KeyCode.C)) {
				print (decisionCount.ToString ());
			}
			blackUnderlay.transform.position = decisions [decisionCount].transform.position;
			whiteUnderlay.transform.position = decisions [decisionCount].transform.position;
		}
	}
}

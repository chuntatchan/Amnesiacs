using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseMedicScript : MonoBehaviour {

	public Text titletbox;
	
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
		decisions[0].gameObject.GetComponent<Text>().text = "<color=#709AD6FF>" + PlayerPrefs.GetString("Player " + PlayerPrefs.GetInt("OrderFirst").ToString()).ToString() + "</color>";
		decisions[1].gameObject.GetComponent<Text>().text = "<color=#7DA374FF>" + PlayerPrefs.GetString("Player " + PlayerPrefs.GetInt("OrderSecond").ToString()).ToString() + "</color>";
		decisions[2].gameObject.GetComponent<Text>().text = "<color=#F04E4EFF>" + PlayerPrefs.GetString("Player " + PlayerPrefs.GetInt("OrderThird").ToString()).ToString() + "</color>";
		decisions[3].gameObject.GetComponent<Text>().text =  "<color=#FFE992FF>" + PlayerPrefs.GetString("Player " + PlayerPrefs.GetInt("OrderFourth").ToString()).ToString() + "</color>";

		titletbox.text = "Group Decision: \n Who is going to heal " + PlayerPrefs.GetString("Player " + PlayerPrefs.GetInt("OrderThird").ToString()).ToString() + " ?";

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

				// Next Scene
				PlayerPrefs.SetInt ("newPlayerNum", decisionCount + 1);
				PlayerPrefs.SetInt ("medicNum", decisionCount + 1);
				SceneManager.LoadScene (decisionNextScene [decisionCount]);


			} else if (Input.GetKeyDown (KeyCode.C)) {
				print (decisionCount.ToString ());
			}
			blackUnderlay.transform.position = decisions [decisionCount].transform.position;
			whiteUnderlay.transform.position = decisions [decisionCount].transform.position;
		}
	}

}

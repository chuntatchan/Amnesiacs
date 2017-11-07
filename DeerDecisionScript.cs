using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeerDecisionScript : MonoBehaviour {

	public GameObject[] decisions;
	public string[] decisionNextScene;
	public GameObject blackUnderlay;
	public GameObject whiteUnderlay;
	private int decisionCount;

	void Start () {
		decisionCount = 0;
		blackUnderlay.transform.position = decisions [decisionCount].transform.position;
		whiteUnderlay.transform.position = decisions [decisionCount].transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			decisionCount++;
			decisionCount = Mathf.Min (decisionCount, 2);
			blackUnderlay.transform.position = decisions [decisionCount].transform.position;
			whiteUnderlay.transform.position = decisions [decisionCount].transform.position;
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			decisionCount--;
			decisionCount = Mathf.Max (decisionCount, 0);
			blackUnderlay.transform.position = decisions [decisionCount].transform.position;
			whiteUnderlay.transform.position = decisions [decisionCount].transform.position;
		} else if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.LoadScene (decisionNextScene [decisionCount]);
		} else if (Input.GetKeyDown (KeyCode.C)) {
			print (decisionCount.ToString ());
		}
	}
}

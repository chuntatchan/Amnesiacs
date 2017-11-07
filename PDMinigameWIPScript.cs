using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PDMinigameWIPScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.LoadScene ("PoliceStationRound1P.2");
		}
	}
}

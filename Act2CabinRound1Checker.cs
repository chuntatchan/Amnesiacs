using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Act2CabinRound1Checker : MonoBehaviour {

	public GameObject blackscreen;
	private float alpha;
	public string nextSceneString;

	void Start() {
		alpha = 0;
	}

	void Update () {
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			if (Input.GetKeyDown(KeyCode.Escape)) {
				SceneManager.LoadScene ("DebuggerSelection");
			}
		}
		if (Project82Main.arrStoryInt == 142) {
			InvokeRepeating ("fadeInBlackScreen", 0f, 0f);
			Invoke ("nextScene", 1.5f);
		} else if (Project82Main.arrStoryInt == 1) {
			PlayerPrefs.SetInt ("CabinLivingRoom", 1);
		} else if (Project82Main.arrStoryInt == 83) {
			PlayerPrefs.SetInt ("CabinMasterBedroom", 1);
		} else if (Project82Main.arrStoryInt == 12) {
			PlayerPrefs.SetInt ("CabinBathroom", 1);
		} else if (Project82Main.arrStoryInt == 34) {
			PlayerPrefs.SetInt ("CabinKitchen", 1);
		} else if (Project82Main.arrStoryInt == 79) {
			PlayerPrefs.SetInt ("CabinDNE", 1);
		} else if (Project82Main.arrStoryInt == 75) {
			PlayerPrefs.SetInt ("CabinWhiteDoor", 1);
		} else if (Project82Main.arrStoryInt == 28) {
			PlayerPrefs.SetInt ("bathroomWindow", 1);
		} else if (Project82Main.arrStoryInt == 56) {
			PlayerPrefs.SetInt ("cabinPresent", 1);
		} else if (Project82Main.arrStoryInt == 63) {
			PlayerPrefs.SetInt ("kitchenWindow", 1);
		} else if (Project82Main.arrStoryInt == 14) {
			PlayerPrefs.SetInt ("LivingRoomWindow", 1);
		} else if (Project82Main.arrStoryInt == 108) {
			PlayerPrefs.SetInt ("MasterEvidenceBathroomTrash", 1);
		} else if (Project82Main.arrStoryInt == 127) {
			PlayerPrefs.SetInt ("EvidenceOven", 1);
		} else if (Project82Main.arrStoryInt == 136) {
			PlayerPrefs.SetInt ("MasterCurtain", 1);
		} else if (Project82Main.arrStoryInt == 110) {
			PlayerPrefs.SetInt ("sinkClogged", 1);
		}

	}

	void nextScene() {
		SceneManager.LoadScene (nextSceneString);
	}

	void fadeInBlackScreen() {
		PlayerPrefs.SetInt ("PreventReturn", 1);
		alpha += 0.02f;
		blackscreen.GetComponent<Image> ().color = new Color (0, 0, 0, alpha);
	}

}

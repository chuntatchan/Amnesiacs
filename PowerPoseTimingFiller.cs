using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PowerPoseTimingFiller : MonoBehaviour {

	public GameObject Button;
	public GameObject ButtonFlash;
	public GameObject Handler;
	public GameObject Win;
	public Image TMProgBar;
	public Image PowerBar;
	public KeyCode inputButton = KeyCode.Space;
	public float increaseAmount;
	public float fillAccel;
	public float fillSpeed;
	public float barAdd;
	private bool increase = true;

	void Start () {
		ButtonFlash.SetActive (false);
		Win.SetActive (false);
		TMProgBar.fillAmount = 0f;
	}

	void Update () {

		if (Input.GetKeyDown (inputButton)) {
			ButtonFlash.SetActive (true);
			Invoke ("ClearFlash", 0.025f);
			Invoke ("ChangeInput", 0.1f); 
			Invoke ("ResetInput", 0.5f); 
		}

		if (Input.GetKeyDown (inputButton) && PowerBar.fillAmount >= 0.8f && PowerBar.fillAmount <= 0.9f) {
			TMProgBar.fillAmount = TMProgBar.fillAmount += increaseAmount;
			Invoke ("ChangeInput", 0.1f); 
			Invoke ("ResetInput", 0.5f); 

		}

		/*if (Input.GetKeyDown (inputButton)) {
			TMProgBar.fillAmount = TMProgBar.fillAmount += PowerBar.fillAmount * barAdd;
		}*/

		if (PowerBar.fillAmount <= 1.0f && increase == true) {
			fillSpeed = fillSpeed += fillAccel;
			PowerBar.fillAmount += fillSpeed;
		}
		if (PowerBar.fillAmount >= 0.05f && increase == false) {
			fillSpeed = fillSpeed -= fillAccel;
			PowerBar.fillAmount -= fillSpeed;
		}

		if (PowerBar.fillAmount == 1.0f) {
			increase = false;
		}
		if (PowerBar.fillAmount <= 0.05f) {
			increase = true;
		}

		//win
		if (TMProgBar.fillAmount == 1.0f) {
			Handler.SetActive (false);
			Win.SetActive (true);
			Invoke ("WinConditionMet", 2f);
		}
	}

	void WinConditionMet () {
		
		PlayerPrefs.SetInt ("currentTurn", PlayerPrefs.GetInt ("currentTurn") + 1);
		if (PlayerPrefs.GetInt ("Debugging") == 1) {
			SceneManager.LoadScene ("DebuggerSelection");
		} else {
			SceneManager.LoadScene ("KittyInsideBlurb3.1");
		}
		
		print ("You Win!");

	}

	void ChangeInput () {
		inputButton = KeyCode.F;
	}

	void ResetInput () {
		inputButton = KeyCode.Space;
	}

	void ClearFlash () {
		ButtonFlash.SetActive (false);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CrutchMinigameManager : MonoBehaviour {

	public delegate void resetItems ();
	public static event resetItems itemReset;

	public GameObject confirmBox;
	public Image[] itemSlots;
	public Sprite itemStartingImage;

	public Sprite[] correctAnswer1;
	public Sprite[] correctAnswer2;

	public Text textbox;
	public string[] failText;

	public string nextScene;

	private int itemSlotCounter;

	// Use this for initialization
	void Start () {
		confirmBox.SetActive (false);
		itemSlotCounter = 0;
	}

	public void addNextItem(Sprite img) {
		if (itemSlotCounter < itemSlots.Length) {
			itemSlots [itemSlotCounter++].sprite = img;
		}
		if (itemSlotCounter == itemSlots.Length) {
			activateConfirm ();
		}
	}

	void activateConfirm() {
		confirmBox.SetActive (true);
	}

	public void yesButton() {
		checkAnswer ();
		confirmBox.SetActive (false);
	}

	public void noButton() {
		itemReset ();
		itemSlotCounter = 0;
		for (int i = 0; i < itemSlots.Length; i++) {
			itemSlots [i].sprite = itemStartingImage;
		}
		confirmBox.SetActive (false);
	}

	void checkAnswer() {
		itemReset ();
		itemSlotCounter = 0;
		int answerCounter = 0;
		if (PlayerPrefs.GetInt ("isCrutch1") != 1) {
			for (int i = 0; i < itemSlots.Length; i++) {
				if (itemSlots [i].sprite == correctAnswer1 [0] || itemSlots [i].sprite == correctAnswer1 [1] || itemSlots [i].sprite == correctAnswer1 [2]) {
					answerCounter++;
				}
			}
		}
		if (PlayerPrefs.GetInt ("isCrutch2") != 1) {
			if (answerCounter != 3) {
				answerCounter = 0;
				for (int i = 0; i < itemSlots.Length; i++) {
					if (itemSlots [i].sprite == correctAnswer2 [0] || itemSlots [i].sprite == correctAnswer2 [1] || itemSlots [i].sprite == correctAnswer2 [2]) {
						answerCounter++;
					}
				}
			}
		}

		if (answerCounter == 3) {
			print ("Got a correct answer.");
			winCondition ();
		} else if (answerCounter == 2) {
			textbox.text = failText [0];
			Invoke ("clearTextbox", 2f);
			textbox.CrossFadeAlpha (1.0f, 0.05f, false);
			for (int i = 0; i < itemSlots.Length; i++) {
				itemSlots [i].sprite = itemStartingImage;
			}
			confirmBox.SetActive (false);
		} else {
			textbox.text = failText [1];
			Invoke ("clearTextbox", 2f);
			textbox.CrossFadeAlpha (1.0f, 0.05f, false);
			for (int i = 0; i < itemSlots.Length; i++) {
				itemSlots [i].sprite = itemStartingImage;
			}
			confirmBox.SetActive (false);
		}

	}

	void clearTextbox() {
		CancelInvoke ("clearTextbox");
		textbox.CrossFadeAlpha (0.0f, 1.5f, false);
	}

	void winCondition() {
		SceneManager.LoadScene (nextScene);
	}


}

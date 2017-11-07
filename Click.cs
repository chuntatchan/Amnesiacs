using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour {

	public Text textbox;
	public string TextToDisplay;

	public Sprite itemImage;
	private bool isClicked = false;

	public CrutchMinigameManager manager;

	void OnEnable() {
		CrutchMinigameManager.itemReset += allowClick;
	}

	void Start() {
		textbox.text = "";
	}

	public void OnLeftClick() {
		if (!manager.confirmBox.activeSelf && !isClicked) {
			isClicked = true;
			manager.addNextItem (itemImage);

			textbox.CrossFadeAlpha (1.0f, 0.05f, false);
			textbox.text = "\t" + TextToDisplay;
			Invoke ("clearTextbox", 2f);
		}
	}

	void clearTextbox() {
		CancelInvoke ("clearTextbox");
		textbox.CrossFadeAlpha (0.0f, 1.5f, false);
	}

	void allowClick() {
		isClicked = false;
	}

}

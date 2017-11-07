using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MouseOver : MonoBehaviour {

	public Click item;
	public string TextToDisplay;

	public void mouseIsOver() {
		item.textbox.CrossFadeAlpha (1.0f, 0.05f, false);
		item.textbox.text = "\t" + TextToDisplay;
	}

	public void mouseNotOver() {
		CancelInvoke ("fadeOut");
		Invoke ("fadeOut", 2f);
	}

	void fadeOut() {
		item.textbox.CrossFadeAlpha (0.0f, 1.5f, false);
	}
}

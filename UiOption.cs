using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UiOption : MonoBehaviour {
	//a reference to the actual option that this UiOption corresponds to
	public string[] insecureText;
	public PromptOption option;

	private Color newRedPointer = new Color (0.94117647058f, 0.30588235294f, 0.30588235294f, 1f);
	private Color newYellowPointer = new Color (1f, 0.91372549019f, 0.5725490196f, 1f);
	private Color newGreenPointer = new Color (0.49019607843f, 0.63921568627f, 0.45490196078f, 1f);
	private Color newBluePointer = new Color (0.43921568627f, 0.60392156862f, 0.83921568627f, 1f);

	//a reference to the Text component on this object, which we can use to change the text's appearance.
	public Text text;
	private int playernum;

	// Update is called once per frame
	void Update () {
		if (this == Project82Main.currentUiOption) {
			if (PlayerPrefs.GetInt ("currentTurn") == 1 || PlayerPrefs.GetInt("currentTurn") == 5) {
				playernum = PlayerPrefs.GetInt ("Player" + PlayerPrefs.GetInt ("OrderFirst").ToString () + "Color");
			} else if (PlayerPrefs.GetInt ("currentTurn") == 2 || PlayerPrefs.GetInt("currentTurn") == 6) {
				playernum = PlayerPrefs.GetInt ("Player" + PlayerPrefs.GetInt ("OrderSecond").ToString () + "Color");
			} else if (PlayerPrefs.GetInt ("currentTurn") == 3 || PlayerPrefs.GetInt("currentTurn") == 7) {
				playernum = PlayerPrefs.GetInt ("Player" + PlayerPrefs.GetInt ("OrderThird").ToString () + "Color");
			} else if (PlayerPrefs.GetInt ("currentTurn") == 4 || PlayerPrefs.GetInt("currentTurn") == 8) {
				playernum = PlayerPrefs.GetInt ("Player" + PlayerPrefs.GetInt ("OrderFourth").ToString () + "Color");
			}
			if (playernum == 1) {
				text.color = newBluePointer;
			} else if (playernum == 2) {
				text.color = newGreenPointer;
			} else if (playernum == 3) {
				text.color = newRedPointer;
			} else if (playernum == 4) {
				text.color = newYellowPointer;
			} else {
				text.color = Color.white;
			}
			if (Project82Main.currentPrompt.useInsecure) {
				if (Project82Main.insecurityActivatedOnce == false) {
					int i = Random.Range (0, insecureText.Length - 1);
					if (insecureText [i] != null) {
						text.text += " " + insecureText [i];
					}
					Project82Main.insecurityActivatedOnce = true;
				}
			}
		}
	}
}
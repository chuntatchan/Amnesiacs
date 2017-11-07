using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtticMinigameZalgo : MonoBehaviour {

	public string[] zalgoText;
	public GameObject promptOptions;

	private int zalgoCounter = 0;
	private bool occurOnce = true;

	// Update is called once per frame
//	void Update () {
//		if (promptOptions.transform.childCount == 3) {
//			promptOptions.transform.GetChild (2).gameObject.GetComponent<Text> ().text = zalgoText [zalgoCounter++];
//			zalgoCounter = zalgoCounter % (zalgoText.Length - 1);
//		}
//	}

	IEnumerator zalgoIt() {
		while (promptOptions.transform.childCount == 3) {
			promptOptions.transform.GetChild (2).gameObject.GetComponent<Text> ().text = zalgoText [zalgoCounter++];
			zalgoCounter = zalgoCounter % (zalgoText.Length - 1);
			for (int i = 0; i < 4; i++) {
				yield return new WaitForEndOfFrame ();
			}
		}
	}

	void Update() {
		if (promptOptions.transform.childCount == 3 && occurOnce) {
			StartCoroutine (zalgoIt ());
			occurOnce = false;
		} else if (promptOptions.transform.childCount != 3) {
			occurOnce = true;
		}
	}
}

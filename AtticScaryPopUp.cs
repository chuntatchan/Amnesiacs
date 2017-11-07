using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtticScaryPopUp : MonoBehaviour {
	// 7
	private int scalingFramesLeft = 10;

	void Start() {
		Invoke ("startTheThingy", 0.2f);

	}


	IEnumerator scaleUp() {
		int startingNum = scalingFramesLeft;
		while (scalingFramesLeft > 0) {
			//3.2
			transform.localScale = Vector3.Lerp (transform.localScale, transform.localScale * 3.2f, Time.deltaTime * 10);

			float yResult = Mathf.Cos(((Mathf.PI * (startingNum - scalingFramesLeft) ) / (startingNum * 2))) * 3;
			transform.position = new Vector3 (transform.position.x, yResult, transform.position.z);

			scalingFramesLeft--;
			yield return new WaitForEndOfFrame ();
		}
	}

	void startTheThingy() {
		StartCoroutine (scaleUp());
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

	public GameObject image;
	public Text description;
	public string[] descriptions;
	public Sprite[] images;

	public GameObject rightArrow;
	public GameObject leftArrow;

	private int counter = 0;

	// Use this for initialization
	void Start () {
		counter = 0;
		image.GetComponent<Image> ().sprite = images[counter];
		description.text = descriptions [counter];
		rightArrow.SetActive(true);
		leftArrow.SetActive (false);
	}

	void Update () {
		if (Input.anyKeyDown) {
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				print ("Left" + counter.ToString ());
				counter = Mathf.Clamp (counter - 1, 0, images.Length - 1);
				changeImageCredit ();
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				print ("Right" + counter.ToString ());
				counter = Mathf.Clamp (counter + 1, 0, images.Length - 1);
				changeImageCredit ();
			} else if (Input.GetKeyDown (KeyCode.Q) && counter == images.Length - 1) {
				Application.Quit ();
			}

		}
	}

	void changeImageCredit() {
		if (counter == 0) {
			leftArrow.SetActive (false);
		} else if (counter == images.Length - 1) {
			rightArrow.SetActive (false);
		} else {
			leftArrow.SetActive(true);
			rightArrow.SetActive(true);
		}
			image.GetComponent<Image> ().sprite = images [counter];
			description.text = descriptions [counter];
	}
}
	

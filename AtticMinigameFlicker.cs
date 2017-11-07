using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AtticMinigameFlicker : MonoBehaviour {

	public GameObject blackScreen;
	public Project82Main MainScript;

	public Sprite transition1Image;
	public Sprite transition2Image;
	public Sprite transition3Image;

	public GameObject scaryPopUp;
	private GameObject scaryPopUpHolder;

	private AudioSource _audioSource;
	public AudioClip jumpScareSound;

	public GameObject[] tboxStuff;
	public GameObject backgroundImg;

	public string nextScene;

	private float alpha = 0;

	private bool isFirstTransition1 = true;
	private bool isFirstTransition2 = true;
	private bool isFirstTransition3 = true;
	private bool isFirstTransition4 = true;
	private bool isFirstTransition5 = true;

	void Start() {
		_audioSource = GameObject.Find ("Sound").GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
		if (Project82Main.arrStoryInt == 3 && isFirstTransition1) {
			startTransition ("transition1");
			isFirstTransition1 = false;
		} else if (Project82Main.arrStoryInt == 4 && isFirstTransition2) {
			startTransition ("transition1");
			for (int i = 0; i < tboxStuff.Length; i++) {
				tboxStuff [i].SetActive (false);
			}
			backgroundImg.GetComponent<RectTransform> ().offsetMin = new Vector2(0f, 10f);
			isFirstTransition2 = false;
		} else if (Project82Main.arrStoryInt == 5 && isFirstTransition3) {
			startTransition ("transition2");
			isFirstTransition3 = false;
		} else if (Project82Main.arrStoryInt == 6 && isFirstTransition4) {
			startTransition ("transition2");
			isFirstTransition4 = false;
		} else if (Project82Main.arrStoryInt == 7 && isFirstTransition5) {
			startTransition ("transition3");
			isFirstTransition5 = false;
		}
	}

	IEnumerator fadeOutScreen () {
		for (int i = 0; i < 7; i++) {
			yield return new WaitForEndOfFrame ();
		}
		PlayerPrefs.SetInt ("PreventReturn", 0);
		SceneManager.LoadScene (nextScene);
	}

	IEnumerator transition1() {
		PlayerPrefs.SetInt ("PreventReturn", 1);
		blackScreen.GetComponent<Image> ().color = new Color (1f, 1f, 1f, 1f);
		yield return new WaitForEndOfFrame ();
		yield return new WaitForEndOfFrame ();
		blackScreen.GetComponent<Image> ().color = new Color (1f, 1f, 1f, 0f);
		yield return new WaitForEndOfFrame ();
		yield return new WaitForEndOfFrame ();
		blackScreen.GetComponent<Image> ().color = new Color (1f, 1f, 1f, 1f);
		yield return new WaitForEndOfFrame ();
		yield return new WaitForEndOfFrame ();
		blackScreen.GetComponent<Image> ().color = new Color (1f, 1f, 1f, 0f);
		yield return new WaitForEndOfFrame ();
		MainScript.background.GetComponent<Image>().sprite = transition1Image;
		yield return new WaitForEndOfFrame ();
		blackScreen.GetComponent<Image> ().color = new Color (1f, 1f, 1f, 1f);
		yield return new WaitForSeconds (1f);

		print ("startFadeOut");

		while (blackScreen.GetComponent<Image> ().color.a > 0) {
			PlayerPrefs.SetInt ("PreventReturn", 1);
			alpha -= 0.01f;
			blackScreen.GetComponent<Image> ().color = new Color (1f, 1f, 1f, alpha);
			yield return new WaitForEndOfFrame ();
		}
		PlayerPrefs.SetInt ("PreventReturn", 0);
	}

	IEnumerator transition2() {
		PlayerPrefs.SetInt ("PreventReturn", 1);
		blackScreen.GetComponent<Image> ().color = new Color (1f, 1f, 1f, 1f);
		yield return new WaitForEndOfFrame ();
		yield return new WaitForEndOfFrame ();
		blackScreen.GetComponent<Image> ().color = new Color (1f, 1f, 1f, 0f);
		yield return new WaitForEndOfFrame ();
		yield return new WaitForEndOfFrame ();
		blackScreen.GetComponent<Image> ().color = new Color (1f, 1f, 1f, 1f);
		yield return new WaitForEndOfFrame ();
		yield return new WaitForEndOfFrame ();
		blackScreen.GetComponent<Image> ().color = new Color (1f, 1f, 1f, 0f);
		yield return new WaitForEndOfFrame ();
		MainScript.background.GetComponent<Image>().sprite = transition2Image;
		yield return new WaitForEndOfFrame ();
		blackScreen.GetComponent<Image> ().color = new Color (1f, 1f, 1f, 1f);
		yield return new WaitForEndOfFrame ();
		yield return new WaitForEndOfFrame ();
		blackScreen.GetComponent<Image> ().color = new Color (1f, 1f, 1f, 0f);
		yield return new WaitForSeconds (1f);

		print ("startFadeOut");

		while (blackScreen.GetComponent<Image> ().color.a > 0) {
			PlayerPrefs.SetInt ("PreventReturn", 1);
			alpha -= 0.01f;
			blackScreen.GetComponent<Image> ().color = new Color (1f, 1f, 1f, alpha);
			yield return new WaitForEndOfFrame ();
		}
		PlayerPrefs.SetInt ("PreventReturn", 0);
	}

	IEnumerator transition3() {
		
		MainScript.textbox.gameObject.SetActive (false);
		MainScript.scenePromptOptions.gameObject.SetActive (false);
		MainScript.background.GetComponent<Image>().sprite = transition3Image;
		scaryPopUpHolder = Instantiate (scaryPopUp, new Vector3 (0, 3f, 0), gameObject.transform.rotation);
		_audioSource.PlayOneShot (jumpScareSound);

		Color newColor = scaryPopUpHolder.GetComponent<SpriteRenderer> ().color;

		newColor.a = 0;
		scaryPopUpHolder.GetComponent<SpriteRenderer> ().color = newColor;
		yield return new WaitForSeconds (0.1f);
		newColor.a = 1f;
		scaryPopUpHolder.GetComponent<SpriteRenderer> ().color = newColor;
		yield return new WaitForSeconds (0.1f);
		newColor.a = 0;
		scaryPopUpHolder.GetComponent<SpriteRenderer> ().color = newColor;
		yield return new WaitForSeconds (0.1f);
		newColor.a = 1f;
		scaryPopUpHolder.GetComponent<SpriteRenderer> ().color = newColor;
		yield return new WaitForSeconds (0.1f);
		newColor.a = 0;
		scaryPopUpHolder.GetComponent<SpriteRenderer> ().color = newColor;
		yield return new WaitForSeconds (0.1f);
		newColor.a = 1f;
		scaryPopUpHolder.GetComponent<SpriteRenderer> ().color = newColor;
		yield return new WaitForSeconds (0.1f);
		newColor.a = 0;
		scaryPopUpHolder.GetComponent<SpriteRenderer> ().color = newColor;
		yield return new WaitForSeconds (0.1f);
		newColor.a = 1f;
		scaryPopUpHolder.GetComponent<SpriteRenderer> ().color = newColor;

		StartCoroutine (fadeOutScreen());

	}

	void startTransition(string currentTransition) {
		StartCoroutine (currentTransition);
	}

}

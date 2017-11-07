using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {
	public GameObject image;
	private float alpha;
	public int arrStoryInt;
	public int StoryIndex;

	void Start () {
		alpha = 1f;
	}

	// Use this for initialization
	void Update () {
		if (Project82Main.arrStoryInt == arrStoryInt && Project82Main.currentStoryIndex == StoryIndex) {
			image.SetActive (true);
			InvokeRepeating ("fadeOutWhiteScreen", 0f, 0f);
		}
	}

	void fadeOutWhiteScreen () {
		PlayerPrefs.SetInt ("PreventReturn", 1);
		alpha -= 0.01f;
		image.GetComponent<Image> ().color = new Color (1f, 1f, 1f, alpha);
		if (alpha <= 0) {
			PlayerPrefs.SetInt ("PreventReturn", 0);
			Destroy (image);
			Destroy (this);
		}
	}

}

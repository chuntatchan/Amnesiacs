using UnityEngine;
using System.Collections;

public class ChangeSpriteTest : MonoBehaviour {
	public GameObject sprite;
	public Sprite[] pictures;
	private bool scale = true;
	private int i;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.C)) {
			Debug.Log (PlayerPrefs.GetInt("currentTurn") + 1);
			sprite.GetComponent<SpriteRenderer>().sprite = pictures [i];
			if (i == 1) {
				i = 0;
			} else {
				i = 1;
			}

		} else if (Input.GetKeyDown (KeyCode.V)) {
			PlayerPrefs.SetInt ("currentTurn", 1);
			if (scale == true) {
				sprite.transform.localScale = new Vector3 (2f,2f,2f);
				scale = false;
			} else {
				sprite.transform.localScale = new Vector3 (1f,1f,1f);
				scale = true;
			}
		}
	
	}
}

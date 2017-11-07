using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {
		public AudioClip door;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
				if (Input.GetKeyDown (KeyCode.Return)) {
						AudioSource.PlayClipAtPoint (door, new Vector3 (0, 0, 0));
				}
	}
}

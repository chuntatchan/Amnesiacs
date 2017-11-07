using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftColliderThrowy : MonoBehaviour {

	public GameObject RightCollider;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer ("enemy")) {
			StabbyPlayerController.eventEndLeftThrowy ();
			Destroy (RightCollider);
			Destroy (gameObject);
			print ("endLeft");
		}
	}

}

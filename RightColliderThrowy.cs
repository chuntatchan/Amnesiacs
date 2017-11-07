using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightColliderThrowy : MonoBehaviour {

	public GameObject LeftCollider;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer ("enemy")) {
			StabbyPlayerController.eventEndRightThrowy ();
			Destroy (LeftCollider);
			Destroy (gameObject);
			print ("endRight");
		}
	}

}

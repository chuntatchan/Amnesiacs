using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteEnemiesCollider : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer ("enemy")) {
			Destroy (col.gameObject);
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowyProjectile : MonoBehaviour {

	public float speed;
	public float LingerTime;

	void Start() {
		Invoke ("Delete", LingerTime);
		gameObject.GetComponent<Rigidbody2D> ().velocity = transform.right * speed * 10;
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer("enemy")) {
			Destroy (gameObject);
		}
	}

	void Delete() {
		Destroy (gameObject);
	}

}

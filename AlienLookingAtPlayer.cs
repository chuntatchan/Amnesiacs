using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienLookingAtPlayer : MonoBehaviour {

	private GameObject target;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player");

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 diff = target.transform.position - transform.position;
		diff.Normalize();

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 270f);
	}
}

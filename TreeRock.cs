using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRock : MonoBehaviour {

	public bool canBeHit = true;
	public controler _controler;
	public PerlinShake _PerlinShake;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (_controler.life == 3) {
			canBeHit = true;
		}

	}
	void OnTriggerEnter2D(Collider2D hit){
		if ((hit.gameObject.tag == "Player") && (canBeHit == true)) {
			_controler.life -= 1;
			canBeHit = false;
			_controler.stopMoving ();
			_PerlinShake.shakeScreen ();
		}
	}
}

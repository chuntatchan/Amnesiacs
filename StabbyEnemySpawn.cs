using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabbyEnemySpawn : MonoBehaviour {

	public float enemySpeed;
	public float enemyAccel;

	public bool goRight;

	public GameObject target;
	public GameObject mCamera;

	Rigidbody2D enemyBody;

	private Vector2 moveVel;

	private bool isDead;
	private bool canMove = true;

	// Use this for initialization
	void OnEnable () {
		target = GameObject.Find ("Player");
		mCamera = GameObject.Find ("Main Camera");
		enemyBody = GetComponent<Rigidbody2D> ();
		if (target.transform.position.x > transform.position.x) {
			goRight = true;
		} else {
			goRight = false;
			gameObject.GetComponent<SpriteRenderer> ().flipX = true;
		}
		StabbyPlayerController.collideLeftThrowy += stopMove;
		StabbyPlayerController.collideRightThrowy += stopMove;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead && canMove) {
			if (goRight) {
				moveVel = enemyBody.velocity;
				moveVel.x = Mathf.Clamp (moveVel.x + enemyAccel, -enemySpeed, enemySpeed);
				enemyBody.velocity = moveVel;
			} else {
				moveVel = enemyBody.velocity;
				moveVel.x = Mathf.Clamp (moveVel.x - enemyAccel, -enemySpeed, enemySpeed);
				enemyBody.velocity = moveVel;
			}
		}
	}

	void stopMove() {
		canMove = false;
		enemyBody.velocity = Vector2.zero;
		print ("stopMoving");
		gameObject.GetComponent<Animator> ().SetBool ("stopMove", true);
	}

	void death() {
		if (!isDead) {
			isDead = true;
			enemyBody.velocity = new Vector2 (0,0);
			mCamera.GetComponent<PerlinShake> ().shakeScreen ();
			StartCoroutine (hitFreeze ());
			gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
			gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0f;
			gameObject.layer = LayerMask.NameToLayer ("Default");
			Invoke ("delete", 10f);
		}
	}

	IEnumerator hitFreeze() {
		DoSlowMotion (0f);
		yield return new WaitForSecondsRealtime (0.07f);
		DoSlowMotion (1f);
	}

	void DoSlowMotion(float slowDownFactor) {
		Time.timeScale = slowDownFactor;
		Time.fixedDeltaTime = Time.timeScale * 0.02f;
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer ("Attack")) {
			death ();
			gameObject.GetComponent<Animator> ().SetBool ("isDead", true);
		} else if (col.gameObject.layer == LayerMask.NameToLayer ("player")) {
			delete ();
		}
	}

	void delete() {
		Destroy (gameObject);
	}

}

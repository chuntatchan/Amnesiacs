using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StabbyPlayerController : MonoBehaviour {

	public delegate void stabbyCollide ();

	public static event stabbyCollide collideLeftThrowy;
	public static event stabbyCollide collideRightThrowy;

	private int ammo = 20;

	public GameObject leftProjectileSpawner;
	public GameObject rightProjectileSpawner;
	public GameObject leftEnemySpawner;
	public GameObject rightEnemySpawner;
	public GameObject projectilePrefab;
	public GameObject enemyPrefab;
	public Animator anim;

	public GameObject[] projectileFloor;

	public GameObject deathAnimation;
	public GameObject blackscreen;
	private float alpha;

	public GameObject[] directions;

	public string nextScene;
	public string nextSceneNoCat;

	private bool canShoot;
	private bool isFacingLeft;
	private bool canSpawn = true;

	public static void eventEndLeftThrowy() {
		collideLeftThrowy ();
	}

	public static void eventEndRightThrowy() {
		collideRightThrowy ();
	}

	void OnEnable() {
		collideLeftThrowy += endLeft;
		collideRightThrowy += endRight;
	}

	void OnDisable() {
		collideLeftThrowy -= endLeft;
		collideRightThrowy -= endRight;
	}

	void Start() {
		Invoke ("spawnEnemy", 1f);
		canShoot = true;
		isFacingLeft = false;
		Invoke ("deleteDirections", 1f);
	}

	void Update() {
		if (ammo > 0) {
			if (Input.GetKeyDown (KeyCode.LeftArrow) && canShoot) {
				if (!isFacingLeft) {
					gameObject.GetComponent<SpriteRenderer> ().flipX = false;
					gameObject.GetComponent<BoxCollider2D> ().offset = new Vector2 (-0.3889252f, 2.570986f);
					isFacingLeft = true;
				}
				anim.SetTrigger ("Attack");
				projectileFloor [ammo - 1].SetActive (false);
				Invoke ("attackLeft", 0.5f);
				canShoot = false;
				Invoke ("reload", 0.5f);
			} else if (Input.GetKeyDown (KeyCode.RightArrow) && canShoot) {
				if (isFacingLeft) {
					gameObject.GetComponent<SpriteRenderer> ().flipX = true;
					gameObject.GetComponent<BoxCollider2D> ().offset = new Vector2 (0.3611676f, 2.570986f);
					isFacingLeft = false;
				}
				anim.SetTrigger ("Attack");
				projectileFloor [ammo - 1].SetActive (false);
				Invoke ("attackRight", 0.5f);
				canShoot = false;
				Invoke ("reload", 0.5f);
			}
		} else {
			gameObject.GetComponent<Animator> ().SetBool ("Panic", true);
		}
	}

	public void endLeft() {
		GameObject tempAnim = Instantiate (deathAnimation, new Vector3(-0.6f,-0.94f,0), gameObject.transform.rotation);
		tempAnim.GetComponent<SpriteRenderer>().flipX = false;
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (0,0,0,0);
		StartCoroutine (fadeInBlackScreen());
		canSpawn = false;
	}

	public void endRight() {
		GameObject tempAnim = Instantiate (deathAnimation, new Vector3(0.6f,-0.94f,0), gameObject.transform.rotation);
		tempAnim.GetComponent<SpriteRenderer>().flipX = true;
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (0,0,0,0);
		StartCoroutine (fadeInBlackScreen());
		canSpawn = false;
	}

	void attackLeft() {
		GameObject tempProjectile = Instantiate (projectilePrefab, leftProjectileSpawner.transform.position, new Quaternion(leftProjectileSpawner.transform.rotation.x, leftProjectileSpawner.transform.rotation.y, leftProjectileSpawner.transform.rotation.z - 180f, leftProjectileSpawner.transform.rotation.w) );
		tempProjectile.GetComponent<SpriteRenderer> ().flipY = true;
	}

	void attackRight() {
		GameObject tempProjectile = Instantiate (projectilePrefab, rightProjectileSpawner.transform.position, rightProjectileSpawner.transform.rotation);
		tempProjectile.GetComponent<SpriteRenderer> ().flipY = false;
	}

	void reload() {
		ammo--;
		canShoot = true;
	}

	void spawnEnemy() {
		if (canSpawn) {
			int LeftvRight = Random.Range (0, 3);
			if (LeftvRight == 0) {
				Instantiate (enemyPrefab, leftEnemySpawner.transform.position, leftEnemySpawner.transform.rotation);
			} else if (LeftvRight == 1) {
				Instantiate (enemyPrefab, rightEnemySpawner.transform.position, rightEnemySpawner.transform.rotation);
			} else if (LeftvRight == 2) {
				Instantiate (enemyPrefab, leftEnemySpawner.transform.position, leftEnemySpawner.transform.rotation);
				Instantiate (enemyPrefab, rightEnemySpawner.transform.position, rightEnemySpawner.transform.rotation);
			}
			Invoke ("spawnEnemy", Random.Range (1f, 2f));
		}
	}

	IEnumerator fadeInBlackScreen() {
		while (alpha < 1f) {
			alpha += 0.01f;
			blackscreen.GetComponent<Image> ().color = new Color (0, 0, 0, alpha);
			yield return new WaitForEndOfFrame ();
		}
		if (PlayerPrefs.GetInt ("AllWindowsClosed") == 1) {
			SceneManager.LoadScene (nextSceneNoCat);
		} else {
			SceneManager.LoadScene (nextScene);
		}
	}

	void deleteDirections() {
		for (int i = 0; i < directions.Length; i++) {
			Destroy (directions [i].gameObject);
		}
	}

}

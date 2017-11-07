using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class controler : MonoBehaviour {

	public SpriteRenderer rightSpriteRendereLeft;
	public SpriteRenderer rightSpriteRendereUp;
	public SpriteRenderer rightSpriteRendereRight;
	public SpriteRenderer rightSpriteRendereDown;

	public SpriteRenderer leftSpriteRendereLeft;
	public SpriteRenderer leftSpriteRendereUp;
	public SpriteRenderer leftSpriteRendereRight;
	public SpriteRenderer leftSpriteRendereDown;


	public string leftCurrentArrow;
	public string rightCurrentArrow;

		[SerializeField]
		private string[] m_InspectorStrings;

		private string[] m_HardCodedStrings;

	public string nextSceneString;
	public string nextSceneStringNoCat;

	public GameObject blackscreen;
	public Text blackscreenTbox;
	private float blackscreenAlpha;

		void Awake()
		{
			m_HardCodedStrings = new string[]
			{
				"String Zero",
				"String One",
				"String Two",
				"String Three",
				"String Four",
			};
		}

		public string GetRandomInspectorString()
		{
		 	return m_InspectorStrings[Random.Range(0, m_InspectorStrings.Length)];
		}

		public string GetRandomHardCodedString()
		{
			return m_HardCodedStrings[Random.Range(0, m_HardCodedStrings.Length)];
		}


	public float moveDis = 5f;
	public Transform myTrans;
	public Rigidbody2D myBody;
	public int lane = 2;
	public float moveUp = 0.8f;
	public Vector3 startingPosition;
	public bool isNotStopped = true;

	public int life;
	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D>();
		gameObject.GetComponent<Animator> ().SetBool ("isWalking", true);
		startingPosition = myTrans.position;
		Invoke ("changeSpeed", 12f);
		Invoke ("changeSpeed2", 19f);
		afterPlayerMoves ();
		blackscreenAlpha = 0;
	}

	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown (KeyCode.LeftArrow)) && (leftCurrentArrow == "LeftArrow") && (lane != 1) && (isNotStopped == true)) {
			myTrans.position = new Vector2 (myTrans.position.x -4, myTrans.position.y);
			lane -= 1;
			afterPlayerMoves ();
		}
		else if ((Input.GetKeyDown (KeyCode.UpArrow)) && (leftCurrentArrow == "UpArrow") && (lane != 1) && (isNotStopped == true)) {
			myTrans.position = new Vector2 (myTrans.position.x -4, myTrans.position.y);
			lane -= 1;
			afterPlayerMoves ();
		}
		else if ((Input.GetKeyDown (KeyCode.RightArrow)) && (leftCurrentArrow == "RightArrow") && (lane != 1) && (isNotStopped == true)) {
			myTrans.position = new Vector2 (myTrans.position.x -4, myTrans.position.y);
			lane -= 1;
			afterPlayerMoves ();
		}
		else if ((Input.GetKeyDown (KeyCode.DownArrow)) && (leftCurrentArrow == "DownArrow") && (lane != 1) && (isNotStopped == true)) {
			myTrans.position = new Vector2 (myTrans.position.x -4, myTrans.position.y);
			lane -= 1;
			afterPlayerMoves ();
		}



		else if ((Input.GetKeyDown (KeyCode.LeftArrow)) && (rightCurrentArrow == "LeftArrow") && (lane != 3) && (isNotStopped == true)) {
			myTrans.position = new Vector2 (myTrans.position.x +4, myTrans.position.y);
			lane += 1;
			afterPlayerMoves ();
		}
		else if ((Input.GetKeyDown (KeyCode.UpArrow)) && (rightCurrentArrow == "UpArrow") && (lane != 3) && (isNotStopped == true)) {
			myTrans.position = new Vector2 (myTrans.position.x +4, myTrans.position.y);
			lane += 1;
			afterPlayerMoves ();
		}
		else if ((Input.GetKeyDown (KeyCode.RightArrow)) && (rightCurrentArrow == "RightArrow") && (lane != 3) && (isNotStopped == true)) {
			myTrans.position = new Vector2 (myTrans.position.x +4, myTrans.position.y);
			lane += 1;
			afterPlayerMoves ();
		}
		else if ((Input.GetKeyDown (KeyCode.DownArrow)) && (rightCurrentArrow == "DownArrow") && (lane != 3) && (isNotStopped == true)) {
			myTrans.position = new Vector2 (myTrans.position.x +4, myTrans.position.y);
			lane += 1;
			afterPlayerMoves ();
		}

		if (life == 0) {
			nextScene ();
		}
	}
	public void afterPlayerMoves () {
		leftCurrentArrow = GetRandomInspectorString();
		rightCurrentArrow = GetRandomInspectorString();
		while (leftCurrentArrow == rightCurrentArrow) {
			afterPlayerMoves ();
		}
		if(leftCurrentArrow == "LeftArrow"){
			leftSpriteRendereLeft.enabled = true;
			leftSpriteRendereUp.enabled = false;
			leftSpriteRendereRight.enabled = false;
			leftSpriteRendereDown.enabled = false;
		}
		else if (leftCurrentArrow == "UpArrow"){
			leftSpriteRendereLeft.enabled = false;
			leftSpriteRendereUp.enabled = true;
			leftSpriteRendereRight.enabled = false;
			leftSpriteRendereDown.enabled = false;
		}
		else if (leftCurrentArrow == "RightArrow"){
			leftSpriteRendereLeft.enabled = false;
			leftSpriteRendereUp.enabled = false;
			leftSpriteRendereRight.enabled = true;
			leftSpriteRendereDown.enabled = false;
		}
		else if (leftCurrentArrow == "DownArrow"){
			leftSpriteRendereLeft.enabled = false;
			leftSpriteRendereUp.enabled = false;
			leftSpriteRendereRight.enabled = false;
			leftSpriteRendereDown.enabled = true;
		}

		if(rightCurrentArrow == "LeftArrow"){
			rightSpriteRendereLeft.enabled = true;
			rightSpriteRendereUp.enabled = false;
			rightSpriteRendereRight.enabled = false;
			rightSpriteRendereDown.enabled = false;
		}
		else if (rightCurrentArrow == "UpArrow"){
			rightSpriteRendereLeft.enabled = false;
			rightSpriteRendereUp.enabled = true;
			rightSpriteRendereRight.enabled = false;
			rightSpriteRendereDown.enabled = false;
		}
		else if (rightCurrentArrow == "RightArrow"){
			rightSpriteRendereLeft.enabled = false;
			rightSpriteRendereUp.enabled = false;
			rightSpriteRendereRight.enabled = true;
			rightSpriteRendereDown.enabled = false;
		}
		else if (rightCurrentArrow == "DownArrow"){
			rightSpriteRendereLeft.enabled = false;
			rightSpriteRendereUp.enabled = false;
			rightSpriteRendereRight.enabled = false;
			rightSpriteRendereDown.enabled = true;
		}


		if (lane == 3){
			rightSpriteRendereLeft.enabled = false;
			rightSpriteRendereUp.enabled = false;
			rightSpriteRendereRight.enabled = false;
			rightSpriteRendereDown.enabled = false;
		}
		if (lane == 1){
			leftSpriteRendereLeft.enabled = false;
			leftSpriteRendereUp.enabled = false;
			leftSpriteRendereRight.enabled = false;
			leftSpriteRendereDown.enabled = false;
		}
	}
	void FixedUpdate () {

		if(isNotStopped == true) {
		myTrans.position = new Vector2 (myTrans.position.x, myTrans.position.y +moveUp);
		}
	}
	public void changeSpeed () {
		moveUp = 0.15f;
	}
	public void changeSpeed2 () {
		moveUp = 0.2f;
	}
	public void startMoving (){
		isNotStopped = true;
	}
	public void stopMoving (){
		isNotStopped = false;
		Invoke ("startMoving", 0.7f);
	}

	void nextScene() {
		StartCoroutine (fadeInBlackScreen());
	}

	IEnumerator fadeInBlackScreen() {
		PlayerPrefs.SetInt ("PreventReturn", 1);
		while (blackscreenAlpha < 1f) {
			blackscreenAlpha += 0.007f;
			blackscreen.GetComponent<Image> ().color = new Color (0, 0, 0, blackscreenAlpha);
			blackscreenTbox.color = new Color (1f,1f,1f,blackscreenAlpha);
			yield return new WaitForEndOfFrame ();
		}
		yield return new WaitForSeconds (2f);
		if (PlayerPrefs.GetInt ("AllWindowsClosed") == 1) {
			SceneManager.LoadScene (nextSceneStringNoCat);
		} else {
			SceneManager.LoadScene (nextSceneString);
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camraMove : MonoBehaviour {

	public Transform myTrans;
	public float moveUp;
	public int DistanceAway = 10;
	public float distance;

	public float playerStart;

	// Use this for initialization
	void Start () {
		playerStart = myTrans.GetComponent<controler> ().myTrans.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 PlayerPOS = GameObject.Find("Player").transform.transform.position;
		GameObject.Find("Main Camera").transform.position = new Vector3(playerStart, PlayerPOS.y + 3.5f, PlayerPOS.z - DistanceAway);

	}
	void FixedUpdate () {
		//myTrans.position = new Vector2 (myTrans.position.x, myTrans.position.y +moveUp);

	}
}

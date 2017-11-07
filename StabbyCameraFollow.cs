using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabbyCameraFollow : MonoBehaviour {

	public GameObject player;
	public bool smoothFollow = true;

	public float smoothTimeX;
	public float smoothTimeY;

	public float YOffset;

	private Vector2 velocity;

	// Update is called once per frame
	void FixedUpdate () {
		if (player) {
			Vector3 newPos = transform.position;

			newPos.x = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
			newPos.y = Mathf.SmoothDamp (transform.position.y, player.transform.position.y + YOffset, ref velocity.y, smoothTimeY);

			if (smoothFollow) {
				transform.position = newPos;
			} else {
				transform.position = player.transform.position;
			}

		}
	}
}

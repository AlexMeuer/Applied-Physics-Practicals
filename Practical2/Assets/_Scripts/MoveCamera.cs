using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
	
	public float speed = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float xMove = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		float yMove = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		transform.Translate(xMove, 0, yMove);
	}
}

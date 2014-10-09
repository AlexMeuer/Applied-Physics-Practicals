using UnityEngine;
using System.Collections;

public class playerControls : MonoBehaviour {
	
	Vector2 mouseStartPos, mousePos;
	float  rotationZ, rotationX;	//no rotationY because we're never changing it

	// Use this for initialization
	void Start () {
		//Screen.lockCursor = true;
		 mouseStartPos = Input.mousePosition;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//keep the plane in the correct position (freezing location in unity doesnt always work)
		rigidbody.position = Vector3.zero;
		
		//get current mouse position
		mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		
		//divide by a large number to decrease sensitivy (we don't want one pixel rotating 1 radian!)
		rotationZ = (mouseStartPos.x - mousePos.x) / 1000f;
		rotationX = (mousePos.y - mouseStartPos.y) / 1000f;
		
		//only allow 45 degrees rotation in each direction
		rotationZ = Mathf.Clamp(rotationZ,-0.3f,0.3f);
		rotationX = Mathf.Clamp(rotationX,-0.3f,0.3f);
		
		//assign new rotation to rigibody
		rigidbody.rotation = new Quaternion(rotationX, 0f, rotationZ, 1f);
	}
}

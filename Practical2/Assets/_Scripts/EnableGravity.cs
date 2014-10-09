using UnityEngine;
using System.Collections;

public class EnableGravity : MonoBehaviour {
	
	float fallTime;
	float estimatedFallTime;
	float finalVelocity;
	const float GravitationalConstant = 9.81f;
	
	// Use this for initialization
	void Start () {
		estimatedFallTime = Mathf.Sqrt ((2 * gameObject.rigidbody.position.y) / GravitationalConstant);
		finalVelocity = Mathf.Sqrt(2 * GravitationalConstant * gameObject.rigidbody.position.y);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.Space)){
			fallTime = 0;
			gameObject.rigidbody.useGravity = true;
			}
		if(GetComponent<Rigidbody>().velocity.y != 0){
			fallTime += Time.deltaTime;
		}
	}
	
	void OnGUI(){
		GUI.Label(new Rect(10,10,250,20),"Height Box = " + (gameObject.rigidbody.position.y).ToString());
		GUI.Label(new Rect(10,25,250,20),"Time falling = " + fallTime.ToString());
		GUI.Label(new Rect(10,40,250,20),"Estimated time falling = " + estimatedFallTime.ToString());
		GUI.Label(new Rect(10,55,250,20),"Final Velocity = " + finalVelocity);
	}
}

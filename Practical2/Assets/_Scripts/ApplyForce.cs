using UnityEngine;
using System.Collections;

public class ApplyForce : MonoBehaviour {
	
	
	/* u = force * time
	 * v = u + at
	 * µg = friction * gravity
	 * v^2 = u^2 + 2as
	 * t = (v-u)/a
	 */
	
	//µg = friction * gravity
	const float Acceleration = -0.05f * 9.81f;

	Vector3 xForce, startPosition;
	bool forceApplied;	//force should be impulse so we use a boolean to prevent force being applied more than once
	float initialVelocity, finalVelocity, estDisplacement, xDisplacement, timeMoving, estTimeMoving;
	
	// Use this for initialization
	void Start () {
		xForce = new Vector3(100f,0f,0f);
		startPosition = rigidbody.position;
		
		//initialize all to zero
		initialVelocity = finalVelocity = estDisplacement= xDisplacement = timeMoving = estTimeMoving = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		#region Input
		if(Input.GetKey(KeyCode.X) && !forceApplied)
		{
			//applies xForce to the gameObject, gets initial velocity and estimated final velocity
			Apply_xForce();
		}
		/*else if(Input.GetKey(KeyCode.Z))
		{
			gameObject.rigidbody.AddForce(-xForce);
		}*/
		
		//increase/decrease force
		if(Input.GetKey(KeyCode.F))
		{
			xForce.x += 2;
		}
		else if(Input.GetKey(KeyCode.G))
		{
			xForce.x -= 2;
		}
		
		//increase/decrease mass
		if(Input.GetKey(KeyCode.M))
		{
			gameObject.rigidbody.mass += 0.1f;
		}
		else if(Input.GetKey(KeyCode.N))
		{
			gameObject.rigidbody.mass -= 0.1f;
		}
		#endregion
		
		//update time taken moving
		if(rigidbody.velocity.x != 0)
			timeMoving += Time.deltaTime;
		
		//update displacement
		xDisplacement = rigidbody.position.x - startPosition.x;
	}
	
	void Apply_xForce()
	{
		//apply a Vector3 force
		gameObject.rigidbody.AddForce(xForce);
			
		//calculate initial velocity
		initialVelocity = xForce.x * Time.deltaTime;
		
		//estimate displacement
		estDisplacement = -((Mathf.Pow(initialVelocity, 2f)) / (2 * Acceleration));
			
		//reset time
		timeMoving = 0f;
		
		//estimate time moving
		estTimeMoving = (finalVelocity - initialVelocity) / Acceleration;
			
		//disable additional forcees being added
		forceApplied = true;
	}
	
	//output to screen
	void OnGUI(){
		GUI.Label(new Rect(10, 200, 250, 20), "Force = " + xForce);
		GUI.Label(new Rect(10, 215, 250, 20), "Mass = " + gameObject.rigidbody.mass);
		GUI.Label(new Rect(10, 230, 250, 20), "Initial Velocity = " + initialVelocity);
		GUI.Label(new Rect(10, 245, 250, 20), "Final Velocity = " + finalVelocity);
		GUI.Label(new Rect(10, 260, 250, 20), "Estimated Displacement = " + estDisplacement);
		GUI.Label(new Rect(10, 275, 250, 20), "Actual Displacement = " + xDisplacement);
		GUI.Label(new Rect(10, 290, 250, 20), "Time Moving = " + timeMoving);
		GUI.Label(new Rect(10, 305, 250, 20), "Estimated Time Moving = " + estTimeMoving);
	}
}

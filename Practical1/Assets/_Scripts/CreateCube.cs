using UnityEngine;
using System.Collections;

public class CreateCube : MonoBehaviour {
	
	public UnityEngine.Object newObject;
	public Vector3 cubePosition;

	// Use this for initialization
	void Start () {
		cubePosition = new Vector3(0,3.0f,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Instantiate(newObject, cubePosition, Quaternion.identity);
		}
	}
}
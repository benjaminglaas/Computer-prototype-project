using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float speed = 10.0f;
	float angle = 180.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.D)) {
			print ("D key was pressed");
			transform.RotateAround (Vector3.zero, new Vector3 (1,1,0),angle);
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			print ("A key was pressed");
			transform.RotateAround (Vector3.zero, new Vector3 (1,1,0),-angle);		
		}
	}
}

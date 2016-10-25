using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float speed = 10.0f;
	public float smooth = 1f;


	float angle = 90.0f;
	int orientation = 0;
	Vector3[] gravityDirectionList = new Vector3[4]{new Vector3 (0, -1, 0),new Vector3(1,0,0),new Vector3(0,1,0),new Vector3(-1,0,1)}; 
	Quaternion targetRotation; 
	Vector3 gravityDirection;



	// Use this for initialization
	//Vector3 gravityDirection;
	void Start () {
		targetRotation = transform.rotation;
		gravityDirection = gravityDirectionList [0];
		Physics.gravity = gravityDirection;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.D)) {
			if (orientation >= 3) {
				orientation = 0;
			}
			else{
			orientation += 1;
			};
			targetRotation *= Quaternion.AngleAxis(angle, new Vector3 (0, 0, 1));
			gravityDirection = gravityDirectionList [orientation];
			Physics.gravity = gravityDirection;
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			if (orientation <= 0) {
				orientation = 3;
			}
			else{
				orientation -= 1;
			};
			targetRotation *= Quaternion.AngleAxis(-angle, new Vector3 (0, 0, 1));
			gravityDirection = gravityDirectionList [orientation];
			Physics.gravity = gravityDirection;
		}
		transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
	}
}

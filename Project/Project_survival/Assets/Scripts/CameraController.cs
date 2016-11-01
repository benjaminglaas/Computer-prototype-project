using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float speed = 10.0f;
	public float smooth = 1f;


	float angle = 90.0f;
	int orientation = 0;
	Vector2[] gravityDirectionList = new Vector2[4]{new Vector2(0, -1),new Vector2(1,0),new Vector2(0,1),new Vector2(-1,0)}; 
	Quaternion targetRotation; 
	public static Vector2 gravityDirection;



	// Use this for initialization
	//Vector3 gravityDirection;
	void Start () {
		targetRotation = transform.rotation;
		gravityDirection = gravityDirectionList [orientation];
		Physics2D.gravity = gravityDirection;
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
			Physics2D.gravity = gravityDirection;
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
			Physics2D.gravity = gravityDirection;
		}
		transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
	}
}

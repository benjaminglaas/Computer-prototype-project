using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float speed = 10.0f;
	public float smooth = 1f;

	float angle = 90.0f;
	float turnTimer;
	int orientation = 0;
	bool canTurn;
	Vector2[] gravityDirectionList = new Vector2[4]{new Vector2(0, -1),new Vector2(1,0),new Vector2(0,1),new Vector2(-1,0)}; 
	Quaternion targetRotation; 
	[HideInInspector] public static Vector2 gravityDirection;

	// Use this for initialization
	void Start () {
		targetRotation = transform.rotation;
		gravityDirection = gravityDirectionList [orientation];
		Physics2D.gravity = gravityDirection;
		canTurn = true;
	}
	
	// Update is called once per frame
	void Update () {

		turnTimer -= Time.deltaTime;
		if (turnTimer <= 0.0f){
			canTurn = true;
			turnTimer = 2.0f;
		}

		if (Input.GetKeyDown (KeyCode.D) && canTurn) {
			if (orientation >= 3) {
				orientation = 0;
			}
			else{
			orientation += 1;
			};
			targetRotation *= Quaternion.AngleAxis(angle, new Vector3 (0, 0, 1));
			gravityDirection = gravityDirectionList [orientation];
			Physics2D.gravity = gravityDirection;
			canTurn = false;
		}
		if (Input.GetKeyDown (KeyCode.A) && canTurn) {
			if (orientation <= 0) {
				orientation = 3;
			}
			else{
				orientation -= 1;
			};
			targetRotation *= Quaternion.AngleAxis(-angle, new Vector3 (0, 0, 1));
			gravityDirection = gravityDirectionList [orientation];
			Physics2D.gravity = gravityDirection;
			canTurn = false;
		}
		transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
	}
}

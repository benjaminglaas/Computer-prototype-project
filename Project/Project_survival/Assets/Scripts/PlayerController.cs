using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10.0f;
	public float smooth = 1f;
	public Rigidbody rb;

	float angle = 90.0f;
	bool onGround = false;
	Quaternion targetRotation; 
	// Use this for initialization
	void Start () {
		targetRotation = transform.rotation;
		rb = GetComponent<Rigidbody> (); 
	}

	// Update is called once per frame
	void Update () {
		if (onGround) {
			rb.useGravity = false;
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			targetRotation *= Quaternion.AngleAxis(angle, new Vector3 (0, 0, 1));
			rb.velocity = Vector3.zero;

		}
		if (Input.GetKeyDown (KeyCode.A)) {
			targetRotation *= Quaternion.AngleAxis(-angle, new Vector3 (0, 0, 1));
			rb.velocity = Vector3.zero;

		}
		transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		print ("Collision");
		rb.velocity = Vector3.zero;
		onGround = true;
		}

	void Jump(){
		onGround = false;
	}
	}

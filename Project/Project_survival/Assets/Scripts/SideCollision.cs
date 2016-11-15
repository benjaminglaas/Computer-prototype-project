using UnityEngine;
using System.Collections;

public class SideCollision : MonoBehaviour {


	Rigidbody2D rb;
	float gravityScale;
	GameObject player;
	Vector3[] directionJumpList;

	// Use this for initialization
	void Start () {
		
		gravityScale = PlayerController.gravityScale;
		player = GameObject.FindGameObjectWithTag ("Player");
		rb = player.GetComponent<Rigidbody2D>(); 
		rb.gravityScale = gravityScale;
		directionJumpList = PlayerController.directionJumpList;

	}



    void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Ground") {	
			//PlayerController.jumping = true;
			rb.gravityScale = gravityScale;
			rb.AddForce (-directionJumpList [PlayerController.orientationPlayer] * Time.deltaTime);
		}

	}
	void OnTriggerStay2D(Collider2D other){
		
		if (other.gameObject.tag == "Ground") {	
			//PlayerController.jumping = true;
			rb.AddForce (-directionJumpList [PlayerController.orientationPlayer] * Time.deltaTime);

		}
	}

	void OnTriggerExit2D(Collider2D other){
		
		if (other.gameObject.tag == "Ground") {
			//PlayerController.jumping = true;
			rb.gravityScale = gravityScale;
			rb.AddForce (-directionJumpList [PlayerController.orientationPlayer] * Time.deltaTime);
		}
	}	

	void FixedUpdate(){
	}
}

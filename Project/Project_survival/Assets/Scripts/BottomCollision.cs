using UnityEngine;
using System.Collections;

public class BottomCollision : MonoBehaviour {

	Rigidbody2D rb;
	float gravityScale;
	GameObject player;

	// Use this for initialization
	void Start () {
		
		gravityScale = PlayerController.gravityScale;
		player = GameObject.FindGameObjectWithTag ("Player");
		rb = player.GetComponent<Rigidbody2D>(); 
		rb.gravityScale = gravityScale;
	}

	void OnTriggerEnter2D(Collider2D other){
		
		if (other.gameObject.tag == "Ground") {	
			PlayerController.jumping = false;
			rb.gravityScale = 0.0f;
			rb.velocity = Vector3.zero;
		}

	}
	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Ground") {	
			PlayerController.jumping = false;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Ground") {
			PlayerController.jumping = true;
			rb.gravityScale = gravityScale;
		}
	}	
}

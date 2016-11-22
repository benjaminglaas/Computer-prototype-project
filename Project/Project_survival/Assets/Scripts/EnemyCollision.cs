using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		print (other.gameObject);
		if (other.tag == "Player") {
			PlayerController.dead = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Boundary") {
			Destroy(gameObject);
		}
	}
}

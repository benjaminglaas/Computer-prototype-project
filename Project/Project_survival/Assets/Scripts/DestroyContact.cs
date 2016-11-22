using UnityEngine;
using System.Collections;

public class DestroyContact : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D other)
    {
		print ("Collision with boundary");
		if (other.tag == "Boundary") {
			return;
		}
        
    }
}

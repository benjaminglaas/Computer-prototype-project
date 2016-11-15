// http://wiki.unity3d.com/index.php?title=DontGoThroughThings
using UnityEngine;
using System.Collections;
 
public class DontGoThroughThings : MonoBehaviour 
{
	public LayerMask layerMask; //make sure we aren't in this layer 
	public float skinWidth = 0.1f; //probably doesn't need to be changed 
 
	private float minimumExtent; 
	private float partialExtent; 
	private float sqrMinimumExtent; 
	private Vector2 previousPosition; 
	private Rigidbody2D myRigidbody;  
 
	//initialize values 
	void Awake() 
	{ 
		myRigidbody = GetComponent<Rigidbody2D>(); 
	   	previousPosition = myRigidbody.position; 
	   //minimumExtent = Mathf.Min(Mathf.Min(collider.bounds.extents.x, collider.bounds.extents.y), collider.bounds.extents.z); 
		minimumExtent = Mathf.Min(Mathf.Min(GetComponent<Collider>().bounds.extents.x, GetComponent<Collider>().bounds.extents.y), GetComponent<Collider>().bounds.extents.y); 

	   partialExtent = minimumExtent * (1.0f - skinWidth); 
	   sqrMinimumExtent = minimumExtent * minimumExtent; 
	} 
 
	void FixedUpdate() 
	{ 
	   //have we moved more than our minimum extent? 
	   Vector2 movementThisStep = myRigidbody.position - previousPosition; 
	   float movementSqrMagnitude = movementThisStep.sqrMagnitude;
 
	   if (movementSqrMagnitude > sqrMinimumExtent) 
		{ 
	      float movementMagnitude = Mathf.Sqrt(movementSqrMagnitude);
	      //check for obstructions we might have missed 
			RaycastHit2D hit = Physics2D.Raycast (previousPosition, movementThisStep, movementMagnitude, layerMask.value);
			if (hit.collider!= null){
				myRigidbody.position = hit.point - (movementThisStep/movementMagnitude)*partialExtent; 
	   } 
 
	   previousPosition = myRigidbody.position; 
	}
}
}
using UnityEngine;
using System.Collections;

public class EnemyFollowController : MonoBehaviour {

	public float moveSpeed = 4.0f;
	Transform target;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		transform.position = Vector2.MoveTowards (transform.position, target.position, moveSpeed * Time.deltaTime);
	}
}

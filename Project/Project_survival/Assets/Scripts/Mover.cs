using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb;

    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		if (PlayerController.orientationPlayer == 0)
		{
			rb.velocity -= Vector2.up * speed;
		}
		else if (PlayerController.orientationPlayer == 1)
		{
			rb.velocity -= Vector2.left * speed;
		}
		else if (PlayerController.orientationPlayer == 2)
		{
			rb.velocity -= Vector2.down * speed;
		}
		else if (PlayerController.orientationPlayer == 3)
		{
			rb.velocity -= Vector2.right * speed;
		}

    }

}

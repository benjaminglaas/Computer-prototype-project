using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float jumpSpeed = 10.0f;
	public float moveForce = 365.0f;
	public float maxSpeed = 5.0f;

	public Text scoreText;
	public Text deadText;
	public Text restartText;

	public GameObject blocks;

	[HideInInspector] public static Rigidbody2D rb;
	[HideInInspector] public static float gravityScale = 15.0f;
	[HideInInspector] public static bool grounded;
	[HideInInspector] public static bool canTurn;
	[HideInInspector] public static Vector3[] directionJumpList = new Vector3[4]{new Vector3(0,1,0),new Vector3(-1,0,0),new Vector3(0,-1,0),new Vector3(1,0,0)}; 
	[HideInInspector] public static int orientationPlayer;

	float smooth = 1.0f;
	float moveSpeed = 2.0f;
	float angle = 90.0f;
	float turnTimer;
	float score;
	bool jump;
	Transform groundCheck;

	Vector3[] directionPlayerList = new Vector3[4]{new Vector3(1,0,0),new Vector3(0,1,0),new Vector3(-1,0,0),new Vector3(0,-1,0)}; 
	Quaternion targetRotation; 
	public static bool dead;
	bool outOfBounds;

	// Use this for initialization
	void Start () {
		groundCheck = transform.Find ("groundCheck");
		targetRotation = transform.rotation;
		rb = GetComponent<Rigidbody2D> (); 
		rb.gravityScale = gravityScale;
		Time.timeScale = 1;
		deadText.enabled = false;
		restartText.enabled = false;
		blocks.SetActive (true);
		dead = false;
		orientationPlayer = 0;
		turnTimer = 2.0f;
		canTurn = true;
		grounded = false;
		outOfBounds = false;
	}

	// Update is called once per frame
	void Update () {
		score = Time.timeSinceLevelLoad * 10;
		if (score < 10) {
			scoreText.text = string.Format ("Score: {0:0}", Time.timeSinceLevelLoad * 10); 
		} else {
			scoreText.text = string.Format ("Score: {0:00}", Time.timeSinceLevelLoad * 10);

		}
		turnTimer -= Time.deltaTime;
		if (turnTimer <= 0.0f){
			canTurn = true;
			turnTimer = 2.0f;
		}
		outOfBounds = checkBounds (orientationPlayer);
		if (outOfBounds) {
			dead = true;
		}

		if (dead) {
			Time.timeScale = 0;
			deadText.enabled = true;
			restartText.enabled = true;
			blocks.SetActive (false);
		}



		if (Input.GetKeyDown (KeyCode.R) && dead) {
			SceneManager.LoadScene ("scenelayout",LoadSceneMode.Single);
		}
		
		if (Input.GetKeyDown (KeyCode.D) && canTurn) {
			if (orientationPlayer >= 3) {
				orientationPlayer = 0;
			}
			else{
				orientationPlayer += 1;
			};
			targetRotation *= Quaternion.AngleAxis(angle, new Vector3 (0, 0, 1));
			rb.velocity = Vector2.zero;
			rb.gravityScale = gravityScale;
			grounded = false;
			canTurn = false;

		}
		if (Input.GetKeyDown (KeyCode.A) && canTurn) {
			if (orientationPlayer <= 0) {
				orientationPlayer = 3;
			}
			else{
				orientationPlayer -= 1;
			};
			targetRotation *= Quaternion.AngleAxis(-angle, new Vector3 (0, 0, 1));
			rb.velocity = Vector2.zero;
			rb.gravityScale = gravityScale;
			grounded = false;
			canTurn = false;
		}

		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  
		// If the jump button is pressed and the player is grounded then the player should jump.
		if (Input.GetKey (KeyCode.UpArrow) && grounded) {
			jump = true;
		}
		transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
	}

	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal");
		if (Mathf.Abs(h) < 0.01f) {
			if (orientationPlayer == 0) {
				rb.velocity = new Vector2 (0, rb.velocity.y);
			} else if (orientationPlayer == 1) {
				rb.velocity = new Vector2 (rb.velocity.x, 0);
			} else if (orientationPlayer == 2) {
				rb.velocity = new Vector2 (0, rb.velocity.y);
			} else if (orientationPlayer == 3) {
				rb.velocity = new Vector2 (rb.velocity.x, 0);
			}

		} else {

			if (orientationPlayer == 0) {
				if (h * rb.velocity.x < maxSpeed) {
					rb.AddForce (Vector2.right * h * moveForce);
				}
				if (Mathf.Abs (rb.velocity.x) > maxSpeed) {
					rb.velocity = new Vector2 (Mathf.Sign (rb.velocity.x) * maxSpeed, rb.velocity.y);
				}
			} else if (orientationPlayer == 1) {
				if (h * rb.velocity.y < maxSpeed) {
					rb.AddForce (Vector2.up * h * moveForce);
				}
				if (Mathf.Abs (rb.velocity.y) > maxSpeed) {
					rb.velocity = new Vector2 (rb.velocity.x, Mathf.Sign (rb.velocity.y) * maxSpeed);
				}
			} else if (orientationPlayer == 2) {
				if (h * rb.velocity.x < maxSpeed) {
					rb.AddForce (Vector2.left * h * moveForce);
				}
				if (Mathf.Abs (rb.velocity.x) > maxSpeed) {
					rb.velocity = new Vector2 (Mathf.Sign (rb.velocity.x) * maxSpeed, rb.velocity.y);
				}
			} else if (orientationPlayer == 3) {
				if (h * rb.velocity.y < maxSpeed) {
					rb.AddForce (Vector2.down * h * moveForce);
				}

				if (Mathf.Abs (rb.velocity.y) > maxSpeed) {
					rb.velocity = new Vector2 (rb.velocity.x, Mathf.Sign (rb.velocity.y) * maxSpeed);
				}
			}
		}


		if (jump) {

			rb.AddForce (directionJumpList [orientationPlayer] * Time.deltaTime * jumpSpeed);
			jump = false;
		}

	}


	bool checkBounds(int orientation){
		if (transform.position.y < -4.3) {
			return true;
		} else if (transform.position.x > 4.3) {
			return true;
		} else if (transform.position.y > 4.3) {
			return true;
		} else if (transform.position.x < -4.3) {
			return true;
		} else{
			return false;
			}
	}

}

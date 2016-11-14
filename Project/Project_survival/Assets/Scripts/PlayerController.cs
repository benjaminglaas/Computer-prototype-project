using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float jumpSpeed = 10.0f;
	public float speed = 10.0f;
	public Text scoreText;
	public Text deadText;
	public Text restartText;

	public GameObject blocks;

	[HideInInspector] public static Rigidbody2D rb;
	[HideInInspector] public static float gravityScale = 15.0f;
	[HideInInspector] public static bool jumping;
	[HideInInspector] public static bool canTurn;
	[HideInInspector] public static Vector3[] directionJumpList = new Vector3[4]{new Vector3(0,1,0),new Vector3(-1,0,0),new Vector3(0,-1,0),new Vector3(1,0,0)}; 
	[HideInInspector] public static int orientationPlayer;

	float smooth = 1.0f;
	float moveSpeed = 2.0f;
	float angle = 90.0f;
	float turnTimer;
	float score;

	Vector3[] directionPlayerList = new Vector3[4]{new Vector3(1,0,0),new Vector3(0,1,0),new Vector3(-1,0,0),new Vector3(0,-1,0)}; 
	Quaternion targetRotation; 
	bool dead;

	// Use this for initialization
	void Start () {
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
		jumping = true;
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

		if (checkBounds(orientationPlayer)) {
			dead = true;
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
			jumping = true;
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
			jumping = true;
			canTurn = false;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position -= directionPlayerList [orientationPlayer] * Time.deltaTime * moveSpeed;
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += directionPlayerList [orientationPlayer] * Time.deltaTime * moveSpeed;
		}
		if (Input.GetKey (KeyCode.UpArrow) && !jumping) {
			Jump ();
		}
		transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
	}


    void Jump(){
		rb.AddForce (directionJumpList [orientationPlayer] * Time.deltaTime * jumpSpeed);
		jumping = true;
		rb.gravityScale = gravityScale;
	}

	bool checkBounds(int orientation){
		if (orientation == 0) {
			if (transform.position.y < -4.5) {
				return true;
			} else {
				return false;
			}
		} else if (orientation == 1) {
			if (transform.position.x > 4.5) {
				return true;
			} else {
				return false;
			}
		} else if (orientation == 2) {
			if (transform.position.y > 4.5) {
				return true;
			} else {
				return false;
			}
		} else if (orientation == 3){
			if (transform.position.x < -4.5) {
				return true;
			} else {
				return false;
			}
		} else{
			return false;
			}
	}
}

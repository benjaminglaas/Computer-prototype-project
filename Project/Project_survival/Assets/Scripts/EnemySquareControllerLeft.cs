using UnityEngine;
using System.Collections;

public class EnemySquareControllerLeft : MonoBehaviour{

    public float moveForce = 0.5f;
    public float maxSpeed = 1f;

    [HideInInspector] public static Rigidbody2D rb;
    [HideInInspector] public static float gravityScale = 15.0f;

    bool outOfBounds;
    int orientationEnemy;
    float angle = 90.0f;
    float smooth = 1.0f;

    Quaternion targetRotation;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
        Time.timeScale = 1;
        orientationEnemy = PlayerController.orientationPlayer;
        outOfBounds = false;
    }

    // Update is called once per frame
    void Update () 
    {
        orientationEnemy = PlayerController.orientationPlayer;

        outOfBounds = checkBounds(orientationEnemy);

        if (Input.GetKeyDown(KeyCode.D) && PlayerController.canTurn)
        {
            targetRotation *= Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
            rb.velocity = Vector2.zero;
            rb.gravityScale = gravityScale;

        }
        if (Input.GetKeyDown(KeyCode.A) && PlayerController.canTurn)
        {

            targetRotation *= Quaternion.AngleAxis(-angle, new Vector3(0, 0, 1));
            rb.velocity = Vector2.zero;
            rb.gravityScale = gravityScale;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
    }
    void FixedUpdate()
    {
        if (orientationEnemy == 0)
        {
            if (rb.velocity.x < maxSpeed)
            {
                rb.AddForce(Vector2.left * moveForce);
            }
            if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            {
                rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
            }
        }
        else if (orientationEnemy == 1)
        {
            if (rb.velocity.y < maxSpeed)
            {
                rb.AddForce(Vector2.down * moveForce);
            }
            if (Mathf.Abs(rb.velocity.y) > maxSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Sign(rb.velocity.y) * maxSpeed);
            }
        }
        else if (orientationEnemy == 2)
        {
            if (rb.velocity.x < maxSpeed)
            {
                rb.AddForce(Vector2.right * moveForce);
            }
            if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            {
                rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
            }
        }
        else if (orientationEnemy == 3)
        {
            if (rb.velocity.y < maxSpeed)
            {
                rb.AddForce(Vector2.up * moveForce);
            }

            if (Mathf.Abs(rb.velocity.y) > maxSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Sign(rb.velocity.y) * maxSpeed);
            }
        }
       /* if (outOfBounds)
        {
            Destroy(gameObject);
        }
        */
    }





    bool checkBounds(int orientation)
    {
        if (transform.position.y < -4.3)
        {
            return true;
        }
        else if (transform.position.x > 4.3)
        {
            return true;
        }
        else if (transform.position.y > 4.3)
        {
            return true;
        }
        else if (transform.position.x < -4.3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

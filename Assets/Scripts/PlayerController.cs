using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    //[SerializeField]
    //GameObject raycastOrigin;

    public float speed;
    public float maxSpeed;
    public float jump;
    public float veclocityLimit;
    public float raycastDisplace;

    bool grounded = true;
    bool active = false;

    TextManager othertwo;
    Rigidbody2D rb;

    Vector2 jumpVelocity = Vector2.zero;
    Vector2 sideVelocity = Vector2.zero;
    Vector3 sub;
    Vector2 jumpVector;
    Vector2 sideVector;


    void Start()
    {
        GameObject texttwo = GameObject.Find("FoundText");
        othertwo = (TextManager)texttwo.GetComponent(typeof(TextManager)); 
        rb = GetComponent<Rigidbody2D>();
        sub = new Vector3(0, raycastDisplace, 0);

        jumpVector = new Vector2(0, jump);
        sideVector = new Vector2(0, speed);

        if (gameObject.name == "PlayerMain")
        {
            active = true;
        }
    }


    void Update()
    {
        if (active)
        {
            
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (grounded)
                {
                    RaycastHit2D hit = Physics2D.Raycast(transform.position-sub,-Vector2.up);
                    if (hit.collider != null)
                    {
                        
                        Debug.Log( "name of raycast collider:  "+ hit.collider.name);
                        
                        Quaternion rot = hit.collider.transform.rotation;
                        jumpVelocity = rot*jumpVector;

                        
                        Debug.Log("velocity:  " + rot * jumpVector);
                        rb.velocity = rb.velocity + jumpVelocity;
                        
                    }      
                }
                else
                {
                    jumpVelocity = Vector2.zero;
                }
            }

            //Left Right Movement
            if (Input.GetKey(KeyCode.D))
            {
                if (grounded)
                {

                    Vector2 sideVector = new Vector2(0, speed);
                    RaycastHit2D hit = Physics2D.Raycast(transform.position - sub, -Vector2.up);
                    if (hit.collider != null)
                    {
                        Quaternion rot = hit.collider.transform.rotation;
                        rot = Quaternion.Euler(0, 0, 90) * rot;
                        sideVelocity = rot * -sideVector;
                        rb.velocity = rb.velocity + sideVelocity;

                    }
                }
                else
                {
                    
                    rb.velocity =new Vector2(rb.velocity.x+speed, rb.velocity.y);
                }

            }


            if (Input.GetKey(KeyCode.A))
            {
                if (grounded)
                {

                    Vector2 sideVector = new Vector2(0, speed);
                    RaycastHit2D hit = Physics2D.Raycast(transform.position - sub, -Vector2.up);
                    if (hit.collider != null)
                    {
                        Quaternion rot = hit.collider.transform.rotation;
                        rot = Quaternion.Euler(0, 0, 90) * rot;
                        sideVelocity = rot * -sideVector;
                       
                        rb.velocity = rb.velocity + -sideVelocity;
                    }
                }
                else
                {

                    rb.velocity = new Vector2(rb.velocity.x - speed, rb.velocity.y);
                }

            }
            if (rb.velocity.x > maxSpeed)
            {
                rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
            }
            if (rb.velocity.x < -maxSpeed)
            {
                rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
            }
        }
    }
    //Check if Grounded
    void OnCollisionEnter2D(Collision2D other)
    {
        string otherTag = other.gameObject.tag;
        Debug.Log("collided");
        if (other.gameObject.tag == "Floors")
        {
            Debug.Log("Hit floor");
            grounded = true;
        }

        if (otherTag == "Player")
        {
            Debug.Log("Hit player");
            if (active == false)
            {
                othertwo.TextOut();
                active = true;
            }

        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floors")
        {
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floors")
        {
            Debug.Log("stopped Hit floor");
            grounded = false;
        }
    }
}
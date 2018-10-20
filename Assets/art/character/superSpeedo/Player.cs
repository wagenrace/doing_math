using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Rigidbody2D myRigidbody2D;

    public float moveSpeed;
    public float jumpSpeed;

    private Animator anim;

    private bool grounded;

    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundDistance;

	// Use this for initialization
	void Start () {
        myRigidbody2D = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetKey(KeyCode.A))
        {
            myRigidbody2D.velocity = new Vector2(-moveSpeed,myRigidbody2D.velocity.y);
        } else if (Input.GetKey(KeyCode.D))
        {
            myRigidbody2D.velocity = new Vector2(moveSpeed, myRigidbody2D.velocity.y);
        }
        else
        {
            myRigidbody2D.velocity = new Vector2(0f, myRigidbody2D.velocity.y);
        }

        anim.SetFloat("Speed", Mathf.Abs( myRigidbody2D.velocity.x));

        if(myRigidbody2D.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else if(myRigidbody2D.velocity.x > 0)
        {
            transform.localScale = new Vector3(1f,1f,1f);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpSpeed);
            
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, whatIsGround);
        anim.SetBool("Jump", !grounded);
	}
}

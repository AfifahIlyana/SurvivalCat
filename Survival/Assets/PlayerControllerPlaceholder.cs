using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPlaceholder : MonoBehaviour {
    public float maxSpeed = 10f;
    bool facingRight = true;

    Animator anim;

    //bool grounded = false;
    //public Transform groundCheck;
    //float groundRadius = 0.2f;
    //public LayerMask whatIsGround;

    public float jumpForce = 700f;

	void Start () {
        anim = GetComponent<Animator>();
	}

    void FixedUpdate() {

        Rigidbody rb2d = GetComponent<Rigidbody>();

        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //anim.SetBool("ground", grounded);

        anim.SetFloat("vSpeed", rb2d.velocity.y);

        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("speed", Mathf.Abs(move));
        
        rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

    }

    void Update() {
        Rigidbody rb2d = GetComponent<Rigidbody>();

        if (Input.GetButtonDown("Jump")) {
            //anim.SetBool("ground", false);
            rb2d.AddForce(new Vector2(0, jumpForce));
        }
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
}

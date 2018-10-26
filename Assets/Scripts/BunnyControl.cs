using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyControl : MonoBehaviour {


    public float maxspeed = 10f;
    bool facingright = true;
    Rigidbody2D rigidbody2D;

    Animator anim;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask WhatIsGround;
    public float JumpForce = 700;

    bool DoubleJump = false;

	// Use this for initialization
	void Start ()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, WhatIsGround);
        anim.SetBool("Ground", grounded);

        if (grounded)
            DoubleJump = false;

        anim.SetFloat("vSpeed", rigidbody2D.velocity.y);


        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));
        rigidbody2D.velocity = new Vector2(move * maxspeed, rigidbody2D.velocity.y);
        if(move > 0 &&!facingright)
        {
            Flip();
        }
        else if (move < 0 && facingright)
        {
            Flip();
        }
	}

    void Update()
    {
        if((grounded || !DoubleJump) && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            rigidbody2D.AddForce(new Vector2(0, JumpForce));

            if (!DoubleJump && !grounded)
                DoubleJump = true;
        }
    }


    void Flip()
    {
        facingright = !facingright;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
}

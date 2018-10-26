using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyControl : MonoBehaviour {


    public float maxspeed = 10f;
    bool facingright = true;
    Rigidbody2D rigidbody2D;

    Animator anim;

	// Use this for initialization
	void Start ()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
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
    

    void Flip()
    {
        facingright = !facingright;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
}

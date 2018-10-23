using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyControl : MonoBehaviour {


    public float maxspeed = 10f;
    bool facingright = true;
    Rigidbody2D rigidbody2D; 

	// Use this for initialization
	void Start ()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float move = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(move * maxspeed, rigidbody2D.velocity.y);
	}

    void Flip()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyControl : MonoBehaviour {


    public float maxspeed = 10f;
    bool facingright = true; 

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float move = Input.GetAxis("Horizontal");
        Rigidbody2D.velocity = new Vector2(move * maxspeed, Rigidbody2D.velocity.y);
	}

    void Flip()
    {

    }
}

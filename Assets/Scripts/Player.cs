﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class Player : NetworkBehaviour
{
    
    public Movement movement;
    public PlayerInput input;
    public PlayerAnimation anim;
    Vector2 direction;
    bool lookRight = true;
    bool grounded = false;
    void Start () {
        direction = Vector2.zero;
        movement.initialise(GetComponent<Rigidbody2D>(), transform.Find("GroundCheck"));
        anim.initialise(GetComponent<Animator>());
    }
	
	void Update () {
        grounded = movement.isGrounded();
        
        if (isLocalPlayer)
        {
            if (grounded)
            {
                if (input.isJumpDown) movement.jump();
            }
        }

        updateAnimation();
    }

    public void FixedUpdate()
    {
        if (!isLocalPlayer) return;
        if (input.isLeft)
        {
            movement.move(-1, Time.fixedDeltaTime);
        }
        else if (input.isRight)
        {
            movement.move(1, Time.fixedDeltaTime);
        }
        else
        {
            movement.stop();
        }
    }

    void flip()
    {
        lookRight = !lookRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void updateAnimation()
    {
        if(grounded)
        {
            anim.setGrounded(true);
        }
        else
        {
            anim.setGrounded(false);
        }
        anim.setVerticalSpeed(movement.VerticalSpeed);
        anim.setWalkSpeed(movement.HorizontalSpeed);

        if(movement.HorizontalSpeed > 0.1f)
        {
            if (!lookRight) flip();
        }
        else if(movement.HorizontalSpeed < -0.1f)
        {
            if (lookRight) flip();
        }
    }
}

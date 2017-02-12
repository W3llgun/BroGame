using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Movement{

    Rigidbody2D rigid;
    public float acceleration = 1;        // The acceleration of the object
    public float maxSpeed = 2f;           // The fastest the object can travel in the x axis.
    public float jumpForce = 10;          // Amount of force added when the player jumps.
    public bool airControl = false;       // Whether or not the object can steer while jumping;
    public LayerMask whatIsGround;

    bool grounded = false;
    private float groundRadius = 0.5f;
    Transform groundCheck;

    public void initialise(Rigidbody2D r, Transform grdcheck)
    {
        rigid = r;
        groundCheck = grdcheck;
    }

    public void move(float direction, float deltaT)
    {
        if (grounded == false && airControl == false) return;

        Vector2 vel = new Vector2(rigid.velocity.x + direction * (acceleration * deltaT), 0);
        vel = Vector2.ClampMagnitude(vel, maxSpeed);
        vel.y = rigid.velocity.y;
        rigid.velocity = vel;
    }

    public void jump()
    {
        rigid.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    public void stop()
    {
        rigid.velocity = new Vector2(0, rigid.velocity.y);
    }
    
    public bool isGrounded()
    {
        if (groundCheck == null) return false;

        if (Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        return grounded;
    }

    public float HorizontalSpeed { get { return rigid.velocity.x; } }
    public float VerticalSpeed { get { return rigid.velocity.y; } }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Movement{

    Rigidbody2D rigid;
    public float acceleration = 100f;                    // The fastest the player can travel in the x axis.
    public float maxSpeed = 2f;                    // The fastest the player can travel in the x axis.
    public float jumpForce = 400f;                  // Amount of force added when the player jumps.
    [Range(0, 1)]
    public float crouchSpeed = .36f;                 // Amount of maxSpeed applied to crouching movement. 1 = 100%
    public bool airControl = false;                 // Whether or not a player can steer while jumping;
    
    public void initialise(Rigidbody2D r)
    {
        rigid = r;
    }

    public void move(Vector2 direction)
    {
        Vector2 vel = rigid.velocity;
        vel += direction * acceleration * Time.fixedDeltaTime;
        vel = Vector2.ClampMagnitude(vel, maxSpeed);
        rigid.velocity += vel;
    }

    public void stop()
    {
        rigid.velocity = new Vector2(0, rigid.velocity.y);
    }
}

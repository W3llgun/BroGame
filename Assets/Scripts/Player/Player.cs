using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class Player : Entity
{
    
    public Movement movement;
    public PlayerInput input;
    public PlayerAnimation anim;
    public Weapon weapon = null;
    private float radiusCollision = 1f;

    Vector2 direction;
    bool lookRight = true;
    bool grounded = false;
    Transform inventory;

    void Start () {
        direction = Vector2.zero;
        movement.initialise(rigid, transform.Find("GroundCheck"));
        anim.initialise(GetComponent<Animator>());
        inventory = transform.Find("Inventory");
        if(weapon) weapon.setOwner(this);
        if (isLocalPlayer && Camera.main.GetComponent<MovementCamera>()) Camera.main.GetComponent<MovementCamera>().setTargetTransform(transform);
    }
	
	void Update () {
        grounded = movement.isGrounded();
        if (isLocalPlayer)
        {
            if (grounded)
            {
                if (input.isJumpDown) movement.jump();
            }
            if(weapon != null && weapon.canUse() && input.isPrimaryShootDown)
            {
                
                weapon.Use();
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

        //get weapon
        Collider2D item = Physics2D.OverlapCircle(transform.position, radiusCollision, 1<<LayerMask.NameToLayer("Weapon"));
        if(item!=null)
        {
            if (input.isUseObjectDown)
            {
                weapon = item.gameObject.GetComponent<Weapon>();
                weapon.setOwner(this);
            }
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

        if(isLocalPlayer)
        {
            float x = Utility.mouseDirection(Camera.main, transform).x;
            if (x > 0)
            {
                if (!lookRight) flip();
            }
            else if (x < 0)
            {
                if (lookRight) flip();
            }
        }
    }
}

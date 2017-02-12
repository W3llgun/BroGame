using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class Player : NetworkBehaviour
{
    public Movement movement;
    public PlayerInput input;
    public PlayerAnimation anim;
    public Weapon weapon = null;

    Vector2 direction;
    bool lookRight = true;
    bool grounded = false;
    Transform inventory;

    void Start () {
        direction = Vector2.zero;
        movement.initialise(GetComponent<Rigidbody2D>(), transform.Find("GroundCheck"));
        anim.initialise(GetComponent<Animator>());
        inventory = transform.Find("Inventory");
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Weapon"))
        {
            takeWeapon(collision.collider.gameObject);
        }
    }

    void takeWeapon(GameObject wp)
    {
        weapon = wp.GetComponent<Weapon>();
        wp.transform.position = inventory.position;
        wp.transform.SetParent(inventory);
        weapon.setOwner(this);
    }
}

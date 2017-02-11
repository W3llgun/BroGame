using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class Player : NetworkBehaviour
{
    public LayerMask whatIsGround;
    public Movement movement;
    public PlayerInput input;
    Vector2 direction;

    void Start () {
        direction = Vector2.zero;
        movement.initialise(GetComponent<Rigidbody2D>());
	}
	
	void Update () {
        if (!isLocalPlayer) return;
        
        if(input.isLeft)
        {
            Debug.Log("Left");
            direction.x = -1;
        }
        else if(input.isRight)
        {
            Debug.Log("Right");
            direction.x = 1;
        }
        else
        {
            direction.x = 0;
        }
	}

    public void FixedUpdate()
    {
        if(direction.x == 0)
        {
            movement.stop();
        }
        else
        {
            movement.move(direction);
        }
        
    }
}

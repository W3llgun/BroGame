using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class Player : NetworkBehaviour
{

    [SerializeField]private float maxSpeed = 10f;                    // The fastest the player can travel in the x axis.
    [SerializeField]private float jumpForce = 400f;                  // Amount of force added when the player jumps.
    [Range(0, 1)]
    [SerializeField]private float crouchSpeed = .36f;                 // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [SerializeField]private bool airControl = false;                 // Whether or not a player can steer while jumping;
    [SerializeField]private LayerMask whatIsGround;
    [SerializeField]private Movement movement;
    [SerializeField]private PlayerInput input;

    void Start () {
		
	}
	
	void Update () {
        if (!isLocalPlayer) return;


	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    Movement movement;


	// Use this for initialization
	void Start () {
        movement.initialise(GetComponent<Rigidbody2D>(), null);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Entity : NetworkBehaviour
{

    protected Collider2D col { get; set; }
    protected Rigidbody2D rigid { get; set; }

	protected virtual void Awake()
    {
        col = GetComponent<Collider2D>();
        rigid = GetComponent<Rigidbody2D>();
    }


}

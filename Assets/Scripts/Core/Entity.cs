using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    protected Collider2D col { get; set; }
    protected Rigidbody2D rigid { get; set; }

	protected virtual void Awake()
    {
        col = GetComponent<Collider2D>();
        rigid = GetComponent<Rigidbody2D>();
    }


}

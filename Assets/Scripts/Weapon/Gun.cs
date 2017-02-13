using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Gun : Weapon {
    public GameObject bullet;
    public float damage;

    public override bool canUse()
    {
        return true;
    }

    public override void Use()
    {
        
        Cmdshoot();
    }

    [Command]
    void Cmdshoot()
    {

        if (!bullet) return;

        Transform b = Instantiate(bullet).transform;
        b.position = transform.position;
        b.forward = transform.forward;
        b.GetComponent<Projectile>().Launch(owner, Utility.mouseDirection(Camera.main, transform).normalized, damage, 30);
        NetworkServer.Spawn(b.gameObject);
        Destroy(b, 10);
    }
}

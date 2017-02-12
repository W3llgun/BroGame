using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon {
    public GameObject bullet;
    public float damage;

    public override bool canUse()
    {
        return true;
    }

    public override void Use()
    {
        shoot();
    }

    void shoot()
    {
        if (!bullet) return;
        Transform b = Instantiate(bullet).transform;
        b.transform.position = transform.position;
        b.forward = transform.forward;
        b.GetComponent<Projectile>().Launch(owner, Utility.mouseDirection(Camera.main, transform), damage, 30);
    }
}

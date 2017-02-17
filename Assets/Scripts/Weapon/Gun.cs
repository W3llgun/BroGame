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
        Debug.Log("Shoot");
        Cmdshoot();
    }

    [Command]
    void Cmdshoot()
    {
        //if (!bullet) bullet = Resources.Load<GameObject>("Projectile");
        //if (!bullet) return;
        Debug.Log("Srv shoot");
        Transform b = GameObject.Instantiate(bullet).transform;
        b.position = owner.transform.position + (owner.transform.right);
        b.right = owner.transform.right;
        b.GetComponent<Projectile>().Launch(owner, Utility.mouseDirection(Camera.main, owner.transform).normalized, damage, 30);
        NetworkServer.Spawn(b.gameObject);
        GameObject.Destroy(b.gameObject, 10);
    }
}

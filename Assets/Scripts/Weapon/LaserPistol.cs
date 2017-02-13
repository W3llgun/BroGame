using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LaserPistol : Weapon
{
    public GameObject laserBeam;

    public override bool canUse()
    {
        return true;
    }

    public override void Use()
    {

    }

    [Command]
    void Cmdshoot()
    {

    }
}

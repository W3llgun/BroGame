using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Weapon : Entity{
    protected Player owner = null;
    public float speedRotation;
    
    public virtual void initWeapon(Player p)
    {
        owner = p;
    }

    public abstract void Use();
    public abstract bool canUse();
    

    public virtual Player getOwner()
    {
        return owner;
    }
    
}

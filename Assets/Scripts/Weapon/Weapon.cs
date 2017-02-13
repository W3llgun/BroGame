using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Weapon : Entity{
    protected Player owner = null;
    
    protected override void Awake()
    {
        base.Awake();
    }

    public abstract void Use();
    public abstract bool canUse();

    public virtual void setOwner(Player p)
    {
        owner = p;
        col.enabled = false;
        rigid.simulated = false;
    }

    private void Update()
    {
        //Follow Owner
        if(owner!=null)
        {
            transform.position = owner.transform.position+new Vector3(owner.transform.localScale.x,0,0);
        }
    }
}

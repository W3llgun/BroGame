using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Weapon : Entity{
    protected Player owner = null;
    public float speedRotation;
    
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
        //transform.SetParent(owner.transform);
    }

    private void Update()
    {
        //Follow Owner and rotation with mouse
        if(owner!=null)
        {
            Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float angle = Mathf.Atan2(mouseInWorld.y - owner.transform.position.y, mouseInWorld.x - owner.transform.position.x) * Mathf.Rad2Deg;
            
            //rotation around the player with latency
            transform.position = owner.transform.position + Quaternion.Lerp(transform.rotation,Quaternion.AngleAxis(angle, Vector3.forward), speedRotation) * Vector3.right;
            //rotation weapon
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), speedRotation);
        }
    }
}

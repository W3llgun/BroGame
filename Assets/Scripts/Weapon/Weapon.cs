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
    }

    private void Update()
    {
        //Follow Owner
        if(owner!=null)
        {
            Vector3 relativePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(Mathf.LerpAngle(transform.rotation.eulerAngles.z, angle, speedRotation), Vector3.forward);

            transform.SetParent(owner.transform);
            transform.rotation = rotation;
        }
    }
}

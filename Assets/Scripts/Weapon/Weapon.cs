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
        //Follow Owner
        if(owner!=null)
        {
            Vector3 relativePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(Mathf.LerpAngle(transform.rotation.eulerAngles.z, angle, speedRotation), Vector3.forward);
            Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = owner.transform.position + Vector3.ClampMagnitude(new Vector2(mouseInWorld.x- owner.transform.position.x, mouseInWorld.y- owner.transform.position.y), 1f);
            transform.rotation = rotation;
        }
    }
}

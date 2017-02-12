using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAnimation {
    public Animator animator;

    public void initialise(Animator a)
    {
        animator = a;
        
    }

    public void setGrounded(bool val)
    {
        animator.SetBool("Ground", val);
    }

    public void setVerticalSpeed(float val)
    {
        animator.SetFloat("vSpeed", val);
    }

    public void setWalkSpeed(float val)
    {
        animator.SetFloat("Speed", Mathf.Abs(val));
    }

}

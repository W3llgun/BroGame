using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destroyable : MonoBehaviour {
    public float maxHealth = 10;

    protected float currentHealth = 0;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    
    public virtual void Damage(float dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0) death();
    }

    protected virtual void death()
    {
        Destroy(this.gameObject);
    }
}

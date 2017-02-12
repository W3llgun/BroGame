using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Entity {
    public Movement movement;
    public LayerMask collideMask;
    Player owner;

    float damage = 1;
    float speed = 10;
    bool shooted = false;
    Vector2 direction;


	void Start () {
        movement.initialise(GetComponent<Rigidbody2D>(), null);

    }

    public void Launch(Player launcher, Vector2 dir, float dmg, float spd)
    {
        owner = launcher;
        shooted = true;
        direction = dir;
        damage = dmg;
        speed = spd;
    }

    private void FixedUpdate()
    {
        if(shooted)
        {
            move();
        }
    }

    void move()
    {
        rigid.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collideMask == (collideMask | (1 << collision.collider.gameObject.layer)))
        {
            Destroyable dest = collision.collider.gameObject.GetComponent<Destroyable>();
            if (dest != null && dest.gameObject != owner.gameObject) dest.Damage(damage);
            Destroy(this.gameObject);
        }            
    }
}

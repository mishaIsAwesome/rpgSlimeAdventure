using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    Animator animator;

    Rigidbody2D rb;

    bool isAlive = true;

    public float Health
    {
        set
        {
            if (value < health)
            {
                animator.SetTrigger("Hit");
            }

            health = value;

            if (health <= 0)
            {
                animator.SetBool("isAlive", false);
            }
        }

        get
        {
            return health;
        }
    }

    public float health = 1;
    public float damage = 1;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnHit(float damage, Vector2 knockback){
        Health -= damage;
        rb.AddForce(knockback);
    }

    public void OnHit(float damage){
        Health -= damage;
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col){
        IDamageable damageable = col.collider.GetComponent<IDamageable>();

        if (damageable != null){
            damageable.OnHit(damage);
        }
    }
}

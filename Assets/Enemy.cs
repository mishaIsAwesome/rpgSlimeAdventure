using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage = 1;
    public float knockbackForce = 30f;

    public float moveSpeed = 500f;

    public DetectionZone detectionZone;

    Rigidbody2D rb;

    DamageableCharacter damageableCharacter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        damageableCharacter = GetComponent<DamageableCharacter>();
    }

    void FixedUpdate()
    {
        if (damageableCharacter.Targetable && detectionZone.detectedObjs.Count > 0)
        {
            Vector2 direction = (detectionZone.detectedObjs[0].transform.position - transform.position).normalized;
            rb.AddForce(direction * moveSpeed * Time.deltaTime); 
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        Collider2D collider = col.collider;
        IDamageable damageable = collider.GetComponent<IDamageable>();

        if (damageable != null){
            print("knockback!");
        //    Vector3 parentPosition = transform.parent.position;
            Vector2 direction = (Vector2)(collider.transform.position - transform.position).normalized;
            Vector2 knockback = direction * knockbackForce;
            print("direction: " + direction);  print("knockback: " + knockback);
            damageable.OnHit(damage, knockback);
        }
    }
}

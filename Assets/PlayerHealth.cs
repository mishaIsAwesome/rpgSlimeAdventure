using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public float Health {}
    public float health = 3;
     public void OnHit(float damage, Vector2 knockback){
        Health -= damage;
        rb.AddForce(knockback);
    }

    public void OnHit(float damage){
        Health -= damage;
    }
}

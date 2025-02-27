using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float damage = 3;
    public float knockbackForce = 5000f;
    Vector2 rightAttackOffset;
    public Collider2D swordCollider;

    // Start is called before the first frame update
    void Start()
    {
        rightAttackOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AttackRight()
    {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {

        IDamageable damageableObject = collider.GetComponent<IDamageable>();

            if (damageableObject != null)
            {
                Vector3 parentPosition = transform.parent.position;
                Vector2 direction = (Vector2)(collider.transform.position - parentPosition).normalized;
                Vector2 knockback = direction * knockbackForce;

                damageableObject.OnHit(damage, knockback);
            }
        
    }
}

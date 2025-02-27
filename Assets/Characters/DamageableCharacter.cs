using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour, IDamageable
{
    public GameObject healthText;
    public bool disableSimulation = false;
    public bool isInvincibilityEnabled = false;
    public float invincibilityTime = 0.25f;
    Animator animator;

    Rigidbody2D rb;

    Collider2D physicsCollider;

    bool isAlive = true;
    private float invincibleTimeElapsed = 0f;
    public CollectibleCount collectibleCount;


    public float Health
    {
        set
        {
            if (value < health)
            {
                animator.SetTrigger("Hit");
                RectTransform textTransform = Instantiate(healthText).GetComponent<RectTransform>();
                textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);

                Canvas canvas = GameObject.FindObjectOfType<Canvas>();
                textTransform.SetParent(canvas.transform);
                if (gameObject.tag == "Player")
                {
                    collectibleCount.OnMinusHealth();
                }
            }

            health = value;

            if (health <= 0)
            {
                animator.SetBool("isAlive", false);
                Targetable = false;
            }
        }

        get
        {
            return health;
        }
    }

    public bool Targetable
    {
        set
        {
            targetable = value;
            if (disableSimulation)
            { rb.simulated = value;}
            physicsCollider.enabled = value;
        }
        get {
           return targetable; 
        } 
        
    }

    public bool Invincible
    {
        set
        {
            invincible = value;
            if (invincible)
            {
                invincibleTimeElapsed = 0f;
            }
        }
        get
        {
            return invincible;
        }
    }

    public float health = 1;
    public bool targetable = true;
    public bool invincible = false; 

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);

        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Invincible)
        {
            invincibleTimeElapsed += Time.deltaTime;

            if (invincibleTimeElapsed > invincibilityTime)
            {
                Invincible = false;
            }
        }
    }

    public void OnHit(float damage, Vector2 knockback){
        if (!Invincible)
        {
            Health -= damage;
            rb.AddForce(knockback, ForceMode2D.Impulse);

            if (isInvincibilityEnabled)
            {
                Invincible = true;
            }
        }
    }

    public void OnHit(float damage){
        if (!Invincible)
        {
            Health -= damage;
            if (isInvincibilityEnabled)
            {
                Invincible = true;
            }
        }
    }

    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
    }
}

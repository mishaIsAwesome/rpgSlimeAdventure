using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private bool isCollected = false;
    public string tagTarget = "Player";
    public Collider2D col;
    Animator animator;

    public CollectibleCount collectibleCount;

    // Start is called before the first frame update
    void Start()
    {
        col.GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == tagTarget && !isCollected)
        {
            animator.SetBool("isOpen", true);
            collectibleCount.OnAddCount();
            isCollected = true;
        }
    }
}

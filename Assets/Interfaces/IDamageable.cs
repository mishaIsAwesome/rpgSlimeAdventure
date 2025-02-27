using UnityEngine;

public interface IDamageable
{
    public float Health { set; get; }
    public bool Targetable { set; get; }
    public bool Invincible { set; get; }
    void OnHit(float damage, Vector2 knockback);
    void OnHit(float damage);
    public void OnObjectDestroyed();
}
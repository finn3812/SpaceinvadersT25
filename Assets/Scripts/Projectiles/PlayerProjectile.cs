using UnityEngine;

public class PlayerProjectile : Projectile
{
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponentInParent<Enemy>();

        if (enemy == null)
            return;

        enemy.TakeDamage(damage);
        Destroy(gameObject);
    }
}
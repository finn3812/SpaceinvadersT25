using UnityEngine;

public class EnemyProjectile : Projectile
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.GetComponentInParent<PlayerHealth>();

        if (player == null)
            return;

        player.TakeHit();
        Destroy(gameObject);
    }
}
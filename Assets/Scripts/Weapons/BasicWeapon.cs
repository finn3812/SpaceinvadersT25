using UnityEngine;

public class BasicWeapon : Weapon
{
    [SerializeField] private PlayerProjectile projectilePrefab;
    [SerializeField] private Transform firePoint;

    protected override void Fire()
    {
        PlayerProjectile projectile = Instantiate(
            projectilePrefab,
            firePoint.position,
            firePoint.rotation
        );

        projectile.Initialize(firePoint.forward);
    }
}
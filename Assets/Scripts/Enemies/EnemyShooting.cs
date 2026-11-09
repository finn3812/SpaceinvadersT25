using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private EnemyProjectile projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireInterval = 2f;

    private float nextFireTime;

    private void Start()
    {
        nextFireTime = Time.time + fireInterval;
    }

    private void Update()
    {
        if (Time.time < nextFireTime)
            return;

        Fire();
        nextFireTime = Time.time + fireInterval;
    }

    private void Fire()
    {
        EnemyProjectile projectile = Instantiate(
            projectilePrefab,
            firePoint.position,
            Quaternion.identity
        );

        projectile.Initialize(Vector3.back);
    }
}
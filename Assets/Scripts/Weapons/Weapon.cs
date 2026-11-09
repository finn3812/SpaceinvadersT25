using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float fireInterval = 0.2f;

    private float nextFireTime;

    public void TryFire()
    {
        if (Time.time < nextFireTime)
            return;

        Fire();
        nextFireTime = Time.time + fireInterval;
    }

    protected abstract void Fire();
}
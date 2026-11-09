using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float speed = 10f;
    [SerializeField] protected int damage = 1;
    [SerializeField] private float lifetime = 3f;

    private Rigidbody projectileBody;
    private Vector3 direction;

    protected virtual void Awake()
    {
        projectileBody = GetComponent<Rigidbody>();
    }

    public void Initialize(Vector3 travelDirection)
    {
        direction = travelDirection.normalized;
        Destroy(gameObject, lifetime);
    }

    protected virtual void FixedUpdate()
    {
        Vector3 nextPosition = projectileBody.position
            + direction * speed * Time.fixedDeltaTime;

        projectileBody.MovePosition(nextPosition);
    }
}
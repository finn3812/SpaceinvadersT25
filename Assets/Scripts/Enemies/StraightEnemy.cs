using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StraightEnemy : Enemy
{
    [SerializeField] private float horizontalSpeed = 2f;
    [SerializeField] private float downwardSpeed = 0.3f;
    [SerializeField] private float minX = -4.5f;
    [SerializeField] private float maxX = 4.5f;

    private Rigidbody enemyBody;
    private float horizontalDirection = 1f;

    protected override void Awake()
    {
        base.Awake();
        enemyBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 position = enemyBody.position;

        position.x += horizontalDirection * horizontalSpeed
                      * Time.fixedDeltaTime;
        position.z -= downwardSpeed * Time.fixedDeltaTime;

        if (position.x >= maxX)
        {
            position.x = maxX;
            horizontalDirection = -1f;
        }
        else if (position.x <= minX)
        {
            position.x = minX;
            horizontalDirection = 1f;
        }

        enemyBody.MovePosition(position);
    }
}
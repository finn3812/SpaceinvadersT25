using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WaveEnemy : Enemy
{
    [SerializeField] private float downwardSpeed = 0.8f;
    [SerializeField] private float waveWidth = 1.5f;
    [SerializeField] private float waveSpeed = 2f;

    private Rigidbody enemyBody;
    private float startX;
    private float elapsedTime;

    protected override void Awake()
    {
        base.Awake();

        enemyBody = GetComponent<Rigidbody>();
        startX = enemyBody.position.x;
    }

    private void FixedUpdate()
    {
        elapsedTime += Time.fixedDeltaTime;

        Vector3 position = enemyBody.position;

        position.x = startX + Mathf.Sin(elapsedTime * waveSpeed) * waveWidth;
        position.z -= downwardSpeed * Time.fixedDeltaTime;

        enemyBody.MovePosition(position);
    }
}
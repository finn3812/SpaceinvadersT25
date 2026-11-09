using UnityEngine;

public class BottomBoundary : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponentInParent<Enemy>();

        if (enemy == null)
            return;

        playerHealth.LoseLifeFromEscapedEnemy();
        Destroy(enemy.gameObject);
    }
}
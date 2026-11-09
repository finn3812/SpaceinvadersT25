using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth = 2;
    [SerializeField] private int pointValue = 5;
    [SerializeField] private EnemyHealthBar healthBar;

    private int currentHealth;
    private bool isDefeated;

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDefeated)
            return;

        currentHealth -= damage;

        if (healthBar != null)
            healthBar.UpdateHealth(currentHealth, maxHealth);

        if (currentHealth <= 0)
            Die();
    }

    protected virtual void Die()
    {
        isDefeated = true;

        ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();

        if (scoreManager != null)
            scoreManager.AddScore(pointValue);
        else
            Debug.LogWarning("Ingen ScoreManager fundet i scenen.");

        Destroy(gameObject);
    }
}
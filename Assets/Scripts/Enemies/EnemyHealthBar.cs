using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private GameObject barVisual;
    [SerializeField] private Transform fill;

    private Vector3 initialFillScale;
    private Vector3 initialFillPosition;

    private void Awake()
    {
        initialFillScale = fill.localScale;
        initialFillPosition = fill.localPosition;

        barVisual.SetActive(false);
    }

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        barVisual.SetActive(true);

        float fraction = Mathf.Clamp01((float)currentHealth / maxHealth);

        // Bevar venstre kant, mens den grønne del bliver kortere.
        fill.localScale = new Vector3(
            initialFillScale.x * fraction,
            initialFillScale.y,
            initialFillScale.z
        );

        fill.localPosition = initialFillPosition
            + Vector3.left * initialFillScale.x * (1f - fraction) / 2f;
    }
}
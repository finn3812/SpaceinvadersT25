using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class GameUIController : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private WaveSpawner waveSpawner;

    private Label livesLabel;
    private Label scoreLabel;
    private Label waveLabel;
    private Label messageLabel;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        livesLabel = root.Q<Label>("lives-label");
        scoreLabel = root.Q<Label>("score-label");
        waveLabel = root.Q<Label>("wave-label");
        messageLabel = root.Q<Label>("message-label");
    }

    private void LateUpdate()
    {
        livesLabel.text = $"Liv: {playerHealth.CurrentLives}";
        scoreLabel.text = $"Point: {scoreManager.Score}";
        waveLabel.text = $"Bølge: {waveSpawner.CurrentWaveNumber}";

        if (playerHealth.IsDead)
            messageLabel.text = "Du tabte!";
        else if (waveSpawner.AllWavesSpawned)
            messageLabel.text = "Alle bølger er spawnet!";
        else
            messageLabel.text = "";
    }
}
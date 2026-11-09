using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score { get; private set; }

    public void AddScore(int points)
    {
        Score += points;
        Debug.Log($"Point: {Score}");
    }
}
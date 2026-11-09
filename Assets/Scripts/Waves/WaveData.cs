using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "Space Invaders/Wave")]
public class WaveData : ScriptableObject
{
    public EnemySpawn[] spawns;
}

[Serializable]
public class EnemySpawn
{
    public Enemy enemyPrefab;
    public int count = 3;
    public float startDelay = 0f;
    public float spawnInterval = 1f;
}
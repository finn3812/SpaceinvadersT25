using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private WaveData[] waves;
    [SerializeField] private float timeBetweenWaveStarts = 10f;

    [Header("Spawnområde")]
    [SerializeField] private float minSpawnX = -3f;
    [SerializeField] private float maxSpawnX = 3f;
    [SerializeField] private float spawnY = 0.5f;
    [SerializeField] private float spawnZ = 4.5f;

    [Header("Overgang efter sidste bølge")]
    [SerializeField] private UnityEvent onAllWavesSpawned;

    public int CurrentWaveNumber { get; private set; }

    private int activeSpawnSequences;

    public bool AllWavesSpawned { get; private set; }

    private void Start()
    {
        StartCoroutine(RunWaves());
    }

    private IEnumerator RunWaves()
    {
        if (waves == null || waves.Length == 0)
        {
            Debug.LogWarning("Der er ikke tildelt nogen bølger.");
            yield break;
        }

        for (int i = 0; i < waves.Length; i++)
        {
            CurrentWaveNumber = i + 1;
            Debug.Log($"Bølge {CurrentWaveNumber} starter.");

            StartWave(waves[i]);

            if (i < waves.Length - 1)
                yield return new WaitForSeconds(timeBetweenWaveStarts);
        }

        // Vent på, at alle spawnsekvenser er færdige.
        yield return new WaitUntil(() => activeSpawnSequences == 0);

        AllWavesSpawned = true;
        Debug.Log("Alle bølger er spawnet. Overgang til næste fase.");
        onAllWavesSpawned?.Invoke();
    }

    private void StartWave(WaveData wave)
    {
        if (wave == null || wave.spawns == null)
        {
            Debug.LogWarning("En bølge mangler data.");
            return;
        }

        foreach (EnemySpawn spawn in wave.spawns)
        {
            if (spawn == null || spawn.enemyPrefab == null)
            {
                Debug.LogWarning("En spawnindgang mangler en fjendeprefab.");
                continue;
            }

            activeSpawnSequences++;
            StartCoroutine(SpawnEnemies(spawn));
        }
    }

    private IEnumerator SpawnEnemies(EnemySpawn spawn)
    {
        yield return new WaitForSeconds(spawn.startDelay);

        for (int i = 0; i < spawn.count; i++)
        {
            float x = Random.Range(minSpawnX, maxSpawnX);
            Vector3 position = new Vector3(x, spawnY, spawnZ);

            Instantiate(spawn.enemyPrefab, position, Quaternion.identity);

            if (i < spawn.count - 1)
                yield return new WaitForSeconds(spawn.spawnInterval);
        }

        activeSpawnSequences--;
    }
}
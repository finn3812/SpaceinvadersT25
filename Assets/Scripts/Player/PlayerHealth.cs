using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int startingLives = 5;
    [SerializeField] private float protectionDuration = 0.5f;
    [SerializeField] private float blinkInterval = 0.1f;

    public int CurrentLives => currentLives;
    public bool IsDead => isDead;

    private int currentLives;
    private float protectedUntil;
    private bool isDead;

    private Renderer playerRenderer;
    private Coroutine blinkRoutine;

    private void Awake()
    {
        currentLives = startingLives;
        playerRenderer = GetComponentInChildren<Renderer>();
    }

    public void TakeHit()
    {
        if (isDead || Time.time < protectedUntil)
            return;

        currentLives--;
        Debug.Log($"Liv tilbage: {currentLives}");

        if (currentLives <= 0)
        {
            Die();
            return;
        }

        protectedUntil = Time.time + protectionDuration;

        if (blinkRoutine != null)
            StopCoroutine(blinkRoutine);

        blinkRoutine = StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        while (Time.time < protectedUntil)
        {
            if (playerRenderer != null)
                playerRenderer.enabled = !playerRenderer.enabled;

            yield return new WaitForSeconds(blinkInterval);
        }

        if (playerRenderer != null)
            playerRenderer.enabled = true;

        blinkRoutine = null;
    }

    public void LoseLifeFromEscapedEnemy()
    {
        if (isDead)
            return;

        currentLives--;
        Debug.Log($"En fjende slap igennem. Liv tilbage: {currentLives}");

        if (currentLives <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        if (blinkRoutine != null)
            StopCoroutine(blinkRoutine);

        if (playerRenderer != null)
            playerRenderer.enabled = true;

        Debug.Log("Spilleren har tabt.");

        // Midlertidig afslutning, indtil tabertilstanden og UI er klar.
        Time.timeScale = 0f;
    }

    private void OnDestroy()
    {
        // Sørger for, at Play ikke forbliver sat på pause.
        Time.timeScale = 1f;
    }
}
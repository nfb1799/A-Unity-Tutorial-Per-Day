using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5.9f;
    private float countdown = 2f;

    public Text waveCountdownText;

    private int waveIndex = 0;

    void Update()
    {
        // Spawns a wave every 5s using coroutines
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        // Updates the UI text
        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    // Spawns a certain number of enemies each wave with a 0.5s wait between
    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Spawns an enemy at the start point
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

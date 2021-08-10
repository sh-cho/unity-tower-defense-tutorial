using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float waveInterval = 5f;

    private float _countdown = 2f;
    private int _waveIndex = 0;

    private void Update()
    {
        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = waveInterval;
        }

        _countdown -= Time.deltaTime;
    }

    // --------------------------------------------------
    private IEnumerator SpawnWave()
    {
        ++_waveIndex;
        for (int i = 0; i < _waveIndex; ++i)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

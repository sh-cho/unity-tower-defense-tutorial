using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float waveInterval = 5.99f;
    [SerializeField] private Text waveCountDownText;

    private float _countdown = 2f;
    private int _waveIndex = 0;

    private void Update()
    {
        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = waveInterval;
        }

        waveCountDownText.text = $"{Mathf.Floor(_countdown)}";

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

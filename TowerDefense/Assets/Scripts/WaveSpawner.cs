using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text waveCountdownText;
    public Text waveNumber;

    private int waveIndex = 0;

    public Color finalColor = Color.red;

    void Start()
    {

    }

    void Update()
    {
        if(countdown <= 3.5f)
        {
            waveCountdownText.color = finalColor;
        }
        else{
            waveCountdownText.color = Color.white;
        }

        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            waveNumber.text = "Wave: " + waveIndex.ToString();
            countdown = timeBetweenWaves;
        }
        
        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        print("Wave Incomming!");

        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.7f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

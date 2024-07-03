using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyWavePrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval = 3f;

    private Queue<GameObject> enemyWaveQueue = new Queue<GameObject>();
    private int currentWave;
    private int enemyIndex;
    private float spawnTimer;

    [SerializeField] Grafo Grafo;

    void Start()
    {
        StartWave();
    }

    void StartWave()
    {
        currentWave++;
        Debug.Log("Starting wave " + currentWave);
        enemyIndex = 0;
        spawnTimer = 0f;
        SpawnEnemy();
    }

    void SpawnEnemy() //O(n) de tiempo asintotico
    {
        if (enemyIndex < enemyWavePrefabs.Length)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                GameObject enemyObject = Instantiate(enemyWavePrefabs[enemyIndex], spawnPoints[i].position, spawnPoints[i].rotation);
                Grafo.SelectionPath(enemyObject);
                enemyWaveQueue.Enqueue(enemyObject); 
            }
            enemyIndex++;
        }
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemy();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyWavePrefabs; 
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval = 3f;

    private SimplyLinkedList<GameObject> enemyWaveList = new SimplyLinkedList<GameObject>();
    private int currentWave;
    private int enemyIndex;
    private float spawnTimer;

    [SerializeField] MyGrafo Grafo; 

    void Start()
    {
        // Iniciar la primera oleada
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

    void SpawnEnemy()
    {
        if (enemyIndex < enemyWavePrefabs.Length)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                GameObject enemyObject = Instantiate(enemyWavePrefabs[enemyIndex], spawnPoints[i].position, spawnPoints[i].rotation);
                Grafo.SelectionPath(enemyObject);
                //Enemy1 enemy = enemyObject.GetComponent<Enemy>();
                enemyWaveList.AddNodeAtEnd(enemyObject);
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
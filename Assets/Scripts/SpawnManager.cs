using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject powerupPrefab;
    public int waveNumber = 1;
    public int enemyCount;
    private float spawnRange = 9.0f;
    public GameObject[] enemyPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        spawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }
    void spawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int prefabIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[prefabIndex], GenerateSpawnPosition(), enemyPrefabs[prefabIndex].transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            spawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}

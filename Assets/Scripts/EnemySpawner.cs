using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public spawners enemy;


    [SerializeField] private float countDown;
    public Wave[] waves;
    private int currentWaveIndex;

    [SerializeField] private bool waveSpawned = false;

    float placeHolder;

    private void Start()
    {
        placeHolder = 0;
    }

    private void Update()
    {
        placeHolder -= Time.deltaTime;

        if (!waveSpawned && placeHolder <= 0)
        {
            StartCoroutine(SpawnWave());
            waveSpawned = true;
        }
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waves[currentWaveIndex].numEnemies; i++)
        {
            //int spawnIndex = Random.Range(0, enemySpawnPoint.Count);
            int enemyToSpawn = Random.Range(0, 2);

            int enemyLocation = Random.Range(0, 2);

            enemyToSpawn = 1;
            if (enemyToSpawn == 0)
            {
                Instantiate(enemy.burgerPrefab, enemy.burgers[enemyLocation].position, Quaternion.identity);
                TheAudioManager.Instance.PlaySFX("SpawnEnemyBurger");
            }
            else
            {
                Instantiate(enemy.hotdogPrefab, enemy.hotdogs[enemyLocation].position, Quaternion.identity);
            }

            //GameObject newCustomer = Instantiate(enemyPrefabList[enemyToSpawn], enemySpawnPoint[spawnIndex].position, Quaternion.identity);
            yield return new WaitForSeconds(waves[currentWaveIndex].timingBetweenEnemies);
        }
        placeHolder = countDown;
    }

    [System.Serializable]
    public class Wave
    {
        public int numEnemies;
        public float timingBetweenEnemies;
    }

    [System.Serializable]
    public class spawners
    {

        public List<Transform> burgers;
        public GameObject burgerPrefab;

        //public List<Transform> fries;
        //public GameObject fryPrefab;

        public List<Transform> hotdogs;
        public GameObject hotdogPrefab;
    }
}

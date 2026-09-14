using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateSpawner : MonoBehaviour
{

    [SerializeField] private GameObject piratePrefab;
    [SerializeField] private float pirateInterval = 3.5f;

    [SerializeField] private Transform[] spawnPoints;

    public float minInterval = 0.5f;
    public float difficultyIncrease = 0.08f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(pirateInterval);

            int randomIndex = Random.Range(0, spawnPoints.Length);

            Transform spawnPoint = spawnPoints[randomIndex];

            Instantiate(piratePrefab, spawnPoint.position, Quaternion.identity);
        }
    }

    public void ReduceSpawnTime()
    {
        pirateInterval -= difficultyIncrease;

        if (pirateInterval < minInterval)
        {
            pirateInterval = minInterval;
        }
    }







































    /**
    [SerializeField] private GameObject piratePrefab;
    [SerializeField] private float pirateInterval = 3.5f;

    public float minInterval = 0.5f;
    public float difficultyIncrease = 0.1f;
    void Start()
    {
        StartCoroutine(spawnEnemy(pirateInterval, piratePrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject pirate)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(pirate, new Vector3(Random.Range(-7f, 7), Random.Range(-5f, 5f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, pirate));
    }

    public void ReduceSpawnTime()
    {
        pirateInterval -= difficultyIncrease;

        if (pirateInterval < minInterval)
        {
            pirateInterval = minInterval;
        }
    }
    **/
}

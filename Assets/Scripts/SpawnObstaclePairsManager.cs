using UnityEngine;

public class SpawnObstaclePairs : MonoBehaviour
{
    public GameObject[] ObstaclePrefabs;
    private float spawnRangeX = 5;
    private float spawnPosZ = 40;
    private float startDelay = 2f;
    private float spawnInterval = 0.75f;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomObstacle", startDelay, spawnInterval);
    }


    // Update is called once per frame
    void Update()
    {


    }
    void SpawnRandomObstacle()
    {
        int ObstacleIndex = Random.Range(0, ObstaclePrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(ObstaclePrefabs[ObstacleIndex], spawnPos, ObstaclePrefabs[ObstacleIndex].transform.rotation);
    }
    }

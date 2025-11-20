using UnityEngine;

public class SpawnLoneObstaclesManager : MonoBehaviour
{
    public GameObject[] ObstaclePrefabs;
    private float spawnRangeX = 0;
    private float spawnPosZ = 0;
    public float startDelay = 2f;
    public float spawnInterval = 1.5f;
    public bool gameOver = false;
    
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
        if (!gameOver)
        {
            int ObstacleIndex = Random.Range(0, ObstaclePrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            Instantiate(ObstaclePrefabs[ObstacleIndex], spawnPos, ObstaclePrefabs[ObstacleIndex].transform.rotation);
        }

    }
    }
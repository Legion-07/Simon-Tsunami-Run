using UnityEngine;
using System.Collections.Generic;

public class SpawnObstaclePairs : MonoBehaviour
{
    public GameObject[] ObstaclePrefabs;
    public List<int> Xpos = new List<int> { -3, 0, 3 };
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
        if (ObstacleIndex == 0)
        {
            Vector3 spawnPos = new Vector3(Xpos[Random.Range(0,3)], 1, spawnPosZ);
            Instantiate(ObstaclePrefabs[ObstacleIndex], spawnPos, ObstaclePrefabs[ObstacleIndex].transform.rotation);            
        }
        if (ObstacleIndex > 0)
        {
            Vector3 spawnPos = new Vector3(0, 0, spawnPosZ);
            Instantiate(ObstaclePrefabs[ObstacleIndex], spawnPos, ObstaclePrefabs[ObstacleIndex].transform.rotation);          
        }

        
    }
}

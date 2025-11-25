using UnityEngine;

public class RandomBuilding : MonoBehaviour
{
    public GameObject[] BuildingPrefabs;
    public GameObject Road;
    private float spawnPosZ = 135;
    private float leftX = -15;
    private float rightX = 14;
    public float ReSpawnTime = 2f;

    void Start()
    {
        InvokeRepeating("SpawnRoad", ReSpawnTime, ReSpawnTime);
        InvokeRepeating("SpawnBuilding", ReSpawnTime, ReSpawnTime);
    }

    void Update()
    {
        if (transform.position.z <= -50)
        {
            Destroy(gameObject);
        }
    }

    void SpawnBuilding()
    {
        int Leftindex = Random.Range(0, BuildingPrefabs.Length);
        int Rightindex = Random.Range(0, BuildingPrefabs.Length);
        Vector3 Left = new Vector3(leftX, 0, spawnPosZ);
        Instantiate(BuildingPrefabs[Leftindex], Left, BuildingPrefabs[Leftindex].transform.rotation);
        Vector3 Right = new Vector3(rightX, 0, spawnPosZ);
        Instantiate(BuildingPrefabs[Rightindex], Right, BuildingPrefabs[Rightindex].transform.rotation);
    }
    void SpawnRoad()
    {
            Instantiate(Road, new Vector3(0, 0, spawnPosZ), Quaternion.identity);
    }

}

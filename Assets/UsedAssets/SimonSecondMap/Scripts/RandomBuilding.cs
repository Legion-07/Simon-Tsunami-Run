using UnityEngine;

public class RandomBuilding : MonoBehaviour
{
    public GameObject[] BuildingPrefabs;
    public GameObject Road;
    private float spawnPosZ = 195;
    private float leftX = -15;
    private float rightX = 14;
    private float LeftrotationX = 90;
    private float RightrotationX = -90;
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
        int index = Random.Range(0, BuildingPrefabs.Length);
        Vector3 pos = new Vector3(leftX, 0, spawnPosZ);
        Instantiate(BuildingPrefabs[index], pos, BuildingPrefabs[index].transform.rotation);
    }
    void SpawnRoad()
    {
            Instantiate(Road, new Vector3(0, 0, spawnPosZ), Quaternion.identity);
    }

}

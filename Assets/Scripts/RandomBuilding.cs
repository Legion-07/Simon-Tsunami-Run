using UnityEngine;

public class RandomBuilding : MonoBehaviour
{
    
    public GameObject[] BuildingPrefabs;
    public GameObject Road;
    public int BuildingIndex;
    private float spawnRightRangeX = 14;
    private float spawnPosZ = 180;
    private float spawnLeftRangeX = -15;
    private float rotationLeft = 90;
    private float rotationRight = -90;
    void Start()
    {
        Vector3 spawnPossZ = new Vector3(0, 0, 215);
        Instantiate(Road, spawnPossZ, Road.transform.rotation);
    }

    void Update()
    {
        Vector3 LeftSpawn = new Vector3(spawnLeftRangeX, 0, spawnPosZ);
        int BuildingIndex = Random.Range(0, BuildingPrefabs.Length);
        Instantiate(BuildingPrefabs[BuildingIndex], LeftSpawn, BuildingPrefabs[BuildingIndex].transform.rotation);


    }
}

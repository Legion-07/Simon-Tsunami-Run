using UnityEngine;

public class StartUpHelper : MonoBehaviour
{
    public GameObject spawnManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 spawnPos = new Vector3(0,0,0);
        spawnManager.GetComponent<Constants>().speed = 5f;
        Instantiate(spawnManager, spawnPos, spawnManager.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private float backBound = -10;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < backBound)
        {
            Destroy(gameObject);
        }
    }
}
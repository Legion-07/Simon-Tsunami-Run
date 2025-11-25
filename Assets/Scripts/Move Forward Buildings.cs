using UnityEngine;

public class MoveForwardBuildings : MonoBehaviour

{
    public bool gameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 20f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }
    }
}

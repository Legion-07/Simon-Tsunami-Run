using UnityEngine;


public class MoveObjects : MonoBehaviour
{
    public float speed = 20f;
    public bool gameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
        transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
        }
    }
}
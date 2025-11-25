using UnityEngine;


public class MoveForward : MonoBehaviour
{
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
            transform.Translate(Vector3.back * Time.deltaTime * gameObject.GetComponent<Constants>().speed);
        }
    }
}
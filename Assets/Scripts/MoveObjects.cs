using Unity.VisualScripting;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    public GameObject gameManager;
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
        transform.Translate(Vector3.forward * Time.deltaTime * gameManager.GetComponent<Constants>().speed);
        }
    }
}

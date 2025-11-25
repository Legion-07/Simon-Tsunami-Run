using Unity.VisualScripting;
using UnityEngine;
public class RepeatBackground : MonoBehaviour
// IGNORE THIS ENTIRE SCRIPT
{
    private Vector3 startPos;
    private float repeatWidth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            Debug.Log("Repeat");
            transform.position = startPos;
        }
    }
}
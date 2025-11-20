using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SlowPlayer : MonoBehaviour
{
    public GameObject gameManager;
    public bool IsSlow = false;
    
    private float SlowTimeLeft = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSlow)
        {
            SlowTimeLeft -= Time.deltaTime;
            if (SlowTimeLeft <= 0)
            {
                IsSlow = false;
                gameManager.GetComponent<Constants>().speed = 5f;
                SlowTimeLeft = 5f;
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision detected");
            gameManager.GetComponent<Constants>().speed = 0.2f;
            IsSlow = true;
        }
    }
}

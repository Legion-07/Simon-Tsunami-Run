using UnityEngine;


public class SlowPlayer : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject Wave;
    public bool IsSlow = false;
   
    private float SlowTimeLeft = 5f;
    public float SecondaryWaveSpawnX = -2.0f;


    public float DeathWaveSpawnX = 0.0f;
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
            if(!GameObject.FindGameObjectWithTag("Wave"))
            {
                Instantiate (Wave, new Vector3 (SecondaryWaveSpawnX,0,0), transform.rotation);
            }
           
            if (SlowTimeLeft <= 0)
            {
                IsSlow = false;
                gameManager.GetComponent<Constants>().speed = 5f;
                SlowTimeLeft = 5f;
                GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Wave");
                foreach (GameObject obj in objectsToDestroy)
                {
                    Destroy(obj);
                }
            }
        }
    }
   
    private void OnTriggerEnter(Collider collision)
    {
       
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision detected");
            Destroy(collision.gameObject);
            gameManager.GetComponent<Constants>().speed = 0.2f;
            IsSlow = true;
            if (collision.gameObject.CompareTag("Obstacle") && IsSlow)
            {
                GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Wave");
                foreach (GameObject obj in objectsToDestroy)
                {
                    Destroy(obj);
                }
                Debug.Log("Spawned a new wave at:"+ SecondaryWaveSpawnX);
                Instantiate (Wave, new Vector3 (DeathWaveSpawnX,0,0), transform.rotation);
            }
        }
    }
}

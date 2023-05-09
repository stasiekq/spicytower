using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject zaphire;
    public bool hasGround = false;
    

    // Start is called before the first frame update
    void Start()
    {
        float offset = GenerateRandomFloat(0.0f, 3.8f);
        //Instantiate(groundPrefab, new Vector3(offset, transform.position.y, 0), Quaternion.identity);
        InvokeRepeating("SpawnGround", 0f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        // if(!hasGround)
        // {
        //     SpawnGround();
        //     hasGround = true;
        // }
        //spawn ground every 2 seconds

    }

    public void SpawnGround()
    {
        if (true)
        {
            float offset = GenerateRandomFloat(0.0f, 4.3f);
            Instantiate(groundPrefab, new Vector3(offset, transform.position.y, 0), Quaternion.identity);
            //if(GenerateRandomFloat(0.0f, 1.0f) > 0.5f)
            // {
            //     Instantiate(zaphire, new Vector3(GenerateRandomFloat(0.0f, 4.3f) - 3.1f, transform.position.y - 2.5f, 0), Quaternion.identity);
            // }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            hasGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasGround = false;
        }
    }

    private float GenerateRandomFloat(float min, float max) {
        return UnityEngine.Random.Range(min, max);
    }
}

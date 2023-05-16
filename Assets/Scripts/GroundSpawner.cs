using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject zaphire;
    public FollowPlayer followPlayer;
    public GameObject wall2;
    public GameObject wall1;
    public bool hasGround = false;
    private float previousOffset;
    private float offset;

    
    private GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        wall = wall1;
        previousOffset = GenerateRandomFloat(0.0f, 4.3f);
        //Instantiate(groundPrefab, new Vector3(previousOffset, transform.position.y - 1, 0), Quaternion.identity);
        //InvokeRepeating("SpawnGround", 3f, 2.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasGround){
            SpawnGround();
            hasGround = true;
        }
    }

    public void SpawnGround()
    {
        previousOffset = offset;
        offset = GenerateRandomFloat(0.0f, 4.3f);
        if(offset - previousOffset < 1 && offset - previousOffset > -1)
        {
            offset = GenerateRandomFloat(0.0f, 4.3f);
            previousOffset = offset;

        }
        Instantiate(groundPrefab, new Vector3(offset, transform.position.y, 0), Quaternion.identity);
        //if(GenerateRandomFloat(0.0f, 1.0f) > 0.5f)
        if(true)
        {
            //Instantiate(zaphire, new Vector3(GenerateRandomFloat(0.0f, 4.3f) - 3.1f, transform.position.y - 2.5f, 0), Quaternion.identity);
        }
        if(followPlayer.maxSpeed == true)
        {
            if (GenerateRandomFloat(0.0f, 1.0f) > 0f)
            {
                float wallOffset = GenerateRandomFloat(-3f, 3f);
                if(!(wallOffset - offset > -3f && wallOffset - offset < -1.2f) && !(wallOffset - previousOffset > -3f && wallOffset - previousOffset < -1.2f))
                {
                    Instantiate(wall, new Vector3(wallOffset, transform.position.y - 1.6f, 0), Quaternion.identity);
                }
                else
                {
                    wallOffset = GenerateRandomFloat(-3f, 3f);
                    if(!(wallOffset - offset > -3f && wallOffset - offset < -1.2f) && !(wallOffset - previousOffset > -3f && wallOffset - previousOffset < -1.2f))
                    {
                        Instantiate(wall, new Vector3(wallOffset, transform.position.y - 1.6f, 0), Quaternion.identity);
                    }
                }
            }
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

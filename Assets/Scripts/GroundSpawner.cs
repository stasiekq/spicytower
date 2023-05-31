using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject zaphire;
    public GameObject emerald;
    public GameObject ruby;
    public FollowPlayer followPlayer;
    public GameObject wall1;
    public GameObject enemy;
    public bool hasGround = false;
    public float previousOffset;
    public float offset;
    public float wallOffset;

    
    private GameObject collectible;
    private GameObject wall;
    public GameObject wall_hole;

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
        if(offset - previousOffset < 1.5f && offset - previousOffset > -1.5f)
        {
            offset = GenerateRandomFloat(0.0f, 4.3f);
            if(offset - previousOffset < 1.5f && offset - previousOffset > -1.5f)
            {
                offset = GenerateRandomFloat(0.0f, 4.3f);
            }   

        }
        Instantiate(groundPrefab, new Vector3(offset, transform.position.y, 0), Quaternion.identity);
        
        if(followPlayer.maxSpeed == true)
        {
            float los = GenerateRandomFloat(0.0f, 1.0f);
            if (los > 0f)
            {
                if(los > 0.3)
                {
                    Instantiate(enemy, new Vector3(GenerateRandomFloat(-3f, 3f), transform.position.y - 1.6f, 0), Quaternion.identity);
                }

                if(los > 0.8f)
                {
                    wall = wall_hole;
                }
                else
                {
                    wall = wall1;
                }

                wallOffset = GenerateRandomFloat(-3f, 3f);
                if(!(wallOffset - offset > -3f && wallOffset - offset < -1.2f) && !(wallOffset - previousOffset > -3f && wallOffset - previousOffset < -1.2f))
                {
                    Instantiate(wall, new Vector3(wallOffset, transform.position.y - 1.6f, 0), Quaternion.identity);
                }
                else
                {
                    wallOffset += 1.4f;
                    if(wallOffset > 3f)
                    {
                        wallOffset -= 3f;
                    }
                    if(!(wallOffset - offset > -3f && wallOffset - offset < -1.2f) && !(wallOffset - previousOffset > -3f && wallOffset - previousOffset < -1.2f))
                    {
                        Instantiate(wall, new Vector3(wallOffset, transform.position.y - 1.6f, 0), Quaternion.identity);
                    }
                }
            }

            if(GenerateRandomFloat(0.0f, 1.0f) > 0.2f)
            {
                float collectibleOffset = GenerateRandomFloat(-3f, 3f);
                if(wallOffset - collectibleOffset > -0.4f && wallOffset - collectibleOffset < 0.4f)
                {
                    collectibleOffset -= 0.4f;
                }
                float rareness = GenerateRandomFloat(0.0f, 1.0f);
                if(rareness > 0.9f)
                {
                    collectible = ruby;
                }
                else if(rareness > 0.6f)
                {
                    collectible = emerald;
                }
                else
                {
                    collectible = zaphire;
                }
                Instantiate(collectible, new Vector3(GenerateRandomFloat(-3f, 3f), transform.position.y - 1.6f, 0), Quaternion.identity);
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

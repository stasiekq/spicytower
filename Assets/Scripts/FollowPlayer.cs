using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    public Vector3 offset;
    float overrider  = 0.002f;
    int iterator = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + overrider, transform.position.z);

        iterator++;
        if(overrider < 0.005f && iterator == 10) 
        {
            overrider += 0.00001f;
            iterator = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    public Vector3 offset;
    public float camSpeed  = 0.004f;
    int iterator = 0;
    public bool maxSpeed = true;
    public bool sraka = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + camSpeed, transform.position.z);

        iterator++;
        if(camSpeed < 0.008f && iterator == 10) 
        {
            camSpeed += 0.00001f;
            iterator = 0;
        }
        else if(camSpeed >= 0.008f)
        {
            maxSpeed = true;
        }
    }
}

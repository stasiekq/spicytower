using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    public bool hasGround = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.CompareTag("Ground"))
        // {
        //     hasGround = true;
        //     Destroy(collision.gameObject);
        // } else
        // {
        //     hasGround = false;
        // }
        if(collision.gameObject != null)
        {
            
        Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb2d;
    private float runSpeed = 2f;
    public GameObject mainCamera;
    public static int touchingPlayer = 0;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        //make enemy walk and switch sides every 3 seconds
        InvokeRepeating("SwitchSides", 0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
        //make player appear on the other side of the screen when he leaves it
        if (transform.position.x > mainCamera.transform.position.x + 3.1f)
        {
            transform.position = new Vector3(mainCamera.transform.position.x - 3.1f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < mainCamera.transform.position.x - 3.1f)
        {
            transform.position = new Vector3(mainCamera.transform.position.x + 3.1f, transform.position.y, transform.position.z);
        }
        //turn around when touching wall

    }

    private void SwitchSides()
    {
        runSpeed *= -1;
        //flip enemy sprite
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            SwitchSides();
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            SwitchSides();
        }
        if(collision.gameObject.CompareTag("Player"))
        {
            touchingPlayer++;
        }
    }
}

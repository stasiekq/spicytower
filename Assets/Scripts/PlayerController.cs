using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb2d;
    private float runSpeed = 2.4f;
    public int jumpCount = 0;
    public GameObject mainCamera;
    public int headBumpCount = 0;

    public int zFound = 0;
    public int eFound = 0;
    public int rFound = 0;

    bool flipped = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
        }   
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && jumpCount < 2000)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 6);
            jumpCount++;
        }

        if (rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (2.5f - 1) * Time.deltaTime;
        }

        flipped = rb2d.velocity.x < 0;
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));

        //make player unable to leave the screen
        if (transform.position.y > mainCamera.transform.position.y + 5.2f)
        {
            transform.position = new Vector3(transform.position.x, mainCamera.transform.position.y + 5, transform.position.z);
            //stop player from moving up if he reaches the top of the screen and make him move down
            rb2d.velocity = new Vector2(rb2d.velocity.x, -0.2f);
            headBumpCount++;
        }

        //make player appear on the other side of the screen when he leaves it
        if (transform.position.x > mainCamera.transform.position.x + 3.1f)
        {
            transform.position = new Vector3(mainCamera.transform.position.x - 3.1f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < mainCamera.transform.position.x - 3.1f)
        {
            transform.position = new Vector3(mainCamera.transform.position.x + 3.1f, transform.position.y, transform.position.z);
        }
        


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ruby")
        {
            rFound++;
        }
        if (collision.gameObject.name == "Zaphire")
        {
            zFound++;
        }
        if (collision.gameObject.name == "Emerald")
        {
            eFound++;
        }
    }
}

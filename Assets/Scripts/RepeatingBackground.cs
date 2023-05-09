using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{

    public GameObject mainCamera;
    public float parallaxEffect;
    private float height, positionY;

    // Start is called before the first frame update
    void Start()
    {
        height = GetComponent<SpriteRenderer>().bounds.size.y;
        positionY = transform.position.y;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        float parallaxDistance = mainCamera.transform.position.y * parallaxEffect;
        float remainingDistance = mainCamera.transform.position.y * (1-parallaxEffect);

        transform.position = new Vector3(transform.position.x, positionY + parallaxDistance, transform.position.z);

        if (remainingDistance > positionY + height)
        {
            positionY += height;
        }
    }
}

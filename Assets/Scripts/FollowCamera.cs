using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    private GameObject mainCamera;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        offset = transform.position - mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, mainCamera.transform.position.y + offset.y, transform.position.z);
    }
}

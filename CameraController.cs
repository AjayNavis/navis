using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //PRIVATE
    private Transform look;
    private Vector3 startOffset;

    // Start is called before the first frame update
    void Start()
    {
       look = GameObject.FindGameObjectWithTag("Player").transform;
       startOffset = transform.position - look.position; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = look.position + startOffset;
    }
}

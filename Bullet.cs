using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //GLOBAL
    private GameObject enemy;

    private void OnCollisionEnter(Collision collision)     //COLLISIION
    {
        
        if(collision.collider.CompareTag("Player")) 
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)               //TRIGGERS
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); 
        }
    }
}

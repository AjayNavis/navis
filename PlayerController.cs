using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //PRIVATE
    private CharacterController controller;
    private Vector3 moveForward;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    //GLOBAL
    public float moveSpeed;
    public float sideMoveSpeed;
    public float bulletspeed;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public GameObject gameOverPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveForward = Vector3.zero;

        if(controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity*Time.deltaTime;
        }

        moveForward.x = Input.GetAxisRaw("Horizontal") *sideMoveSpeed;    
        moveForward.y = verticalVelocity;
        moveForward.z = moveSpeed;
        
        controller.Move(moveForward*Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Mouse0))                                   //SPAWNBULLETS
        {
            var bullet = Instantiate(bulletPrefab,bulletSpawn.position,bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletspeed;
        }
    }

    private void OnTriggerEnter(Collider other)                      //TRIGGERS
    {
        if (other.CompareTag("Enemy"))
        {
            gameOverPanel.SetActive(true);
        }
    }
}

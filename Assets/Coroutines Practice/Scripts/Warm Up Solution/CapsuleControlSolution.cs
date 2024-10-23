using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleControlSolution : MonoBehaviour
{
    //VARIABLES

    [Header("Movement")]
    public float moveSpeed;
    public float turnSpeed;
    public float jumpForce;
    public bool isOnGround = true;
    private float verticalInput;
    private float horizontalInput;
    private Rigidbody rb;

    [Header("Shooting")]
    public GameObject projectile;
    public GameObject spawnPoint;
    public float shootDelay;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Forward and Backward Movement
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * moveSpeed * verticalInput * Time.deltaTime);



        //Clockwise and counterclockwise Rotation
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);



        //Jumping
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false; 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }



        //Shooting
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}

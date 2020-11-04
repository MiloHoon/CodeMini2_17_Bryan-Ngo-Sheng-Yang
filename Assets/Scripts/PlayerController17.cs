using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController17 : MonoBehaviour
{
    // Declare and Initialise variables
    float speed = 10.0f;

    float gravityModifier = 2.5f;
    int jumpTimes = 0;
    bool onGround = false;

    Rigidbody playerRb;

    public GameObject MoveCube;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Declare and In it variables to reference to User Interaction inputs
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move Player (GameObject) according to user interactions
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        JumpPlayer();
    }

    // Jump Code
    private void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpTimes < 2)
        {
            playerRb.AddForce(Vector3.up * 8, ForceMode.Impulse);

            // Track my jump if single jump or double jump
            jumpTimes++;
        }
    }

    // Event Listener for a collision by the GameObject "Player" with another possible GameObject
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpTimes = 0;
        }

        if (collision.gameObject.CompareTag("MoveCube"))
        {
            jumpTimes = 0;
        }
    }
}
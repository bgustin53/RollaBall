using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*****************************************
 * This script will control both the
 * player actions and the UI
 * 
 * Author: Bruce Gustin
 * December 11, 2022
 ****************************************/

public class PlayerController : MonoBehaviour
{
    // PlayerController properties
    private Rigidbody rb;               // Allows for use of physics
    private int count;                  // Holds the number of collectibles that have been picked up
    private float movementX;            // Holds forwars/backward component of movement vector
    private float movementY;            // Holds left/right component of movement vector

    private float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    // Gets keypresses from Input Actions and applies it to the Player Movement
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }


    // Displays pickup count and end game message to the screen


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
        }
    }

    // Detects collisions with pickups and counts them
}

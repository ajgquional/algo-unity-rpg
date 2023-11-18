/* **************************************************
 * Author: 
 *      Adrian Josele G. Quional
 * 
 * Program description: 
 *      This program implements the operation of the
 *      arrow:
 *          - continuously move in a straight line
 *              after being shot from the crossbow
 *          - reduce the health of the enemy object
 *              when the enemy object is touched
 *          - destroy itself at the beginning of
 *              the game and after hitting an enemy
 * 
 * How to use the script:
 *      - Setup the arrow first
 *          - reduce its size
 *          - set "Sorting Layer" to "Items"
 *          - set "Order in Layer" to 2
 *          - add a Rigidbody 2D component (Body Type
 *              should be Kinematic and Simulated
 *              should be checked)
 *          - add a BoxCollider 2D (or CapsuleCollider)
 *              component, edit the size, and check the 
 *              IsTrigger property
 *      - Attach the script to the arrow object
 *      - Setup the enemy next
 * **************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // default speed of the arrow (can be changed via the Inspector window)
    public float speed = 3;

    // destroy the arrow at the beginning of the game, with a delay of 3 secs
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // continuously move the arrow after it spawns from the crossbow
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime; 
    }

    // handles the collision between the arrow and the enemy
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if the object touched upon by the arrow, get the Enemy component (script) of the object
        // then execute the TakeDamage() method of the enemy
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.TakeDamage();
        }

        // destroy the arrow after hitting the enemy
        Destroy(gameObject);
    }
}

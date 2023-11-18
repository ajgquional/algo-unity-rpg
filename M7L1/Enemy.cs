/* **************************************************
 * Author: 
 *      Adrian Josele G. Quional
 * 
 * Program description: 
 *      This program implements the operation of the
 *      enemy. This initial version of the script only
 *      assigns a health value to the enemy, and
 *      declares a method to reduce the enemy's health.
 * 
 * How to use the script:
 *      - Setup the enemy first
 *          - put the enemy anywhere in the level
 *          - set "Sorting Layer" to "Items"
 *          - set "Order in Layer" to 0
 *          - add a BoxCollider 2D component and edit 
 *              the size
 *      - Attach the script to the enemy object
 * **************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // default health of the enemy (can be changed via the Inspector window)
    public int health = 5;

    // method to handle reduction in the enemy's health when the enemy is hit by an arrow
    public void TakeDamage()
    {
        // reduce enemy's health by 1
        health -= 1;

        // if health goes down to 0, destroy the enemy
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

/* **************************************************
 * Author: 
 *      Adrian Josele G. Quional
 * 
 * Description: 
 *      Implements the operation of the enemy:
 *          - assigns a health value to the enemy
 *          - reduces the enemy's health when hit by an arrow
 *          - destroys the enemy when health reaches 0
 * 
 * How to use:
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

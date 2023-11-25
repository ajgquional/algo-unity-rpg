/* **************************************************
 * Author: 
 *      Adrian Josele G. Quional
 * 
 * Program description: 
 *      This program implements the operation of the
 *      cornfield border.
 * 
 * How to use the script:
 *      - Create an empty cornfield border object
 *      - Attach the script to the border object
 * **************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corn : MonoBehaviour
{
    // creating a static variable named "singleton"
    public static Corn singleton;

    // initializing the health of the cornfield to 10 (can be changed via the Inspector window)
    public int health = 10;

    // before the game even starts, create a static instance of the Corn class
    private void Awake()
    {
        // creating a static instance of the Corn class
        singleton = this;
    }

    // method to handle the reduction on the cornfield's health when the enemy attacks it
    // to be accessed by the Enemy script
    public void TakeDamage()
    {
        // reduce the health of the cornfield when the enemy attacks it
        health -= 1;
    }
}

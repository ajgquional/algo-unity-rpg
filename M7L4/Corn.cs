/* ****************************************************************************************************
 * AUTHOR: 
 *      Adrian Josele G. Quional
 * ====================================================================================================
 * SCRIPT DESCRIPTION: 
 *      This script implements the operation of the cornfield border. 
 * ====================================================================================================
 * VERSIONS:
 *      -   Version 1:  Initialized health and implementated how to take damage.
 *      -   Version 2:  Supressed further damage to the cornfield when its health falls below zero.
 *      -   Version 3:  Implemented a cornfield health improvement mechanism using crystals gained by 
 *                      killing enemies.
 * ====================================================================================================
 * HOW TO USE THE SCRIPT:
 *      -   Create an empty cornfield border object                                     [for Version 1]
 *      -   Attach the script to the border object                                      [for Version 1]
 *      -   Create a GameController class with the SaveCrystals() method                [for Version 3]
 * ****************************************************************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corn : MonoBehaviour
{
    public static Corn singleton;   // creating a static variable named "singleton"
    public int health = 10;         // initializing the health of the cornfield to 10 (can be changed via the Inspector window)
    public int crystals = 0;        // initializing the number of crystals which the player earns when defeating enemies

    public int initHealth;          // health at the beginning of the game (eventually overrides the health variable)
    public int healthPerUpgrade;    // how much the health level increases when it's upgraded

    // before the game even starts, create a static instance of the Corn class
    private void Awake()
    {
        // creating a static instance of the Corn class
        singleton = this;

        // gets the saved number of crystals
        crystals = PlayerPrefs.GetInt("crystals", 0);

        // calculating the health level of the field before the start of each game level
        int healthBonus = healthPerUpgrade * PlayerPrefs.GetInt("healthGrade", 0);
        health = initHealth + healthBonus;
    }

    // method to handle the reduction on the cornfield's health when the enemy attacks it
    // to be accessed by the Enemy script
    public void TakeDamage()
    {
        // the cornfield would only take damage when health > 0
        if (health > 0)
        {
            // reduce the health of the cornfield when the enemy attacks it
            health -= 1;
        }
    }

    // executed when enemies are destroyed
    public void AddCrystals(int newCrystals)
    {
        // increment the number of crystals when an enemy is destroyed, depending on the "price" of an enemy
        // then saves the updated amount of crystals
        crystals += newCrystals;
        GameController.SaveCrystals();
    }

    // executed during upgrades
    public void DecCrystals(int crystalsSpent)
    {
        // decrements the number of crystals when it is spent on an upgrade
        // then saves the updated amount of crystals
        crystals -= crystalsSpent;
        GameController.SaveCrystals();
    }
}

/* ****************************************************************************************************
 * AUTHOR: 
 *      Adrian Josele G. Quional
 * ====================================================================================================
 * SCRIPT DESCRIPTION: 
 *      This script controls the display of the cornfield's health during the game. 
 * ====================================================================================================
 * VERSIONS:
 *      -   Version 1:  Implemented the continuous display of the cornfield's health.
 * ====================================================================================================
 * HOW TO USE THE SCRIPT:
 *      -   Attach the script to the Health object of the HUD belonging to the 
 *          GameCanvas object                                                           [for Version 1]
 *      -   Pass the text of the Health object to the Health Text field of the
 *          HealthUI component of the Health object                                     [for Version 1]  
 * ****************************************************************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // used to work with UI

public class HealthUI : MonoBehaviour
{
    public Text healthText; // reference to the health text (the text to be updated)

    // continuously update the display of the health text on top of the player's screen
    void Update()
    {
        // gets the health value of the cornfield then converts it to string before displaying the value
        healthText.text = Corn.singleton.health.ToString();
    }
}

/* ****************************************************************************************************
 * AUTHOR: 
 *      Adrian Josele G. Quional
 * ====================================================================================================
 * SCRIPT DESCRIPTION: 
 *      This script controls the display of the current level of the game. 
 * ====================================================================================================
 * VERSIONS:
 *      -   Version 1:  Implemented the continuous display of the current level.
 * ====================================================================================================
 * HOW TO USE THE SCRIPT:
 *      -   Attach the script to the Level object of the HUD belonging to the 
 *          GameCanvas object                                                           [for Version 1]
 *      -   Pass the text of the Level object to the Level Text field of the
 *          LevelUI component of the Level object                                       [for Version 1]  
 * ****************************************************************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // used to work with UI

public class LevelUI : MonoBehaviour
{
    public Text levelText; // reference to the level text (the text to be updated)

    // continuously update the display of the level text on top of the player's screen
    void Update()
    {
        // gets the level value from the LevelController then converts it to string before displaying the value
        levelText.text = LevelController.level.ToString();
    }
}

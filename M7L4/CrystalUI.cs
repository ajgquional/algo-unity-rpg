/* ****************************************************************************************************
 * AUTHOR: 
 *      Adrian Josele G. Quional
 * ====================================================================================================
 * SCRIPT DESCRIPTION: 
 *      This script controls the display of the number of crystals gained by the player after defeating
 *      the enemies. 
 * ====================================================================================================
 * VERSIONS:
 *      -   Version 1:  Implemented the continuous display of the number of crystals.
 * ====================================================================================================
 * HOW TO USE THE SCRIPT:
 *      -   Attach the script to the Crystal object of the HUD belonging to the 
 *          GameCanvas object                                                           [for Version 1]
 *      -   Pass the text of the Crystal object to the Crystal Text field of the
 *          CrystalUI component of the Crystal object                                   [for Version 1]  
 * ****************************************************************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // used to work with UI

public class CrystalUI : MonoBehaviour
{
    public Text crystalText; // reference to the crystal text (the text to be updated)

    // continuously update the display of the number of crystals on top of the player's screen
    void Update()
    {
        // gets the crystal value stored in the cornfield then converts the value to string before displaying the value
        crystalText.text = Corn.singleton.crystals.ToString();
    }
}

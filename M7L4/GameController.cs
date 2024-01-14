/* ****************************************************************************************************
 * AUTHOR: 
 *      Adrian Josele G. Quional
 * ====================================================================================================
 * SCRIPT DESCRIPTION: 
 *      This script controls saving and resetting of in-game data. 
 * ====================================================================================================
 * VERSIONS:
 *      -   Version 1:  Implemented the saving and clearing of the saves, saving and clearing of the 
 *                      display of the number of crystals, as well as the saving and clearing of the
 *                      health upgrade.
 * ====================================================================================================
 * HOW TO USE THE SCRIPT:
 *      -   Attach the script to the GameCanvas object                                  [for Version 1] 
 * ****************************************************************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // executed when the player wins a level (i.e. the level achieved is automatically saved)
    public static void SaveLevel()
    {
        PlayerPrefs.SetInt("level", LevelController.level); // saving the level achieved by the player
    }

    // executed if the player chooses to delete his/her saves
    public static void ClearLevel()
    {
        PlayerPrefs.SetInt("level", 1); // resets the level back to 1
    }

    // clears the levels achieved and the number of crystals earned if the player wishes to clear the saves 
    public void ClearSave()
    {
        ClearLevel();
        ClearCrystals();
    }

    // saves the number of crystals earned by the player
    public static void SaveCrystals()
    {
        PlayerPrefs.SetInt("crystals", Corn.singleton.crystals);
    }

    // resets the number of crystals earned by the player
    public static void ClearCrystals()
    {
        PlayerPrefs.SetInt("crystals", 0);
    }

    // saves the number of health upgrades
    public static void SaveHealthGrade()
    {
        PlayerPrefs.SetInt("healthGrade", UpgradeController.healthGrade);
    }

    // resets the number of health upgrades
    public static void ClearHealthGrade()
    {
        PlayerPrefs.SetInt("healthGrade", 0);
    }
}

/* ****************************************************************************************************
 * AUTHOR: 
 *      Adrian Josele G. Quional
 * ====================================================================================================
 * SCRIPT DESCRIPTION: 
 *      This script controls all upgrades in the game. 
 * ====================================================================================================
 * VERSIONS:
 *      -   Version 1:  Implemented a health upgrade mechanism.
 * ====================================================================================================
 * HOW TO USE THE SCRIPT:
 *      -   Attach the script to the UpgradePanel object of the GameStatus 
 *          belonging to the GameCanvas object                                          [for Version 1] 
 *      -   Input a Health Grade Price and pass the text of the Message object
 *          belonging to the UpgradePanel object to the Health Grade Price Text
 *          field of the UpgradeController component                                    [for version 1]
 *      -   Ensure that when the UPGRADE button of the PassedPanel and DefeatPanel
 *          is clicked, the UpgradePanel will show and the PassedPanel and
 *          DefeatPanel will hide
 *              GameCanvas -> GameStatus -> PassedPanel -> Upgrade                      
 *              GameCanvas -> GameStatus -> DefeatPanel -> Upgrade                      [for Version 1]
 *      -   Ensure that when the shield icon button (corresponding a health upgrade)
 *          of the UpgradePanel is clicked, the OnClickUpgradeHealth() method is
 *          executed
 *              GameCanvas -> GameStatus -> UpgradePanel -> Health                      [for Version 1]   
 * ****************************************************************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // used to work with UI

public class UpgradeController : MonoBehaviour
{
    public int healthGradePrice;        // cost of upgrade
    public static int healthGrade;      // number of times the player has used the upgrade

    public Text healthGradePriceText;   // reference to the text containing the cost of the upgrade

    // displays the price of the upgrade on the screen
    void Update()
    {
        // gets the cost of the upgrade then converts the value to string before displaying the value
        healthGradePriceText.text = healthGradePrice.ToString();
    }

    // once the shield icon in the Upgrade Panel is clicked, execute the health upgrade
    // if the number of crystals is greater than the cost of the health upgrade   
    public void OnClickUpgradeHealth()
    {
        // if the number of crystals (stored in the cornfield) is greater than the cost of health upgrade,
        // implement the health upgrade
        if(Corn.singleton.crystals >= healthGradePrice)
        {
            healthGrade = PlayerPrefs.GetInt("healthGrade", 0); // get the current number of uses of the upgrade
            healthGrade += 1;                                   // increase the number of uses of the upgrade by 1
            GameController.SaveHealthGrade();                   // save the received value

            Corn.singleton.DecCrystals(healthGradePrice);       // decrease the amount of crystals according to the cost of upgrade
        }
    }
    
}

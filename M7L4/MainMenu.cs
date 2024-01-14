/* ****************************************************************************************************
 * AUTHOR: 
 *      Adrian Josele G. Quional
 * ====================================================================================================
 * SCRIPT DESCRIPTION: 
 *      This script implements the operation of the Main Menu Scene, allowing the transfer between the
 *      said scene and the Game Scene. 
 * ====================================================================================================
 * VERSIONS:
 *      -   Version 1:  Implemented the transfer between from the Main Menu Scene to the Game Scene when 
 *                      the PLAY button in the Main Menu Scene is clicked. Exiting the game (by clicking
 *                      the EXIT button) has also been implemented.
 * ====================================================================================================
 * HOW TO USE THE SCRIPT:
 *      -   Set up the Main Menu Scene                                                  [for Version 1]
 *      -   Attach the script to the MainMenuCanvas object of the Main Menu Scene       [for Version 1]
 *      -   Specify (in the Inspector Window) the scene to transfer to                  [for Version 1]
 *      -   Ensure that when the PLAY button is clicked, the OnClickPlay() method
 *          is executed 
 *              MainMenuCanvas -> MainPanel -> ButtonPlay                               [for Version 1]                                  
 *      -   Ensure that when the EXIT button is clicked, the OnClickExit() method
 *          is executed         
 *              MainMenuCanvas -> MainPanel -> ButtonExit                               [for Version 1]    
 * ****************************************************************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // used to work with scenes

public class MainMenu : MonoBehaviour
{
    public string sceneName; // reference to the scene to transfer to when the PLAY button is clicked

    // executed when the PLAY button is clicked
    public void OnClickPlay()
    {
        // transfer to the specified scene
        SceneManager.LoadScene(sceneName);
    }

    // executed when the EXIT button is clicked
    public void OnClickExit()
    {
        // quit the application
        Application.Quit();
    }
}

/* ****************************************************************************************************
 * AUTHOR: 
 *      Adrian Josele G. Quional
 * ====================================================================================================
 * SCRIPT DESCRIPTION: 
 *      This script controls the operation of each level. 
 * ====================================================================================================
 * VERSIONS:
 *      -   Version 1:  Implemented the check if the player has won or lost, and the increase in the 
 *                      difficulty of the next level when the player has won the current level.
 *      -   Version 2:  Implemented the appearance of UI panels depending on the status of the game 
 *                      (i.e. whether the player has won or lost the level). Also, the restart of the 
 *                      level when the PLAY/START button is clicked, and the return to the Main Menu
 *                      when the MENU button is clicked, has been implemented. Lastly, the retrieval
 *                      (and saving) of the player's progress is implemented.
 * ====================================================================================================
 * HOW TO USE THE SCRIPT:
 *      -   Attach the script to the Level object                                       [for Version 1]
 *      -   Pass the "PassedPanel" and the "DefeatPanel" to the Victory Panel and
 *          Defeat Panel fields of the Level Controller component (seen in the 
 *          Inspector Window) of the Level object                                       [for Version 2]
 *      -   Ensure that when the PLAY button of the PassedPanel, or the START 
 *          button of the DefeatPanel, is clicked, the RestartLevel() method 
 *          is executed 
 *              GameCanvas -> GameStatus -> PassedPanel -> Play 
 *              GameCanvas -> GameStatus -> DefeatPanel -> Start                        [for Version 2]                                  
 *      -   Ensure that when the MENU button of both the PassedPanel and the 
 *          DefeatPanel is clicked, the LoadMenu() method is executed
 *              GameCanvas -> GameStatus -> PassedPanel -> Menu 
 *              GameCanvas -> GameStatus -> DefeatPanel -> Menu                         [for Version 2]    
 * ****************************************************************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // used to work with scenes

public class LevelController : MonoBehaviour
{
    public Spawner spawner;                 // link to the spawner object in the scene
    public static bool finished = false;    // status of the game level (false = not yet finished, true = finished)
    public static int level = 1;            // value of the game level

    public GameObject victoryPanel;         // reference to the win panel
    public GameObject defeatPanel;          // reference to the defeat panel

    // gets the level that the player achieved in the past
    // in this way, when the player plays again, his progress is continued
    private void Awake()
    {
        // getting the level achieved by the player in previous gameplays
        // if the player started the game for the first time, the default level is 1
        level = PlayerPrefs.GetInt("level", 1);
    }

    // resets the status of the game level to "false" every time a new level commences
    private void Start()
    {
        finished = false;
    }

    // continuously check (every frame) for the player's victory or defeat, as long as the game is not yet finished
    private void Update()
    {
        if (finished == false)
        {
            Check();
        }
    }

    // checks whether the player has lost or won
    public void Check()
    {
        // executes Victory() only if the spawnCounter goes down to zero
        // and there are no enemies left in the scene
        if (spawner.spawnCounter <= 0)
        {
            // gets all of the current enemies within the scene and store them in an array
            Enemy[] enemies = FindObjectsOfType<Enemy>();

            // checks if the number of enemies in the scene is zero
            // this is done so by checking the number of elements (length) in the enemies array
            // if there are no enemies left, the player wins the level
            if (enemies.Length <= 0)
            {
                Victory();
            }
        }

        // if the cornfield's health is reduced to zero, the player loses the level
        if (Corn.singleton.health <= 0)
        {
            Defeat();
        }
    }

    // triggered in a player victory situation
    public void Victory()
    {
        finished = true;                // setting the status of the game to "finished" when the player wins the current level
        level += 1;                     // level increases by 1 when the player wins the current level
        victoryPanel.SetActive(true);   // shows the win panel for the level
        GameController.SaveLevel();     // calling the method to save the level achieved
    }

    // trigerred in a player defeat situation
    public void Defeat()
    {
        finished = true;                // setting the status of the game to "finished" when the player loses the current level
        defeatPanel.SetActive(true);    // shows the defeat panel for the level
    }

    // triggered when the PLAY or START button of the win or defeat panels, respectively, is pressed
    public void RestartLevel()
    {
        // restarts the current level
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    // trigerred when the MENU button of either win or defeat panels is pressed
    public void LoadMenu()
    {
        // loads the MainMenu scene
        SceneManager.LoadScene("MainMenu"); 
    }
}

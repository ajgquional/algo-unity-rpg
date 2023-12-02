/* **************************************************
 * Author: 
 *      Adrian Josele G. Quional
 * 
 * Program description: 
 *      This program controls the level: checks if the 
 *      player has won or lost, and increases the
 *      difficulty of the next level when the player has
 *      won the current level.
 * 
 * How to use the script:
 *      - Attach the script to the Level object
 * **************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Spawner spawner;                 // link to the spawner object in the scene
    public static bool finished = false;    // status of the game level (false = not yet finished, true = finished)
    public static int level = 1;            // value of the game level

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
        print("Victory!");  // temporary indicator for player victory 
        finished = true;    // setting the status of the game to "finished" when the player wins the current level
        level += 1;         // level increases by 1 when the player wins the current level
    }

    // trigerred in a player defeat situation
    public void Defeat()
    {
        print("Defeat!");   // temporary indicator for player defeat 
        finished = true;    // setting the status of the game to "finished" when the player loses the current level
        level -= 1;         // level drops by 1 when the player loses the current level
    }
}

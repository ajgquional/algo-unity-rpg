/* **************************************************
 * Author: 
 *      Adrian Josele G. Quional
 * 
 * Program description: 
 *      This program implements the generation of the
 *      enemies in the game.
 * 
 * How to use the script:
 *      - Setup the spawner first
 *          - Create an empty Spawner object and put it
 *              outside to the right of the game scene
 *          - Inside the Spawner object, create two
 *              empty objects: TopBorder and BottomBorder
 *          - Make sure to reset the position of the
 *              TopBorder and BottomBorder inside the 
 *              Spawner object
 *          - Change the y-coordinate of both TopBorder
 *              and BottomBorder to the desired values
 *              (note that this would affect which height
 *              the enemies would appear on the right)
 *      - Attach the script to the Spawner object
 *      - Remove the scene instance of the Treant, and 
 *          assign the Treant prefab (from the Prefabs folder)
 *          in the Enemy Prefab field of this script
 * **************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // reference to the Enemy component of the cloned object
    public Enemy enemyPrefab;   

    // references to the Transform component of the object generation borders
    public Transform topBorder;
    public Transform bottomBorder;

    // timer interval value and timer actual value (for the creation of the enemies)
    // actual spawnInterval would be between the specified minimum and maximum values
    public float spawnIntervalMax = 3.5f;
    public float spawnIntervalMin = 1f;
    public float spawnTimer = 0f;

    // number of enemies in the level (default number for level 1 is 10)
    public int spawnCounter = 10;

    // add 5 more enemies in the next level
    public int spawnAddPerLevel = 5;

    // set the number of enemies depending on the game level
    void Start()
    {
        // increment the spawnCounter according to the level of the game and the assigned number of enemies to be added
        // limits the number of enemies for that level
        spawnCounter += spawnAddPerLevel * LevelController.level;
    }

    // continuously spawn the assigned number of enemies for that level, as long as the game is not yet finished
    void Update()
    {
        // spawns the enemies only if the level is not finished
        if (LevelController.finished == false)
        {
            // if the spawnTimer is not yet zero, continuously decrement it
            if (spawnTimer > 0)
            {
                spawnTimer -= Time.deltaTime;
            }

            // enemies keep on spawning as long as spawnCounter > 0
            // if spawnCounter == 0, enemies will not be spawned anymore
            else if (spawnCounter > 0)
            {
                Spawn();
            }
        }
    }

    // method to handle the spawn of the enemies
    public void Spawn()
    {
        // decrements the spawnCounter; limits the number of enemies in a particular level
        spawnCounter--; 

        // spawnTimer is assigned a random value in between of the min and max values assigned before
        // thus, randomizing the time interval in-between enemy spawns to introduce unpredictability
        spawnTimer = Random.Range(spawnIntervalMin, spawnIntervalMax);

        // generates a random position for the enemy before spawning it 
        Vector2 randomPosition = new Vector2(this.transform.position.x, Random.Range(topBorder.position.y, bottomBorder.position.y));
        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        // Note: Quaternion.identity means that the clone will not be rotated, i.e. its Rotation property will always be (0,0,0) 
    }
}

/* ****************************************************************************************************
 * AUTHOR: 
 *      Adrian Josele G. Quional
 * ====================================================================================================
 * SCRIPT DESCRIPTION: 
 *      This script implements the operation of the enemy. 
 * ====================================================================================================
 * VERSIONS:
 *      -   Version 1:  Initialized the health and implemented the taking of damage and eventual
 *                      elimination of the enemy.
 *      -   Version 2:  Implemented move and attack mechanics.
 *      -   Version 3:  Implemented a change in the enemy's speed as the game goes into the next level.
 *      -   Version 4:  Implemented an increase in the number of crystals if the enemy is destroyed.
 * ====================================================================================================
 * HOW TO USE THE SCRIPT:
 *      -   Setup the enemy first
 *          -   put the enemy anywhere in the level
 *          -   set "Sorting Layer" to "Items"
 *          -   set "Order in Layer" to 0
 *          -   add a BoxCollider 2D component and edit the size                        [for Version 1]
 *      -   Attach the script to the enemy object                                       [for Version 1]    
 *      -   Setup the cornfield border and attach the Corn script to it                 [for Version 2]
 *      -   Fix the treant-walk-side-4 animation to include an Idle state               [for Version 2]
 *      -   Assign the Treant in the animator field of this script in the 
 *          Inspector window                                                            [for Version 2]
 *      -   Fix the treant-walk-side-4 animation to include a transition 
 *          from idle to walking state when  it appears on the scene itself             [for Version 3]
 * ****************************************************************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // enemy properties:
    public int health = 5;      // default health of the enemy
    public float speed = 1f;    // default speed of the enemy

    // x-coordinate of the cornfield border
    float borderPosX;

    // storing the Animator component of the enemy
    public Animator animator;

    // timer for enemy attacks
    public float attackInterval = 0.75f; // delay between enemy attacks
    public float attackTimer = 0;        // countdown timer for the attack

    // enemy speed multiplier per level
    public float speedPerLevel = 0.2f;

    // cost of each enemy
    public int price;

    // getting the border's x-coordinate and increasing the enemies' speed at the beginning of the level
    void Start()
    {
        // increases the speed of the enemy according to the game level
        speed += speedPerLevel * LevelController.level;

        // assigns the x-coordinate of the cornfield to borderPosX
        borderPosX = Corn.singleton.transform.position.x;
    }

    // continuously move and animate the enemy until it arrives at the border
    // also, attack the cornfield when the enemy stops at the border
    void Update()
    {
        // decrease the timer by the amount of time between frames
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }

        // assigns the x-coordinate of the enemy to enemyPosX
        float enemyPosX = transform.position.x;

        // if the enemy is still far from the border, continuously move the enemy towards the border
        if (enemyPosX > borderPosX)
        {
            // moving the enemy towards the left (thus, the -transform.right)
            transform.position += -transform.right * speed * Time.deltaTime;

            // animates the enemy when it is moving towards the cornfield to the left
            animator.SetBool("isMoving", true);
        }

        // otherwise, the enemy arrives at the border then attack it
        else
        {
            // stops the enemy if it is at the position of the border
            animator.SetBool("isMoving", false);

            // if timer value is 0, attack the cornfield
            // then reset the timer
            if (attackTimer <= 0)
            {
                Attack();
                attackTimer = attackInterval;
            }
        }
    }

    // method to handle reduction in the enemy's health when the enemy is hit by an arrow
    public void TakeDamage()
    {
        // reduce enemy's health by 1
        health -= 1;

        // if health goes down to 0, destroy the enemy
        if (health <= 0)
        {
            Die();
        }
    }

    // method to handle the attack of the enemy
    // basically only calls the TakeDamage() method of the Corn class
    public void Attack()
    {
        Corn.singleton.TakeDamage();
    }

    // when the enemy dies, add a crystal (depending on the cost of each enemy) and destroy the enemy
    public void Die()
    {
        Corn.singleton.AddCrystals(price);
        Destroy(gameObject);
    }
}

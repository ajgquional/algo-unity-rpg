/* **************************************************
 * Author: 
 *      Adrian Josele G. Quional
 * 
 * Program description: 
 *      This program implements the operation of the
 *      crossbow:
 *          - rotates according to the location of the
 *              mouse/finger
 *          - shoots arrows when mouse is pressed or
 *              mobile screen is tapped by finger
 * 
 * How to use the script:
 *      - Setup the crossbow first
 *          - reduce its size
 *          - reposition it to be on the stone
 *          - set "Sorting Layer" to "Items"
 *          - set "Order in Layer" to 2
 *      - Attach the script to the crossbow object
 *      - Setup the arrow next
 *      - Assign the arrow prefab to the Arrow Prefab
 *          field of the script
 * **************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public Arrow arrowPrefab;           // prefab of the arrow, assignable via Inspector window       
    public float shootInterval = 0.75f; // delay between arrow shots
    public float shootTimer = 0;        // countdown timer for the arrow

    // continuously implement the operation of the crossbow while the game is running
    void Update()
    {
        // decrease the timer by the amount of time between frames
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }

        // if left mouse button is pressed/finger is present on the screen,
        // continuously rotate the crossbow and shoot an arrow
        if (Input.GetMouseButton(0))
        {
            // coordinates:
            Vector2 mouseScreenPos = Input.mousePosition;                           // getting mouse/finger coords
            Vector2 mouseScenePos = Camera.main.ScreenToWorldPoint(mouseScreenPos); // mouse/finger coords -> scene coords
            Vector2 bowPos = transform.position;                                    // getting crossbow coords

            // direction:
            Vector2 wantedDirection = mouseScenePos - bowPos;   // desired rotation of the crossbow is the diff between mouse/finger pos and crossbow pos
            Vector2 defaultDirection = Vector2.up;              // default direction of the crossbow
            float angle = Vector2.SignedAngle(defaultDirection, wantedDirection); // storing the angle value that the crossbow has to turn to
            // notes:
            //  - Angle() method returns values within [0, 180]
            //  - SignedAngle() method returns values within [-180, 180]

            // rotation of the crossbow as Euler angles in degrees relative to the parent transform's rotation
            Vector3 newEuler = new Vector3(0, 0, angle);
            transform.localEulerAngles = newEuler;

            // if timer value is 0, shoot the arrow from the position and rotation of the crossbow
            // then reset the timer
            if (shootTimer <= 0)
            {
                Instantiate(arrowPrefab, transform.position, transform.rotation);
                shootTimer = shootInterval;
            }
        }
    }
}

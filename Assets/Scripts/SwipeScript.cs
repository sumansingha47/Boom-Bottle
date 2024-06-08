using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeScript : MonoBehaviour {

    Vector2 startPos, endPos, direction; // mouse start position, mouse end position, swipe direction
    float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time
    Rigidbody2D rb; // RigidBody2D component reference
    bool throwAllowed = true; // throw allowed bool variable to let ball be thrown only once per attempt

    [Range (0.05f, 1f)]             // slider for inspector window
    public float throwForce = 0.3f; // to control throw force

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get RigidBody2D component
    }

    // Update is called once per frame
    void Update () {

        // if you press the left mouse button
        if (Input.GetMouseButtonDown(0)) {

            // getting mouse position and marking time when you press the mouse button
            touchTimeStart = Time.time;
            startPos = Input.mousePosition;
        }

        // if you release the left mouse button
        if (Input.GetMouseButtonUp(0) && throwAllowed) {

            // marking time when you release it
            touchTimeFinish = Time.time;

            // calculate swipe time interval 
            timeInterval = touchTimeFinish - touchTimeStart;

            // getting release mouse position
            endPos = Input.mousePosition;

            // calculating swipe direction
            direction = startPos - endPos;

            // add force to ball rigidbody depending on swipe time and direction
            rb.isKinematic = false;
            rb.AddForce(-direction / timeInterval * throwForce);
            // one attempt to throw a ball only
            throwAllowed = false;

        }

        // Optional: Reset throwAllowed with a key press (e.g., "R" key)
        if (Input.GetKeyDown(KeyCode.R)) {
            throwAllowed = true;
        }
    }
}

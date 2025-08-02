using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour {

    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 2f;

    private int waypointIndex = 0;

    private bool forwards = true;

    private Transform target;
    public float rotationSpeed = 5f; // Adjust for desired rotation speed

    private void Start()
    {

        transform.position = waypoints[waypointIndex].transform.position;
    }

    private void Update()
    {
        target = waypoints[waypointIndex].transform;
        Move();
        if (target == null) return;

            // Calculate the vector from the sprite to the target
            Vector3 vectorToTarget = target.position - transform.position;

            // Calculate the angle in degrees
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        // If your sprite's "forward" direction (the direction it faces when angle is 0)
        // is not aligned with the positive X-axis, you might need to adjust the angle.
        // For example, if it faces "up" (positive Y) at angle 0, subtract 90:
        angle -= 90f; 
            

            // Create a Quaternion from the angle around the Z-axis (for 2D rotation)
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Smoothly rotate the sprite towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
	}

    private void Move()
    {

        if ((waypointIndex <= waypoints.Length - 1) && forwards)
        {

            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                if (waypointIndex == waypoints.Length-1)
                {
                    forwards = false;
                }
                else
                {
                    waypointIndex += 1;
                }
            }

        }
        else if ((waypointIndex >= 0) && !forwards)
        {
            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                if (waypointIndex == 0)
                {
                    forwards = true;
                }
                else
                {
                    waypointIndex -= 1;
                }
            }
            
        }
    }
}
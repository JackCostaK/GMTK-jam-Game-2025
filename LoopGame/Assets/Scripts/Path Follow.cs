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

	private void Start()
    {

        transform.position = waypoints[waypointIndex].transform.position;
    }
	
	private void Update () {

        Move();
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
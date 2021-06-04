using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int waypointIndex;

    void Start()
    {
        target = Waypoints.waypoints[0];
    }

    void Update()
    {
        // Get the direction to the next waypoint
        // Travel that direction in world space
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // If at (or near) the waypoint, move to the next waypoint
        if(Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            GetNextWaypoint();
        }
    }

    // Increments the waypoint index
    // Destroys the game object if at the last waypoint
    void GetNextWaypoint()
    {
        if(waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }
}

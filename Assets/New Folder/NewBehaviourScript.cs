using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    public Transform[] waypoints; // Array to hold the waypoints
    public float moveSpeed = 5f; // Speed at which the truck moves
    private int currentWaypointIndex = 0; // Index of the current waypoint

    void Update()
    {
        // Check if there are waypoints to follow
        if (waypoints.Length == 0)
        {
            Debug.LogWarning("No waypoints assigned to the truck.");
            return;
        }

        // Move the truck towards the current waypoint
        MoveTowardsWaypoint();
    }

    void MoveTowardsWaypoint()
    {
        // Get the current waypoint
        Transform currentWaypoint = waypoints[currentWaypointIndex];

        // Calculate direction and move towards the waypoint
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);

        // Check if the truck has reached the current waypoint
        if (Vector3.Distance(transform.position, currentWaypoint.position) < 0.1f)
        {
            // Move to the next waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}

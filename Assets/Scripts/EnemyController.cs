using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float movementSpeed = 2f;
    public Transform[] waypoints;

    private Transform currentWaypoint;

    private void Start()
    {
        InvokeRepeating("TeleportToRandomWaypoint", 15f, 15f);
    }

    private void TeleportToRandomWaypoint()
    {
        int randomIndex = Random.Range(0, waypoints.Length);
        currentWaypoint = waypoints[randomIndex];
        transform.position = currentWaypoint.position;
        transform.rotation = currentWaypoint.rotation;
    }
}
